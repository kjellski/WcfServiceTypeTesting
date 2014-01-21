using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;

namespace SharedLib
{
    public class SharedServicesMethods
    {
        public readonly ILog Log = LogManager.GetCurrentClassLogger();

        public Guid SleepForMilliseconds(int ms, Guid guid)
        {
            var now = DateTime.UtcNow;

            //Log.Debug("SleepForMilliseconds(int ms = " + ms + ", Guid guid = " + guid + ")");
            Thread.Sleep(ms);
            Log.Info("SleepForMilliseconds(int ms = " + ms + ", Guid guid = " + guid + ") took " + (DateTime.UtcNow - now));

            return guid;
        }

        public async Task<Guid> TaskedSleepForMilliseconds(int ms, Guid guid)
        {
            var now = DateTime.UtcNow;

            //Log.Debug("SleepForMillisecondsAsync(int ms = " + ms + ", Guid guid = " + guid + ")");
            await Task.Factory.StartNew(() => Thread.Sleep(ms));
            Log.Info("SleepForMillisecondsAsync(int ms = " + ms + ", Guid guid = " + guid + ") took " + (DateTime.UtcNow - now));

            return guid;
        }

        public Guid BusySleepForMilliseconds(int ms, Guid guid)
        {
            var now = DateTime.UtcNow;

            //Log.Debug("BusySleepForMilliseconds(int ms = " + ms + ", Guid guid = " + guid + ")");
            DateTime until = now + TimeSpan.FromMilliseconds(ms);
            while (true)
            {
                if (DateTime.UtcNow > until)
                    break;

            }
            Log.Info("BusySleepForMilliseconds(int ms = " + ms + ", Guid guid = " + guid + ") took " + (DateTime.UtcNow - now));

            return guid;
        }

        public async Task<Guid> TaskedBusySleepForMilliseconds(int ms, Guid guid)
        {
            var now = DateTime.UtcNow;

            //Log.Debug("BusySleepForMillisecondsAsync(int ms = " + ms + ", Guid guid = " + guid + ")");
            DateTime until = now + TimeSpan.FromMilliseconds(ms);
            await Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (DateTime.UtcNow > until)
                        break;

                }
            });

            Log.Info("BusySleepForMillisecondsAsync(int ms = " + ms + ", Guid guid = " + guid + ") took " + (DateTime.UtcNow - now));

            return guid;
        }

        public string GetData(int value)
        {
            Log.DebugFormat("GetData({0});", value);
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            Log.DebugFormat("GetDataUsingDataContract({0});", composite);

            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}