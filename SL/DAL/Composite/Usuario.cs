using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.DAL.Composite
{
    public class Usuario
    {
        public string Nombre { get; set; }

        public string Password { get; set; }

        public List<Component> Permisos { get; set; }

        public Usuario()
        {
            Permisos = new List<Component>();   
        }

        public List<Patente> GetPatentesAll()
        {
            List<Patente> patentesD = new List<Patente>();

            RecorrerComposite(patentesD, Permisos, "-");

            return patentesD;

        }


        public static void RecorrerComposite(List<Patente> patentes, List<Component> components, string tab)
        {
            foreach (var item in components)
            {
                if (item.GetChild() == 0)
                {
                    Patente patente = item as Patente;
                    //Console.WriteLine($"{tab} Patente: {patente.Name}");
                    /*if (!patentes.Exists(o => o.Name == patente.Name))
                        patentes.Add(patente);*/

                    bool exists = false;

                    foreach (var pat in patentes)
                    {
                        if (patente.Name == pat.Name)
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        patentes.Add(patente);
                    }

                }
                else
                {
                    Familia familia = item as Familia;
                    //Console.WriteLine($"{tab} Familia: {familia.Name}");
                    RecorrerComposite(patentes, familia.GetChildrens(), tab);
                }
            }
        }
    }
}
