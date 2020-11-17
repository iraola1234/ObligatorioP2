using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Models
{
    public class Destino
    {
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int CantDias { get; set; }
        public int CostoDiario { get; set; }

        public Destino(string ciudad, string pais, int cantDias, int costoDiario)
        {
            Ciudad = ciudad;
            Pais = pais;
            CantDias = cantDias;
            CostoDiario = costoDiario;
        }

        public Destino()
        {
        }

        public override string ToString()
        {
            return "\nPais: " + Pais + "\nCiudad: " + Ciudad + "\nCantDias: " + CantDias + "\nCosto Diario " + CostoDiario;
        }

        //Metodo encargado de calcular el costo del destino dependendiendo de la cantidad de dias.
        public int calcularCostoTotal()
        {
            int costoTotal = CantDias * CostoDiario;
            return costoTotal;
        }

        //Metodo encargado de retornar un string unicamente de los destinos que tiene para ofrecer la agencia.
        public string mostrarDestinoCompleto()
        {
            Agencia agencia = Agencia.getInstancia();
            double costoUSD = calcularCostoTotal();
            double costoUYU = calcularCostoTotal() * agencia.Cotizacion;
            return ToString() + "\nCosto total x persona (USD): " + costoUSD + "\nCosto total x persona (UYU): " + costoUYU;
        }
    }
}