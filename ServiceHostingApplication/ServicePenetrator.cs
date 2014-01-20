using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace ServiceHostingApplication
{
    class ServicePenetrator
    {
        private readonly ILog Log = LogManager.GetCurrentClassLogger();

        public void PenetrateServices(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall)
        {
            Log.Info("Penetrating services with " + messagesPerService + "msg, lettings them wait for " 
                + sleepingInMillisecondsPerCall + "ms. The calls "
                + (busyServiceCall ? "will be busy." : "won't be busy."));
            PenetratePerCallService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall);
            PenetratePerSessionService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall);
            //PenetrateSingletonService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall);
        }

        private void PenetratePerCallService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall)
        {
            Log.Info("Starting to penetrate PerCallWcfService.");
            var serviceClient = new PerCallWcfServiceClient.PerCallWcfServiceClient("BasicHttpBinding_IPerCallWcfService");

            var tasks = new Task[messagesPerService];
            for (int i = 1; i <= messagesPerService; i++)
            {

                if (busyServiceCall)
                    tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                else
                    tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());

                if (i % 10 == 0 && i != 0)
                    Log.Info("Sending request " + i + ".");
            }
            Task.WaitAll(tasks);
            Log.Info("Finished penetrating PerCallWcfService.");
        }

        private void PenetratePerSessionService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall)
        {
            Log.Info("Starting to penetrate PerSessionWcfService.");
            var tasks = new Task[messagesPerService];
            var serviceClient = new PerSessionWcfServiceClient.PerSessionWcfServiceClient("BasicHttpBinding_IPerSessionWcfService");

            for (int i = 1; i <= messagesPerService; i++)
            {
                if (busyServiceCall)
                    tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                else
                    tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());

                if (i % 10 == 0 && i != 0)
                    Log.Info("Sending request " + i + ".");
            }
            Task.WaitAll(tasks);
            Log.Info("Finished penetrating PerSessionWcfService.");
        }

        private void PenetrateSingletonService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall)
        {
            Log.Info("Starting to penetrate SingletonWcfService.");
            var tasks = new Task[messagesPerService];
            for (int i = 1; i <= messagesPerService; i++)
            {
                var serviceClient = new SingletonWcfServiceClient.SingletonWcfServiceClient("BasicHttpBinding_ISingletonWcfService");
                if (busyServiceCall)
                    tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                else
                    tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());

                if (i % 10 == 0 && i != 0)
                    Log.Info("Sending request " + i + ".");
            }
            Task.WaitAll(tasks);
            Log.Info("Finished penetrating SingletonWcfService.");
        }
    }
}
