using Agatha.Common.InversionOfControl;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientStartup.Startup.Start();

            var requestDispatcher = IoC.Container.Resolve<Agatha.Common.IRequestDispatcher>();

            //try and get a customer!

            var response = requestDispatcher.Get<GetCustomerResponse>(new GetCustomer
            {
                Id = "customers/1"
            });

            Console.WriteLine(response.Customer.FirstName);

            Console.WriteLine("hooray!");

            Console.ReadLine();
        }
    }
}
