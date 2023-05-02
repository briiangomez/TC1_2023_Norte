using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Memory
{
    internal class AddressRepository : IGenericRepository<Address>
    {
        List<Address> direcciones = new List<Address>();

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll()
        {
            
            direcciones.Add(new Address() { IdAddress = Guid.NewGuid(), Street = "Bernardo de Irigoyen", Number = 696, City = "Boulogne, Bs As" });
            direcciones.Add(new Address() { IdAddress = Guid.NewGuid(), Street = "Avenida San Juan", Number = 950, City = "CABA" });
            direcciones.Add(new Address() { IdAddress = Guid.NewGuid(), Street = "Calle Falsa", Number = 1234, City = "Springfield, USA" });
            direcciones.Add(new Address() { IdAddress = Guid.NewGuid(), Street = "Avenida Siempre Viva", Number = 123, City = "Springfield, USA" });
            return direcciones.OrderBy(o => o.Street);
        }

        public Address GetOne(Guid id)
        {
            return direcciones.Where(o => o.IdAddress == id).FirstOrDefault();
        }

        public void Insert(Address obj)
        {
            direcciones.Add(obj);
        }

        public void Update(Address obj)
        {
            throw new NotImplementedException();
        }
    }
}
