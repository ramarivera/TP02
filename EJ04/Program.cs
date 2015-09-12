using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
     /// <summary>
    /// Clase Solucion del Ejercicio 04 del Trabajo Practico 02
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
            Biblioteca biblioteca = new Biblioteca();
            cFachada = new Facade();
            string titulo, autor, editorial;
            int año, opcion;
            Libro libro = null;

            bool seguir = true;
            while (seguir)
            {
                SeparadorMenuPrincipal();
                Console.WriteLine("¿Que operacion desea realizar?");
                Console.WriteLine("1:\t Cargar un libro");
                Console.WriteLine("2:\t Agregar un libro a la biblioteca");
                Console.WriteLine("3:\t Quitar un libro de la biblioteca");
                Console.WriteLine("4:\t Mostrar la informacion de un libro");
                Console.WriteLine("5:\t Prestar un libro");
                Console.WriteLine("6:\t Devolver un libro");
                Console.WriteLine("0:\t Salir");
                Console.Write("Opcion elegida: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            if (libro == null)
                            {
                                SeparadorOperatoria();
                                Console.WriteLine("Ingrese los datos del libro");
                                Console.Write("\t Titulo: ");
                                titulo = Console.ReadLine();
                                Console.Write("\t Autor: ");
                                autor = Console.ReadLine();
                                Console.Write("\t Editorial: ");
                                editorial = Console.ReadLine();
                                Console.Write("\t Año: ");
                                año = int.Parse(Console.ReadLine());
                                libro = cFachada.CargarLibro(titulo, autor, editorial, año);
                                Console.WriteLine("El libro se ha cargado correctamente");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Existe actualmente un libro cargado");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            
                            break;
                        }
                    case 2:
                        {
                            if (libro == null)
                            {
                                Console.WriteLine("Cargue un libro para poder agregarlo a la biblioteca");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            else
                            {
                                bool cargado = cFachada.AgregarABiblioteca(libro, biblioteca);
                                if (cargado)
                                {
                                    libro = null;
                                    Console.WriteLine("Libro agregado a la bilioteca correctamente");
                                }
                                else
                                {
                                    Console.WriteLine("La biblioteca esta llena");
                                }
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            break;
                        }
                    case 3:
                        {
                            SeparadorOperatoria();
                            Console.Write("Ingrese el titulo del libro a borrar ");
                            titulo = Console.ReadLine();
                            bool borrado = cFachada.QuitarDeBiblioteca(titulo, biblioteca);
                            if (borrado)
                            {
                                Console.WriteLine("Libro borrado correctamente");
                             
                            }
                            else
                            {
                                Console.WriteLine("No se encontro el libro");
                               
                            }
                            Console.ReadKey();
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            SeparadorOperatoria();
                            Console.Write("Ingrese el titulo del libro ");
                            titulo = Console.ReadLine();
                            libro = cFachada.InformacionDeLibro(titulo,biblioteca);
                            if (libro == null)
                            {
                                Console.WriteLine("No se encontro el libro");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Informacion del libro");
                                Console.WriteLine("\t Titulo: {0}",libro.Titulo);
                                Console.WriteLine("\t Autor: {0}",libro.Autor);
                                Console.WriteLine("\t Editorial: {0}",libro.Editorial);
                                Console.WriteLine("\t Año: {0}",libro.Año);
                                Console.WriteLine("\t Prestado: {0}", libro.Prestado ? "Si" : "No");
                                libro = null;
                            }
                            Console.ReadKey();
                            Console.WriteLine();
                            break;
                        }
                    case 5:
                        {
                            SeparadorOperatoria();
                            Console.Write("Ingrese el titulo del libro a prestar ");
                            titulo = Console.ReadLine();
                            opcion = cFachada.PrestamoDeLibro(titulo,biblioteca);
                            switch (opcion)
                            {
                                case 0:
                                    {
                                        Console.WriteLine("No se encontro el libro");
                                        break;
                                    }
                                case -1:
                                    {
                                        Console.WriteLine("El libro ya se encuentra prestado");
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.WriteLine("Libro prestado correctamente");
                                        break;
                                    }
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            SeparadorOperatoria();
                            Console.Write("Ingrese el titulo del libro a devolver ");
                            titulo = Console.ReadLine();
                            opcion = cFachada.DevolucionDeLibro(titulo, biblioteca);
                            switch (opcion)
                            {
                                case 0:
                                    {
                                        Console.WriteLine("No se encontro el libro");
                                        break;
                                    }
                                case -1:
                                    {
                                        Console.WriteLine("El libro no se encuentra prestado");
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.WriteLine("Libro devuelto correctamente");
                                        break;
                                    }
                            }
                            Console.ReadKey();
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
