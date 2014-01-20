using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using Common.Logging;

namespace ServiceHostingApplication
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private static void Main()
        {
            const string baseAddress = "http://localhost:8080/";
            IEnumerable<ServiceHost> serviceHosts = CreateAndOpenServiceHosts(new List<Type>
            {
                typeof (PerCallWcfService.PerCallWcfService),
                typeof (PerSessionWcfService.PerSessionWcfService),
                typeof (SingletonWcfService.SingletonWcfService)
            }, baseAddress);

            const int messagesPerService = 1000;
            const int sleepingInMillisecondsPerCall = 100;
            const bool busyServiceCall = true;

            PenetrateServices(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall);
            ShutdownAndClose(serviceHosts);
        }

        private static void PenetrateServices(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall)
        {
            Log.Info("Requesting " + messagesPerService + " msg * " + sleepingInMillisecondsPerCall + "ms");
            PenetratePerCallService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall);
            PenetratePerSessionService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall);
            PenetrateSingletonService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall);
        }

        private static void PenetratePerCallService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall)
        {
            Log.Info("Starting to penetrate PerCallWcfService.");
            var serviceClient = new PerCallWcfServiceClient.PerCallWcfServiceClient("BasicHttpBinding_IPerCallWcfService");
            var tasks = new Task[messagesPerService];
            for (int i = 0; i < messagesPerService; i++)
            {
                if (busyServiceCall)
                    tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, new Guid());
                else
                    tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, new Guid());

                if (i % 10 == 0 && i != 0)
                    Log.Info("Sending request " + i + ".");
            }
            Task.WaitAll(tasks);
            Log.Info("Finished penetrating PerCallWcfService.");
        }

        private static void PenetratePerSessionService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall)
        {
            Log.Info("Starting to penetrate PerSessionWcfService.");
            var serviceClient = new PerSessionWcfServiceClient.PerSessionWcfServiceClient("BasicHttpBinding_IPerSessionWcfService");
            var tasks = new Task[messagesPerService];
            for (int i = 0; i < messagesPerService; i++)
            {
                if (busyServiceCall)
                    tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, new Guid());
                else
                    tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, new Guid());

                if (i % 10 == 0 && i != 0)
                    Log.Info("Sending request " + i + ".");
            }
            Task.WaitAll(tasks);
            Log.Info("Finished penetrating PerSessionWcfService.");
        }

        private static void PenetrateSingletonService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall)
        {
            Log.Info("Starting to penetrate SingletonWcfService.");
            var serviceClient = new SingletonWcfServiceClient.SingletonWcfServiceClient("BasicHttpBinding_ISingletonWcfService");

            var tasks = new Task[messagesPerService];
            for (int i = 0; i < messagesPerService; i++)
            {
                if (busyServiceCall)
                    tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, new Guid());
                else
                    tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, new Guid());

                if (i % 10 == 0 && i != 0)
                    Log.Info("Sending request " + i + ".");
            }
            Task.WaitAll(tasks);
            Log.Info("Finished penetrating SingletonWcfService.");
        }

        private static void ShutdownAndClose(IEnumerable<ServiceHost> serviceHosts)
        {
            Log.Info("Press <Enter> to stop the services.");
            Console.ReadLine();
            CloseServiceHosts(serviceHosts);
        }

        private static IEnumerable<ServiceHost> CreateAndOpenServiceHosts(IEnumerable<Type> serviceTypes, String baseAddress)
        {
            var serviceHosts = serviceTypes.Select(serviceType => CreateConfiguredServiceHost(serviceType, baseAddress)).ToList();
            foreach (var serviceHost in serviceHosts)
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
            var smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true,
                MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}
            };

            host.Description.Behaviors.Add(smb);
            return host;
        }
    }
}