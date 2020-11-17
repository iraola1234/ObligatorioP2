using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Models
{
    public class CompaniaAerea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }

        public int ultimoId = 1;
        public CompaniaAerea(string pais, string nombre)
        {
            Id = ultimoId;
            ultimoId++;
            Pais = pais;
            Nombre = nombre;
        }

        public CompaniaAerea()
        {
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}