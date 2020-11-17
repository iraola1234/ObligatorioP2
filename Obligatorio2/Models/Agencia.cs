using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Models
{
    public class Agencia
    {
        private Agencia()
        {
          precargaDatos();   
        }

        //Singleton
        private static Agencia instancia = null;
        public static Agencia getInstancia()
        {
            if (instancia == null)
            {
                instancia = new Agencia();
            }
            return instancia;
        }

        
        private List<Destino> destinos = new List<Destino>();
        private List<Excursion> excursiones = new List<Excursion>();
        private List<Usuario> usuarios = new List<Usuario>();


        public double Cotizacion { get; set; }


        public void modificarCotizacion(double nuevoValor)
        {
            Cotizacion = nuevoValor;
        }

        //Metodo el cual agrega un Destino a la lista de destinos, validando la entrada como nombre de ciudad, pais y que la cantida de dias y costos sean positivos.
        public Destino nuevoDestino(string ciudad, string pais, int cantDias, int costoDiario)
        {
            if (ciudad.Length > 2)
            {
                if (pais.Length > 2)
                {
                    for (int pos = 0; pos < destinos.Count; pos++)
                    {
                        if (pais.Equals(destinos[pos].Pais) && ciudad.Equals(destinos[pos].Ciudad))
                        {
                            return null;
                        }
                    }
                    if (costoDiario > 0 && cantDias > 0)
                    {
                        Destino destino = new Destino(ciudad, pais, cantDias, costoDiario);
                        destinos.Add(destino);
                        return destino;
                    }
                }
            }
            return null;
        }

        //Se busca y retorna lista Destinos
        public List<Destino> getDestinos()
        {
            return destinos;
        }

        //Se busca y retorna lista de excursiones
        public List<Excursion> getExcursiones()
        {
            return excursiones;
        }

        //Metodo que agrega Excursion tipo Nacional a lista de Excursiones
        private Nacional agregarNacional(bool esInteres, string descripcion, int cantDiasTraslado, DateTime fechaComienzo, int disponibilidad)
        {
            Nacional nacional = new Nacional(esInteres, descripcion, cantDiasTraslado, fechaComienzo, disponibilidad);
            excursiones.Add(nacional);
            return nacional;
        }

        //Metodo que agrega Excursion tipo Internacional a lista de Excursiones
        private Internacional agregarInternacional(CompaniaAerea compAerea, string descripcion, int cantDiasTraslado, DateTime fechaComienzo, int disponibilidad)
        {
            Internacional internacional = new Internacional(compAerea, descripcion, cantDiasTraslado, fechaComienzo, disponibilidad);
            excursiones.Add(internacional);
            return internacional;
        }

        //Metodo que toma una ciudad, fecha en la cual se quiere ir y volver, retornando una lista con las excursiones que tienen esa ciudad entre esas fechas.
        public List<Excursion> mostrarExcursionesEnDestino(string ciudadElegida, DateTime fechaInicio, DateTime fechaFinal, string paisElegido)
        {
            List<Excursion> excursionesDadas = new List<Excursion>();
            foreach (Excursion e in getExcursiones())
            {
                foreach (Destino d in e.getDestinos())
                {
                    if (d.Ciudad == ciudadElegida && d.Pais == paisElegido)
                    {
                        if (fechaInicio <= e.FechaComienzo && fechaFinal > e.FechaComienzo)
                        {
                            excursionesDadas.Add(e);
                        }
                    }
                }
            }
            return excursionesDadas;
        }

        private bool verificarContraseña(string contraseña)
        {
            bool retorno = false;
            int may = 0, min = 0, dig = 0;
            if (contraseña.Length >= 6)
            {
                for (int i = 0; i <= contraseña.Length; i++)
                {
                    if (Char.IsUpper(contraseña[i]))
                    {
                        may += 1;
                    }
                    else if (Char.IsLower(contraseña[i]))
                    {
                        min += 1;
                    }
                    else if (Char.IsDigit(contraseña[i]))
                    {
                        dig += 1;
                    }
                }
                if (may >= 1 && min >= 1 && dig >= 1)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        private bool verificarCedula(string cedula)
        {
            bool retorno = true;
            if (cedula.Length >= 7 && cedula.Length <= 9)
            {
                foreach (char c in cedula)
                {
                    if (!Char.IsDigit(c))
                    {
                        retorno = false;
                    }
                }
            }
            return retorno;
        }
        private bool verificarNombre(string nombre)
        {
            bool retorno = false;
            if (nombre.Length >= 2)
            {
                retorno = true;
            }
            return retorno;
        }
        private bool verificarApellido(string apellido)
        {
            bool retorno = false;
            if (apellido.Length >= 2)
            {
                retorno = true;
            }
            return retorno;
        }
        public Usuario nuevoCliente(string nombre, string apellido, string contraseña, string ci)
        {
            if(verificarNombre(nombre) && verificarApellido(apellido) && verificarCedula(ci) && verificarContraseña(contraseña))
            {
                Usuario usuarioCliente = new Usuario(nombre, apellido, contraseña, ci,"Cliente");
                usuarios.Add(usuarioCliente);
                return usuarioCliente;
            }
            else
            {
                return null;
            }
            
        }
        public List<Usuario> getUsuarios()
        {
            return usuarios;
        }
        private void precargaDatos()
        {
            CompaniaAerea Emirates = new CompaniaAerea("Emiratos arabes", "Emirates");
            CompaniaAerea Iberia = new CompaniaAerea("Espania", "Iberia");
            CompaniaAerea Lufthansa = new CompaniaAerea("Alemania", "Lufthansa");
            CompaniaAerea Latam = new CompaniaAerea("Latam", "Latam");

            Destino montevideo = nuevoDestino("Montevideo", "Uruguay", 4, 80);
            Destino colonia = nuevoDestino("Colonia", "Uruguay", 2, 100);
            Destino maldonado = nuevoDestino("Maldonado", "Uruguay", 3, 120);
            Destino paysandu = nuevoDestino("Paysandu", "Uruguay", 2, 80);
            Destino salto = nuevoDestino("Salto", "Uruguay", 3, 90);
            Destino rocha = nuevoDestino("Rocha", "Uruguay", 5, 40);
            Destino cusco = nuevoDestino("Cusco", "Peru", 7, 80);
            Destino lima = nuevoDestino("Lima", "Peru", 4, 100);
            Destino berlin = nuevoDestino("Berlin", "Alemania", 5, 70);
            Destino paris = nuevoDestino("Paris", "Francia", 3, 150);
            Destino dubai = nuevoDestino("Dubai", "Emiratos Arabes", 6, 200);
            Destino bangkok = nuevoDestino("Bangkok", "Tailandia", 5, 20);
            Destino hanoi = nuevoDestino("Hanoi", "Vietnam", 4, 35);
            Destino barcelona = nuevoDestino("Barcelona", "Espania", 5, 50);
            Destino madrid = nuevoDestino("Madrid", "Espania", 4, 90);

            Nacional n1 = agregarNacional(true, "Lorem ipsum", 1, DateTime.Parse("2021-06-15"), 20);
            Nacional n2 = agregarNacional(false, "Lorem ipsum", 1, DateTime.Parse("2021-01-01"), 10);
            Nacional n3 = agregarNacional(false, "Lorem ipsum", 2, DateTime.Parse("2021-10-25"), 15);
            Nacional n4 = agregarNacional(true, "Lorem ipsum", 2, DateTime.Parse("2020-12-20"), 6);

            Internacional i1 = agregarInternacional(Emirates, "Lorem ipsum", 4, DateTime.Parse("2021-08-10"), 12);
            Internacional i2 = agregarInternacional(Iberia, "Lorem ipsum", 2, DateTime.Parse("2021-06-10"), 10);
            Internacional i3 = agregarInternacional(Lufthansa, "Lorem ipsum", 2, DateTime.Parse("2020-11-01"), 20);
            Internacional i4 = agregarInternacional(Latam, "Lorem ipsum", 1, DateTime.Parse("2021-04-10"), 8);

            n1.agregarDestino(montevideo);
            n1.agregarDestino(colonia);
            n2.agregarDestino(montevideo);
            n2.agregarDestino(maldonado);
            n3.agregarDestino(salto);
            n3.agregarDestino(paysandu);
            n4.agregarDestino(maldonado);
            n4.agregarDestino(rocha);

            i1.agregarDestino(dubai);
            i1.agregarDestino(bangkok);
            i1.agregarDestino(hanoi);
            i2.agregarDestino(barcelona);
            i2.agregarDestino(madrid);
            i3.agregarDestino(madrid);
            i3.agregarDestino(paris);
            i3.agregarDestino(berlin);
            i4.agregarDestino(lima);
            i4.agregarDestino(cusco);

            Usuario o1 = new Usuario("Tomas", "Lanterna", "123456", "50205474", "Operador");
            Usuario o2 = new Usuario("Santiago", "Iraola", "123456", "42325685", "Operador");
            usuarios.Add(o1);
            usuarios.Add(o2);

        }
    }
}