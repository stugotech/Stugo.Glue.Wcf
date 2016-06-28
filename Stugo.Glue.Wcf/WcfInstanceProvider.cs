using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Stugo.Glue.Wcf
{
    class WcfInstanceProvider : IInstanceProvider
    {
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
            return this.container.Resolve(serviceType);
        }


        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;

            if (disposable != null)
                disposable.Dispose();
        }
    }
}
