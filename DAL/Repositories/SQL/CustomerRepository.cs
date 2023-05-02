using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.SQL
{
    internal class CustomerRepository : IGenericRepository<Customer>
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
