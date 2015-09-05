using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
	/// <summary>
	/// Clase Solucion del Ejercicio 01 del Trabajo Practico 02
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
            double x, y;
            cFachada = new Facade();
            bool seguir = true;
            while (seguir)
            {
				SeparadorMenuPrincipal();
                Console.WriteLine("¿Con que figura desea trabajar?");
                Console.WriteLine("1:\t Triangulo");
                Console.WriteLine("2:\t Circulo");
                Console.WriteLine("0:\t Salir");
                Console.Write("Opcion elegida: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
						SeparadorOperatoria();
                        Console.WriteLine("Ingrese las coordenadas del primer punto");
                        Console.Write("\t Coordenada en X: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("\t Coordenada en Y: ");
                        y = double.Parse(Console.ReadLine());
                        Punto punto1 = cFachada.CrearPunto(x, y);

                        Console.WriteLine("Ingrese las coordenadas del segundo punto");
                        Console.Write("\t Coordenada en X: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("\t Coordenada en Y: ");
                        y = double.Parse(Console.ReadLine());
                        Punto punto2 = cFachada.CrearPunto(x, y);

                        Console.WriteLine("Ingrese las coordenadas del tercer punto");
                        Console.Write("\t Coordenada en X: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("\t Coordenada en Y: ");
                        y = double.Parse(Console.ReadLine());
                        Punto punto3 = cFachada.CrearPunto(x, y);

                        Triangulo triangulo = cFachada.CrearTriangulo(punto1, punto2, punto3);
                        Console.WriteLine("El perimetro del triangulo es {0}", cFachada.CalcularPerimetroTriangulo(triangulo));
                        Console.Write("El area del triangulo es {0}", cFachada.CalcularAreaTriguanlo(triangulo));
						Console.ReadKey();
						Console.WriteLine();
						break;
                    case 2:
						SeparadorOperatoria();
						Console.WriteLine("Ingrese las coordenadas del centro");
                        Console.Write("\t Coordenada en X: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("\t Coordenada en Y: ");
                        y = double.Parse(Console.ReadLine());
                        Punto centro = cFachada.CrearPunto(x, y);
                        Console.Write("Ingrese el radio: ");
                        double radio = double.Parse(Console.ReadLine());
                        Circulo circulo = cFachada.CrearCirculo(centro, radio);
                        Console.WriteLine("El perimetro del circulo es {0}", cFachada.CalcularPerimetroCirculo(circulo));
                        Console.Write("El area del circulo es {0}", cFachada.CalcularAreaCirculo(circulo));
						Console.ReadKey();
						Console.WriteLine();
						break;
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