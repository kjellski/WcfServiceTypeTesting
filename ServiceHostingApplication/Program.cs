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

            const int messagesPerService = 5000;
            const int sleepingInMillisecondsPerCall = 100;
            const bool busyServiceCall = true;
            const bool tasked = true;

            var pentester = new ServicePenetrator();
            pentester.PenetrateServices(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall, tasked); // tasked
            pentester.PenetrateServices(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall, !tasked); // untasked
            pentester.PenetrateServices(messagesPerService, sleepingInMillisecondsPerCall, !busyServiceCall, tasked); // tasked
            pentester.PenetrateServices(messagesPerService, sleepingInMillisecondsPerCall, !busyServiceCall, !tasked); // untasked

            ShutdownAndClose(serviceHosts);
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
            host.Opened += (sender, args) => Log.Info(typeOfService.Name + " Host opened");
            
            return host;
        }
    }
}