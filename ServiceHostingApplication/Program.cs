using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using Common.Logging;

namespace ServiceHostingApplication
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            const string baseAddress = "http://localhost:8080/";
            List<ServiceHost> serviceHosts = CreateAndOpenServiceHosts(new List<Type>
            {
                typeof (PerCallWcfService.PerCallWcfService),
                typeof (PerSessionWcfService.PerSessionWcfService),
                typeof (SingletonWcfService.SingletonWcfService)
            }, baseAddress);

            PenetrateServices(baseAddress);

            ShutdownAndClose(serviceHosts);
        }

        private static void PenetrateServices(String baseAddress)
        {
            const int messagesPerService = 10;
            const int sleepingInMillisecondsPerCall = 1000;
            Log.Info("Requesting " + messagesPerService + " msg * " + sleepingInMillisecondsPerCall + "ms");
            PenetratePerCallService(messagesPerService);
            PenetratePerSessionService(messagesPerService);
            PenetrateSingletonService(messagesPerService);
        }

        private static void PenetratePerCallService(int messagesPerService)
        {
            var serviceClient = new PerCallWcfServiceClient.PerCallWcfServiceClient("BasicHttpBinding_IPerCallWcfService");

            for (int i = 0; i < messagesPerService; i++)
            {
                var ct = new PerCallWcfServiceClient.CompositeType
                {
                    BoolValue = true,
                    StringValue = Guid.NewGuid().ToString()
                };

                serviceClient.GetDataUsingDataContract(ct);

                if(i % 10 == 0 && i != 0)
                    Log.Info("At request " + i + ".");
            }
        }

        private static void PenetratePerSessionService(int messagesPerService)
        {
            var serviceClient = new PerSessionWcfServiceClient.PerSessionWcfServiceClient("BasicHttpBinding_IPerSessionWcfService");

            for (int i = 0; i < messagesPerService; i++)
            {
                var ct = new PerSessionWcfServiceClient.CompositeType
                {
                    BoolValue = true,
                    StringValue = Guid.NewGuid().ToString()
                };

                serviceClient.GetDataUsingDataContract(ct);

                if (i % 10 == 0 && i != 0)
                    Log.Info("At request " + i + ".");
            }
        }

        private static void PenetrateSingletonService(int messagesPerService)
        {
            var serviceClient = new SingletonWcfServiceClient.SingletonWcfServiceClient("BasicHttpBinding_ISingletonWcfService");

            for (int i = 0; i < messagesPerService; i++)
            {
                var ct = new SingletonWcfServiceClient.CompositeType
                {
                    BoolValue = true,
                    StringValue = Guid.NewGuid().ToString()
                };

                serviceClient.GetDataUsingDataContract(ct);

                if (i % 10 == 0 && i != 0)
                    Log.Info("At request " + i + ".");
            }
        }

        private static void ShutdownAndClose(List<ServiceHost> serviceHosts)
        {
            Log.Info("Press <Enter> to stop the services.");
            Console.ReadLine();
            CloseServiceHosts(serviceHosts);
        }

        private static List<ServiceHost> CreateAndOpenServiceHosts(IEnumerable<Type> serviceTypes, String BaseAddress)
        {
            var serviceHosts = serviceTypes.Select(serviceType => CreateConfiguredServiceHost(serviceType, BaseAddress)).ToList();
            foreach (ServiceHost serviceHost in serviceHosts)
            {
                serviceHost.Open();
            }

            Log.Info("Started " + serviceHosts.Count + " ServiceHosts.");
            serviceHosts.ForEach(serviceHost => Log.Info("Started " + String.Join(", ", serviceHost.BaseAddresses.Select(m => m.AbsoluteUri).ToList())));

            return serviceHosts;
        }

        private static void CloseServiceHosts(IEnumerable<ServiceHost> serviceHosts)
        {
            foreach (ServiceHost serviceHost in serviceHosts)
            {
                serviceHost.Close();
            }
        }

        private static ServiceHost CreateConfiguredServiceHost(Type typeOfService, String baseAddress)
        {
            var host = new ServiceHost(typeOfService, new Uri(baseAddress + typeOfService.Name + ".svc"));

            // Enable metadata publishing.
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(smb);

            return host;
        }
    }
}