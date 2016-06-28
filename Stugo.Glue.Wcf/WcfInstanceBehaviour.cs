using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Stugo.Glue.Wcf
{
    class WcfInstanceBehaviour : IContractBehavior
    {
        private readonly WcfInstanceProvider instanceProvider;


        public WcfInstanceBehaviour(WcfInstanceProvider instanceProvider)
        {
            this.instanceProvider = instanceProvider;
        }


        public virtual void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }


        public virtual void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }


        public virtual void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = instanceProvider;
        }


        public virtual void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }
}
