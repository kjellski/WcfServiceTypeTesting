﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceHostingApplication.PerCallWcfServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PerCallWcfServiceClient.IPerCallWcfService")]
    public interface IPerCallWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/SleepForMilliseconds", ReplyAction="http://tempuri.org/IPerCallWcfService/SleepForMillisecondsResponse")]
        System.Guid SleepForMilliseconds(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/SleepForMilliseconds", ReplyAction="http://tempuri.org/IPerCallWcfService/SleepForMillisecondsResponse")]
        System.Threading.Tasks.Task<System.Guid> SleepForMillisecondsAsync(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/BusySleepForMilliseconds", ReplyAction="http://tempuri.org/IPerCallWcfService/BusySleepForMillisecondsResponse")]
        System.Guid BusySleepForMilliseconds(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/BusySleepForMilliseconds", ReplyAction="http://tempuri.org/IPerCallWcfService/BusySleepForMillisecondsResponse")]
        System.Threading.Tasks.Task<System.Guid> BusySleepForMillisecondsAsync(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/TaskedSleepForMilliseconds", ReplyAction="http://tempuri.org/IPerCallWcfService/TaskedSleepForMillisecondsResponse")]
        System.Guid TaskedSleepForMilliseconds(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/TaskedSleepForMilliseconds", ReplyAction="http://tempuri.org/IPerCallWcfService/TaskedSleepForMillisecondsResponse")]
        System.Threading.Tasks.Task<System.Guid> TaskedSleepForMillisecondsAsync(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/TaskedBusySleepForMilliseconds", ReplyAction="http://tempuri.org/IPerCallWcfService/TaskedBusySleepForMillisecondsResponse")]
        System.Guid TaskedBusySleepForMilliseconds(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/TaskedBusySleepForMilliseconds", ReplyAction="http://tempuri.org/IPerCallWcfService/TaskedBusySleepForMillisecondsResponse")]
        System.Threading.Tasks.Task<System.Guid> TaskedBusySleepForMillisecondsAsync(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/GetData", ReplyAction="http://tempuri.org/IPerCallWcfService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/GetData", ReplyAction="http://tempuri.org/IPerCallWcfService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IPerCallWcfService/GetDataUsingDataContractResponse")]
        SharedLib.CompositeType GetDataUsingDataContract(SharedLib.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPerCallWcfService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IPerCallWcfService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<SharedLib.CompositeType> GetDataUsingDataContractAsync(SharedLib.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPerCallWcfServiceChannel : ServiceHostingApplication.PerCallWcfServiceClient.IPerCallWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PerCallWcfServiceClient : System.ServiceModel.ClientBase<ServiceHostingApplication.PerCallWcfServiceClient.IPerCallWcfService>, ServiceHostingApplication.PerCallWcfServiceClient.IPerCallWcfService {
        
        public PerCallWcfServiceClient() {
        }
        
        public PerCallWcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PerCallWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PerCallWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PerCallWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Guid SleepForMilliseconds(int ms, System.Guid guid) {
            return base.Channel.SleepForMilliseconds(ms, guid);
        }
        
        public System.Threading.Tasks.Task<System.Guid> SleepForMillisecondsAsync(int ms, System.Guid guid) {
            return base.Channel.SleepForMillisecondsAsync(ms, guid);
        }
        
        public System.Guid BusySleepForMilliseconds(int ms, System.Guid guid) {
            return base.Channel.BusySleepForMilliseconds(ms, guid);
        }
        
        public System.Threading.Tasks.Task<System.Guid> BusySleepForMillisecondsAsync(int ms, System.Guid guid) {
            return base.Channel.BusySleepForMillisecondsAsync(ms, guid);
        }
        
        public System.Guid TaskedSleepForMilliseconds(int ms, System.Guid guid) {
            return base.Channel.TaskedSleepForMilliseconds(ms, guid);
        }
        
        public System.Threading.Tasks.Task<System.Guid> TaskedSleepForMillisecondsAsync(int ms, System.Guid guid) {
            return base.Channel.TaskedSleepForMillisecondsAsync(ms, guid);
        }
        
        public System.Guid TaskedBusySleepForMilliseconds(int ms, System.Guid guid) {
            return base.Channel.TaskedBusySleepForMilliseconds(ms, guid);
        }
        
        public System.Threading.Tasks.Task<System.Guid> TaskedBusySleepForMillisecondsAsync(int ms, System.Guid guid) {
            return base.Channel.TaskedBusySleepForMillisecondsAsync(ms, guid);
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public SharedLib.CompositeType GetDataUsingDataContract(SharedLib.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<SharedLib.CompositeType> GetDataUsingDataContractAsync(SharedLib.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
