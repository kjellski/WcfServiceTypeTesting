using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using SharedLib;

namespace SingletonWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISingletonWcfService
    {
        [OperationContract]
        Guid SleepForMilliseconds(int ms, Guid guid);

        [OperationContract]
        Guid BusySleepForMilliseconds(int ms, Guid guid);

        [OperationContract]
        Task<Guid> TaskedSleepForMilliseconds(int ms, Guid guid);

        [OperationContract]
        Task<Guid> TaskedBusySleepForMilliseconds(int ms, Guid guid);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }
}
