using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Models
{
    public class Internacional:Excursion

    {
        public CompaniaAerea CompAerea { get; set; }

        public Internacional(CompaniaAerea compAerea, string descripcion, int cantDiasTraslado, DateTime fechaComienzo, int disponibilidad)
        {
            CompAerea = compAerea;
            Id = ultimoId;
            ultimoId = ultimoId + 100;
            Descripcion = descripcion;
            CantDiasTraslado = cantDiasTraslado;
            FechaComienzo = fechaComienzo;
            Disponibilidad = disponibilidad;
        }

        public Internacional() { }

        public override string ToString()
        {
            return base.ToString() + "\nCompania aerea: " + CompAerea.ToString();
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
                if (destino.Pais != "Uruguay")
                {
                    getDestinos().Add(destino);
                }
            }
        }
    }
}