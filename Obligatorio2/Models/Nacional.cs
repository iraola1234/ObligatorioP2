using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Models
{
    public class Nacional:Excursion
    {
        public bool EsInteres { get; set; }

        public Nacional(bool esInteres, string descripcion, int cantDiasTraslado, DateTime fechaComienzo, int disponibilidad)
        {
            EsInteres = esInteres;
            Id = ultimoId;
            ultimoId = ultimoId + 100;
            Descripcion = descripcion;
            CantDiasTraslado = cantDiasTraslado;
            FechaComienzo = fechaComienzo;
            Disponibilidad = disponibilidad;
        }

        public Nacional() { }

        public override string ToString()
        {
            string interes = "NO";
            if (EsInteres)
            {
                interes = "SI";
            }
            return base.ToString() + "\nInteres: " + interes;
        }

        //Se agrega destino a una excursión utilizando el polimorfismo y verificando que la excursion no tenga ese destino
        public override void agregarDestino(Destino destino)
        {
            bool resultado = false;
            foreach (Destino d in getDestinos())
            {
                if (destino.Pais.Equals(d.Pais) && destino.Ciudad.Equals(d.Ciudad))
                {
                    resultado = true;
                }
            }
            if (!resultado)
            {
                if (destino.Pais == "Uruguay")
                {
                    getDestinos().Add(destino);
                }
            }
        }
    }
}