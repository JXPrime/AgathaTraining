using Agatha.Common;
using Agatha.StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClientStartup
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
                    a.WithDefaultConventions();
                });
            });

            var agathaContainer = new Container(container);

            var messageAssembly = Assembly.GetAssembly(typeof(Messages.GetCustomer));

            var agathaClientConfiguration = new ClientConfiguration(messageAssembly, agathaContainer);
            agathaClientConfiguration.Initialize();

            return container;
        }
    }
}
