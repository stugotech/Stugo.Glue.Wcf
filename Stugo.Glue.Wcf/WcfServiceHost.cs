using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace Stugo.Glue.Wcf
{
    public class WcfServiceHost : ServiceHost
    {
        internal readonly IContainer container;


        public WcfServiceHost(IContainer container, Type serviceType, bool includeExceptionDetailInFaults, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.container = container;


            foreach (var contract in ImplementedContracts.Values)
            {
                var provider = new WcfInstanceProvider(container);
                var behaviour = new WcfInstanceBehaviour(provider);
                contract.Behaviors.Add(behaviour);
            }

            if (includeExceptionDetailInFaults)
            {
                var serviceDebugBehaviour = this.Description.Behaviors
                    .OfType<ServiceDebugBehavior>()
                    .FirstOrDefault();

                if (serviceDebugBehaviour == null)
                {
                    serviceDebugBehaviour = new ServiceDebugBehavior();
                    this.Description.Behaviors.Add(serviceDebugBehaviour);
                }

                serviceDebugBehaviour.IncludeExceptionDetailInFaults = true;
            }
        }
    }
}
