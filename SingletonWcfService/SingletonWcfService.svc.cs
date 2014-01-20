using System;
using System.ServiceModel;
using System.Threading;
using Common.Logging;
using SharedLib;

namespace SingletonWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SingletonWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SingletonWcfService.svc or SingletonWcfService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SingletonWcfService : SharedServicesMethods, ISingletonWcfService
    {
    }
}
