using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using SharedLib;

namespace PerCallWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPerCallWcfService
    {
        [OperationContract]
        Guid SleepForMilliseconds(int ms, Guid guid);
        
        [OperationContract]
        Guid BusySleepForMilliseconds(int ms, Guid guid);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }
}
