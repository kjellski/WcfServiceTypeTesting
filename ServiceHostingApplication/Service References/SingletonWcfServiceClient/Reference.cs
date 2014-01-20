﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceHostingApplication.SingletonWcfServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SingletonWcfServiceClient.ISingletonWcfService")]
    public interface ISingletonWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISingletonWcfService/SleepForMilliseconds", ReplyAction="http://tempuri.org/ISingletonWcfService/SleepForMillisecondsResponse")]
        System.Guid SleepForMilliseconds(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISingletonWcfService/SleepForMilliseconds", ReplyAction="http://tempuri.org/ISingletonWcfService/SleepForMillisecondsResponse")]
        System.Threading.Tasks.Task<System.Guid> SleepForMillisecondsAsync(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISingletonWcfService/BusySleepForMilliseconds", ReplyAction="http://tempuri.org/ISingletonWcfService/BusySleepForMillisecondsResponse")]
        System.Guid BusySleepForMilliseconds(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISingletonWcfService/BusySleepForMilliseconds", ReplyAction="http://tempuri.org/ISingletonWcfService/BusySleepForMillisecondsResponse")]
        System.Threading.Tasks.Task<System.Guid> BusySleepForMillisecondsAsync(int ms, System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISingletonWcfService/GetData", ReplyAction="http://tempuri.org/ISingletonWcfService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISingletonWcfService/GetData", ReplyAction="http://tempuri.org/ISingletonWcfService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISingletonWcfService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ISingletonWcfService/GetDataUsingDataContractResponse")]
        SharedLib.CompositeType GetDataUsingDataContract(SharedLib.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISingletonWcfService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ISingletonWcfService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<SharedLib.CompositeType> GetDataUsingDataContractAsync(SharedLib.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISingletonWcfServiceChannel : ServiceHostingApplication.SingletonWcfServiceClient.ISingletonWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SingletonWcfServiceClient : System.ServiceModel.ClientBase<ServiceHostingApplication.SingletonWcfServiceClient.ISingletonWcfService>, ServiceHostingApplication.SingletonWcfServiceClient.ISingletonWcfService {
        
        public SingletonWcfServiceClient() {
        }
        
        public SingletonWcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SingletonWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SingletonWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SingletonWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
