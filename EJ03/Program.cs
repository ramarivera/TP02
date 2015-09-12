using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Clase Solucion del Ejercicio 03 del Trabajo Practico 02
    /// </summary>
    class Program
    {
        /// <summary>
        /// Miembro estatico Facade, utilizado para abstraer implementaciones de las clases particulares al ejercicio
        /// </summary>
        static Facade cFachada;

        /// <summary>
        /// Muestra la Pantalla de Despedida del programa
        /// </summary>
        static void GoodBye()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                    Thank you for trusting MARR Systems Inc.  ");
            Console.ReadKey();
        }
        /// <summary>
        /// Muestra una cadena de caracteres, utilizado como separador en los menues principales por consola
        /// </summary>
        static void SeparadorMenuPrincipal()
        {
            Console.WriteLine("\n************************** Menu Principal *************************\n");
        }

        /// <summary>
        /// Muestra una cadena de caracteres, utilizado como separador en los menues secundarios por consola
        /// </summary>
        static void SeparadorOperatoria()
        {
            Console.WriteLine("\n-------------------Operando------------------\n");
        }
        static void Main(string[] args)
        {
            Garage garage= new Garage();
            cFachada = new Facade();
            string marca, modelo, descripcion;
            int cv;
            double precio;
            Auto auto;
           
            bool seguir = true;
            while (seguir)
            {
                SeparadorMenuPrincipal();
                Console.WriteLine("¿Que operacion desea realizar?");
                Console.WriteLine("1:\t Agregar auto");
                Console.WriteLine("2:\t Agregar averia");
                Console.WriteLine("3:\t Finalizar reparacion");
                Console.WriteLine("0:\t Salir");
                Console.Write("Opcion elegida: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            if (garage.NoHayAuto())
                            {
                                SeparadorOperatoria();
                                Console.WriteLine("Ingrese los datos del auto");
                                Console.Write("\t Marca: ");
                                marca = Console.ReadLine();
                                Console.Write("\t Modelo: ");
                                modelo = Console.ReadLine();
                                Console.Write("\t Cv: ");
                                cv = (int.Parse(Console.ReadLine()));
                                garage.AceptarAuto(cFachada.CrearAuto(marca, modelo, cv));
                                Console.WriteLine("Auto ingresado correctamente");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Ya esta trabajando con un auto. Finalice el anterior para continuar");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            break;
                        }
                    case 2:
                        {
                            if (garage.NoHayAuto())
                            {
                                Console.WriteLine("No hay ningun auto en el garage. Ingrese uno");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            else
                            {
                                SeparadorOperatoria();
                                Console.WriteLine("Ingrese la informacion de la averia");
                                Console.Write("\t Precio: ");
                                precio = (double.Parse(Console.ReadLine()));
                                Console.Write("\t Descripcion: ");
                                descripcion = Console.ReadLine();
                                cFachada.AgregarAveria(garage,precio,descripcion);
                                Console.WriteLine("Averia ingresada correctamente");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                        break;
                        }
                    case 3:
                        {
                           if (garage.NoHayAuto())
                            {
                                Console.WriteLine("No hay ningun auto en el garage. Ingrese uno");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                           else
                           {
                               SeparadorOperatoria();
                               auto = cFachada.MostrarAuto(garage);
                               Console.WriteLine("Marca: {0}",auto.Marca);
                               Console.WriteLine("Modelo: {0}",auto.Modelo);
                               Console.WriteLine("Litros de aceite: {0}",auto.Motor.LitrosAceite);
                               Console.WriteLine("Cv: {0}",auto.Motor.CV);
                               Console.WriteLine("Total reparacion: ${0}", auto.PrecioAverias);
                               garage.QuitarAuto(auto);
                               Console.ReadKey();
                               Console.WriteLine();
                           }
                           break;
                        }
                    case 0:
                        seguir = false;
                        break;
                    default:
                        Console.Write("Opcion incorrecta. Reintente\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
            GoodBye();
        }
    }
}
