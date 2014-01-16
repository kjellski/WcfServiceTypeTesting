using System;
using System.ServiceModel;

namespace PerCallWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PerCallWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PerCallWcfService.svc or PerCallWcfService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 
    public class PerCallWcfService : IPerCallWcfService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
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
