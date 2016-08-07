using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public abstract class Entity
    {
        public string Id { get; set; }
    }

    namespace Repositories
    {

        public interface ICustomerRepository
        {
            Customer Get(string id);
        }
    }
}
