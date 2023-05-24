using evaluacion2.Comunicacion;
using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mensajero
{
    public class Program
    {
        private static IMensajesDAL mensajesDAL = MensajesDALArchivos.GetInstancia();

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Selecciones una opcion");
            Console.WriteLine(" 1. Ingresar \n 2. Mostrar \n 0.Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Ingresar();
                    break;
                case "2":
                    Mostrar();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese de Nuevo");
                    break;
            }
            return continuar;
        }

        static void IniciarServidor()
        {


        }
        static void Main(string[] args)
        {

            HiloServidor hebra = new HiloServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.Start();

            while (Menu()) ;
        }

        static void Ingresar()
        {
            Console.WriteLine("Ingrese Numero de Medidor: ");
            string nmedidor = Console.ReadLine().Trim();
            Console.WriteLine("Fecha AA/MM/DD: ");
            string numero = Console.ReadLine().Trim();
            Console.WriteLine("Total Consumo: ");
            string precio = Console.ReadLine().Trim();
            Mensaje mensaje = new Mensaje()
            {
                Nmedidor = nmedidor,
                Fecha = numero,
                Valorcons = precio,
            };
            lock (mensajesDAL)
            {
                mensajesDAL.AgregarMensaje(mensaje);
            }


        }

        static void Mostrar()
        {
            List<Mensaje> mensajes = null;
            lock (mensajesDAL)
            {
                mensajes = mensajesDAL.ObtenerMensajes();
            }

            foreach (Mensaje mensaje in mensajes)
            {
                Console.WriteLine(mensaje);
            }

        }
    }
}

