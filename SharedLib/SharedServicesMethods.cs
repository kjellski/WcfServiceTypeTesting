using System;
using System.Threading;
using Common.Logging;

namespace SharedLib
{
    public class SharedServicesMethods
    {
        public readonly ILog Log = LogManager.GetCurrentClassLogger();

        public Guid SleepForMilliseconds(int ms, Guid guid)
        {
            Log.Debug("SleepForMilliseconds(int ms = " + ms + ", Guid guid = " + guid + ")");
            Thread.Sleep(ms);
            return guid;
        }

        public Guid BusySleepForMilliseconds(int ms, Guid guid)
        {
            Log.Debug("BusySleepForMilliseconds(int ms = " + ms + ", Guid guid = " + guid + ")");
            DateTime until = DateTime.UtcNow + TimeSpan.FromMilliseconds(ms);

            while (true)
            {
                if (DateTime.UtcNow > until)
                    break;
            }

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