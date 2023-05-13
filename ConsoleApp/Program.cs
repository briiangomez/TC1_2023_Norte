using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SL.Services.Extension;
using System.Threading;
using System.Globalization;
using SL.DAL.Composite;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Customer customer = new Customer()
                {
                    Doc = "332121515",
                    DateBirth = DateTime.Now.AddYears(-20),
                    FirstName = "Lautaro",
                    LastName = "Gomez",
                    IdCustomer = Guid.NewGuid()

                };

                BLL.Services.CustomerService.Current.Insert(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();

            ///USUARIO-PATENTE-FAMILIA
            ///

            /*Patente patente = new Patente() { formName = "frmGestionVentas", Name = "Gestión de ventas" };
            Patente patente2 = new Patente() { formName = "frmGestionCompras", Name = "Gestión de compras" };
            Patente patente3 = new Patente() { formName = "frmReportesGenerales", Name = "Reportes general" };
            Patente patente4 = new Patente() { formName = "frmPerfilUsuario", Name = "Perfil" };
            Patente patente5 = new Patente() { formName = "frmPrincipal", Name = "Principal" };

            Familia familiaGestionVentas = new Familia("Rol Gestión Ventas", patente);
            Familia familiaGestionCompras = new Familia("Rol Gestión Compras", patente2);
            familiaGestionCompras.Add(patente3);

            Familia administrador = new Familia("Rol Administrador", familiaGestionVentas);
            //administrador.Add(familiaGestionCompras);
            administrador.Add(patente4);
            administrador.Add(patente5);

            Usuario usuario = new Usuario();
            usuario.Permisos.Add(administrador);
            usuario.Permisos.Add(patente5);

            Console.WriteLine("Listado de permisos de mi usuario:");

            List<Patente> patentesUser = usuario.GetPatentesAll();

            foreach (var item in patentesUser)
            {
                Console.WriteLine($"Patente: {item.formName}");
            }

            Console.ReadKey();

            //Console.WriteLine(Thread.CurrentThread.CurrentUICulture.DisplayName);

            /*Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

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
            ///*/

        }
    }
}
