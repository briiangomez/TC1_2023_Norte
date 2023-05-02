using DAL.Contracts;
using DAL.Factory;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SL.Services.Extension;
using System.Threading;
using System.Globalization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Thread.CurrentThread.CurrentUICulture.DisplayName);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            string word = "Bienvenidos".Traducir();

            Console.WriteLine(word);

            foreach (var item in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                Console.WriteLine($"Nombre: {item.Name}: DisplayName: {item.DisplayName}");
            }

            ///28/04 - FACTORY & SINGLETON & REPOSITORY
            ///
            IGenericRepository<Address> repositoryAddress = Factory.Current.GetAddressRepository();

            ///NUEVO REGISTRO EN SQL
            ///
            Address direccionDaVinci = new Address() { IdAddress = Guid.NewGuid(), Street = "Bernardo de Irigoyen", Number = 969, City = "Boulogne, Bs As" };

            repositoryAddress.Insert(direccionDaVinci);

            Address direccionNueva = repositoryAddress.GetOne(direccionDaVinci.IdAddress);

            Console.WriteLine(direccionNueva.ToString());

            List<Address> direcciones = repositoryAddress.GetAll().ToList();

            foreach (var item in direcciones)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();

            ///INSERT EN SQL
            ///

        }
    }
}
