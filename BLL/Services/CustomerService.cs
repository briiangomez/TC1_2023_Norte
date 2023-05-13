using BLL.BusinessExceptions;
using BLL.Contracts;
using DAL.Factory;
using Domain;
using SL.Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public sealed class CustomerService : IGenericBusinessService<Customer>
    {
        private readonly static CustomerService _instance = new CustomerService();

        public static CustomerService Current
        {
            get
            {
                return _instance;
            }
        }

        private CustomerService()
        {
            //Implent here the initialization of your singleton
        }

        public void Insert(Customer obj)
        {
            //Validaciones de Negocio

            //Para poder dar de alta un cliente, tiene que ser mayor de edad

            //Valido si es mayor de edad

            try
            {
                if(obj.DateBirth > DateTime.Now.AddYears(-18))
                {
                    throw new ClienteMenorEdadException();
                }

                Factory.Current.GetCustomerRepository().Insert(obj);
            }
            catch(ClienteMenorEdadException ex)
            {
                ex.Handle(this);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }

        public Customer GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
