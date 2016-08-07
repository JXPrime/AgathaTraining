using Agatha.Common;
using Agatha.ServiceLayer;
using Agatha.ServiceLayer.Conventions;
using Agatha.StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStartup
{
    public static class Startup
    {
        public static StructureMap.IContainer Start()
        {
            var container = new StructureMap.Container(x =>
            {
                x.Scan(a =>
                    {
                        a.AssemblyContainingType<Messages.GetCustomer>();
                        a.AssemblyContainingType<Domain.Customer>();
                        a.AssemblyContainingType<Services.GetCustomerHandler>();
                        a.AssemblyContainingType<Repositories.CustomerRepository>();
                        a.WithDefaultConventions();
                    });
            });

            var agathaContainer = new Container(container);
            
            //load your message assembly/s somehow
            Assembly messageAssembly = Assembly.GetAssembly(typeof(Messages.GetCustomer));
            Assembly handlerAssembly = Assembly.GetAssembly(typeof(Services.GetCustomerHandler));

            var agathaServerConfiguration = new ServiceLayerConfiguration(handlerAssembly, messageAssembly, agathaContainer).Use<RequestHandlerBasedConventions>();
            
            agathaServerConfiguration.Initialize();

            return container;
        }
    }
}
