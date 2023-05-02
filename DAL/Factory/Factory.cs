using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Factory
{
    
    public sealed class Factory
    {
        private readonly static Factory _instance = new Factory();

        private string backend;

        public static Factory Current
        {
            get
            {
                return _instance;
            }
        }

        private Factory()
        {
            //Implent here the initialization of your singleton
            backend = ConfigurationManager.AppSettings["backend"];
        }

        public IGenericRepository<Address> GetAddressRepository()
        {
            if (backend == "SQL")
            {
                return new Repositories.SQL.AddressRepository();
            }
            else
            {
                return new Repositories.Memory.AddressRepository();
            }
        }

    }


}
