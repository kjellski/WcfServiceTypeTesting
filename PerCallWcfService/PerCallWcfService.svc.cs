using System;
using System.ServiceModel;
using System.Threading;
using Common.Logging;
using SharedLib;

namespace PerCallWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PerCallWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PerCallWcfService.svc or PerCallWcfService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PerCallWcfService : IPerCallWcfService
    {
        public readonly ILog Log = LogManager.GetCurrentClassLogger();

        public Guid SleepForMilliseconds(int ms, Guid guid)
        {
            Log.Info("SleepForMilliseconds(int ms = " + ms + ", Guid guid = " + guid + ")");
            Thread.Sleep(ms);
            return guid;
        }

        public Guid BusySleepForMilliseconds(int ms, Guid guid)
        {
            Log.Info("SleepForMilliseconds(int ms = " + ms + ", Guid guid = " + guid + ")");
            var now = DateTime.UtcNow;
            var until = now + TimeSpan.FromMilliseconds(ms);

            while (true)
            {
                if(until > DateTime.UtcNow)
                    break;
            }

            return guid;
        }

        public string GetData(int value)
        {
            Log.InfoFormat("GetData({0});", value);
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            Log.InfoFormat("GetDataUsingDataContract({0});", composite);

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
