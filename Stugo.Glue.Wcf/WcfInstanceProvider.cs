using Stugo.Logging;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Stugo.Glue.Wcf
{
    class WcfInstanceProvider : IInstanceProvider
    {
        private static readonly ILog logger = Logger.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IContainer container;


        public WcfInstanceProvider(IContainer container)
        {
            this.container = container;
        }


        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }


        public object GetInstance(InstanceContext instanceContext)
        {
            var serviceType = instanceContext.Host.Description.ServiceType;
            logger.Trace($"Constructing service instance for {serviceType.FullName}", nameof(GetInstance));
            return this.container.Resolve(serviceType);
        }


        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            logger.Trace($"Releasing service instance of type {instance.GetType().FullName}", nameof(ReleaseInstance));
            var disposable = instance as IDisposable;

            if (disposable != null)
                disposable.Dispose();
        }
    }
}
