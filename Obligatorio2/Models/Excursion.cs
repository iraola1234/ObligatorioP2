using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Models
{
    public abstract class Excursion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CantDiasTraslado { get; set; }
        private List<Destino> destinos = new List<Destino>();
        public DateTime FechaComienzo { get; set; }
        public int Disponibilidad { get; set; }

        public static int ultimoId = 1000;

        public Excursion(string descripcion, int cantDiasTraslado, DateTime fechaComienzo, int disponibilidad)
        {
            Id = ultimoId;
            ultimoId = ultimoId + 100;
            Descripcion = descripcion;
            CantDiasTraslado = cantDiasTraslado;
            FechaComienzo = fechaComienzo;
            Disponibilidad = disponibilidad;
        }

        //Se busca y retorna lista de destinos dentro de una excursion
        public List<Destino> getDestinos()
        {
            return destinos;
        }

        //Se agrega destino a una excursión utilizando el polimorfismo
        public abstract void agregarDestino(Destino destino);


        public Excursion() { }

        //Metodo encargado de calcular el costo de una excursion en funcion a los dias de su destino.
        public int calcularCostoExcursion()
        {
            int costoTotal = 0;
            foreach (Destino d in getDestinos())
            {
                costoTotal += d.calcularCostoTotal();
            }
            return costoTotal;
        }

        public override string ToString()
        {
            string destinosString = "";
            foreach (Destino d in getDestinos())
            {
                destinosString += "\n" + d.Ciudad;
            }
            return "Id: " + Id + "\nDescripcion: " + Descripcion + "\nCantidad de dias de traslado: " + CantDiasTraslado
                + "\nDestinos: " + destinosString + "\nFecha Comienzo: " + FechaComienzo + "\nDisponibilidad: " + Disponibilidad;
        }
    }
}