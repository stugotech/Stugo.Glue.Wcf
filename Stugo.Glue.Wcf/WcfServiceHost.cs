using Stugo.Logging;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Stugo.Glue.Wcf
{
    public class WcfServiceHost : ServiceHost
    {
        private static readonly ILog logger = Logger.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        internal readonly IContainer container;


        public WcfServiceHost(IContainer container, Type serviceType, bool includeExceptionDetailInFaults, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            logger.Debug($"Starting service host for {serviceType.FullName} at {string.Join(",", baseAddresses.Select(x => x.ToString()))}");
            this.container = container;


            foreach (var contract in ImplementedContracts.Values)
            {
                logger.Trace($"Adding behaviour for contract {contract.Name}");
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
                logger.Trace("Setting IncludeExceptionDetailInFaults = true");
            }
        }
    }
}
