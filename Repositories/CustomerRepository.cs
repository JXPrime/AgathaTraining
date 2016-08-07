using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer Get(string id)
        {
            return new Customer
            {
                FirstName = "Bob",
                LastName = "Customer",
                Id = id
            };
        }
    }
}
