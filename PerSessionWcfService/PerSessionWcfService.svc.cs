using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using Common.Logging;
using SharedLib;

namespace PerSessionWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] 
    public class PerSessionWcfService : IPerSessionWcfService
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
                if (until > DateTime.UtcNow)
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
