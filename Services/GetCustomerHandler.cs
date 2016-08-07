using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agatha.Common;
using Messages;
using Domain.Repositories;

namespace Services
{
    public class GetCustomerHandler : Agatha.ServiceLayer.RequestHandler<Messages.GetCustomer, Messages.GetCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override Response Handle(GetCustomer request)
        {
            var customer = _customerRepository.Get(request.Id);

            var response = new GetCustomerResponse();

            if (customer == null)
                throw new ApplicationException($"Customer with Id {request.Id} not found.");

            response.Customer = new CustomerDto
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Id = customer.Id
            };

            return response;
        }
    }
}
