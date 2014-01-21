using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Common.Logging;

namespace ServiceHostingApplication
{
    class ServicePenetrator
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();

        public void PenetrateServices(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall, bool tasked)
        {
            _log.Info("Penetrating services with " + messagesPerService + "msg, lettings them wait for "
                + sleepingInMillisecondsPerCall + "ms. The calls "
                + (busyServiceCall ? "will be busy" : "won't be busy")
                + " and " + (tasked ? "tasked." : "untasked." ));
            PenetratePerCallService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall, tasked);
            PenetratePerSessionService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall, tasked);
            //PenetrateSingletonService(messagesPerService, sleepingInMillisecondsPerCall, busyServiceCall, tasked);
        }

        private void PenetratePerCallService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall, bool tasked)
        {
            _log.Info("Starting to penetrate PerCallWcfService.");
            var sw = new Stopwatch();
            sw.Start();
            var serviceClient = new PerCallWcfServiceClient.PerCallWcfServiceClient("BasicHttpBinding_IPerCallWcfService");

            var tasks = new Task[messagesPerService];
            var progress = 0.0;
            for (int i = 0; i < messagesPerService; i++)
            {
                if (tasked)
                {
                    if (busyServiceCall)
                        tasks[i] = serviceClient.TaskedBusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                    else
                        tasks[i] = serviceClient.TaskedSleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                }
                else
                {
                    if (busyServiceCall)
                        tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                    else
                        tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                }

                var percent = (i * 1.0 / messagesPerService * 100f);
                if (progress + 10 < percent)
                {
                    _log.Info("Sending request " + i + " (" + (progress) + "%) ...");
                    progress = percent;
                }
            }
            Task.WaitAll(tasks);
            serviceClient.Close();
            _log.Info("Finished penetrating PerCallWcfService, took " + sw.ElapsedMilliseconds + "ms.");
        }

        private void PenetratePerSessionService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall, bool tasked)
        {
            _log.Info("Starting to penetrate PerSessionWcfService.");
            var sw = new Stopwatch();
            sw.Start();
            var tasks = new Task[messagesPerService];
            var serviceClient = new PerSessionWcfServiceClient.PerSessionWcfServiceClient("BasicHttpBinding_IPerSessionWcfService");

            var progress = 0.0;
            for (int i = 0; i < messagesPerService; i++)
            {
                if (tasked)
                {
                    if (busyServiceCall)
                        tasks[i] = serviceClient.TaskedBusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                    else
                        tasks[i] = serviceClient.TaskedSleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                }
                else
                {
                    if (busyServiceCall)
                        tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                    else
                        tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                }

                var percent = (i * 1.0 / messagesPerService * 100f);
                if (progress + 10 < percent)
                {
                    _log.Info("Sending request " + i + " (" + (progress) + "%) ...");
                    progress = percent;
                }
            }
            Task.WaitAll(tasks);
            serviceClient.Close();
            _log.Info("Finished penetrating PerSessionWcfService, took " + sw.ElapsedMilliseconds + "ms.");
        }

        private void PenetrateSingletonService(int messagesPerService, int sleepingInMillisecondsPerCall, bool busyServiceCall, bool tasked)
        {
            _log.Info("Starting to penetrate SingletonWcfService.");
            var sw = new Stopwatch();
            sw.Start();
            var tasks = new Task[messagesPerService];
            var serviceClient = new SingletonWcfServiceClient.SingletonWcfServiceClient("BasicHttpBinding_ISingletonWcfService");

            var progress = 0.0;
            for (int i = 0; i < messagesPerService; i++)
            {
                if (tasked)
                {
                    if (busyServiceCall)
                        tasks[i] = serviceClient.TaskedBusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                    else
                        tasks[i] = serviceClient.TaskedSleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                }
                else
                {
                    if (busyServiceCall)
                        tasks[i] = serviceClient.BusySleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                    else
                        tasks[i] = serviceClient.SleepForMillisecondsAsync(sleepingInMillisecondsPerCall, Guid.NewGuid());
                }

                var percent = (i * 1.0 / messagesPerService * 100f);
                if (progress + 10 < percent)
                {
                    _log.Info("Sending request " + i + " (" + (progress) + "%) ...");
                    progress = percent;
                }
            }
            Task.WaitAll(tasks);
            serviceClient.Close();
            _log.Info("Finished penetrating SingletonWcfService, took " + sw.ElapsedMilliseconds + "ms.");
        }
    }
}
