///////////////////////////////////////////////////////////
//  Familia.cs
//  Implementation of the Class Familia
//  Generated by Enterprise Architect
//  Created on:      05-may.-2023 20:18:37
//  Original author: Navegador
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace SL.DAL.Composite
{
	/// <summary>
	/// This class (a) defines behaviour for components having children, (b) stores
	/// child components, and (c) implements child-related operations in the Component
	/// interface.
	/// </summary>
	public class Familia : Component {


        private List<Component> childrens = new List<Component>();

        public string Name { get; set; }

        public Familia(string Nombre, Component component)
		{
			childrens.Add(component);
			Name = Nombre;

		}

		public List<Component> GetChildrens()
        {
			return childrens;
        }

		/// 
		/// <param name="component"></param>
		public override void Add(Component component){

            //Que no sea el null el componente
            //
            if (component != null)
            {
				childrens.Add(component);
			}

		}

        public override int GetChild()
        {
			return childrens.Count;

		}

        /// 
        /// <param name="component"></param>
        public override void Remove(Component component)
		{
			childrens.RemoveAll(o => o.IdComponent == component.IdComponent);
		}

	}//end Familia

}//end namespace Patrones