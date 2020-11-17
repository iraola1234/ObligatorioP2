using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string Cedula { get; set; }
        public string Rol { get; set; }

        public Usuario() { }
        public Usuario(string nombre, string apellido, string contraseña,string ci,string rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
            Cedula = ci;
            Rol = rol;
        }

        
    }
}