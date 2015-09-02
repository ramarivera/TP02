using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            Facade fachada = new Facade();
            bool seguir = true;
            while (seguir)
            {
                Console.WriteLine("¿Con que figura desea trabajar?");
                Console.WriteLine("1:\t Triangulo");
                Console.WriteLine("2:\t Circulo");
                Console.WriteLine("0:\t Salir");
                Console.Write("Opcion elegida: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Ingrese las coordenadas del primer punto");
                        Console.Write("\t Coordenada en X: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("\t Coordenada en Y: ");
                        y = double.Parse(Console.ReadLine());
                        Punto punto1 = fachada.CrearPunto(x, y);

                        Console.WriteLine("Ingrese las coordenadas del segundo punto");
                        Console.Write("\t Coordenada en X: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("\t Coordenada en Y: ");
                        y = double.Parse(Console.ReadLine());
                        Punto punto2 = fachada.CrearPunto(x, y);

                        Console.WriteLine("Ingrese las coordenadas del tercer punto");
                        Console.Write("\t Coordenada en X: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("\t Coordenada en Y: ");
                        y = double.Parse(Console.ReadLine());
                        Punto punto3 = fachada.CrearPunto(x, y);

                        Triangulo triangulo = fachada.CrearTriangulo(punto1, punto2, punto3);
                        Console.WriteLine("El perimetro del triangulo es {0}", fachada.CalcularPerimetroTriangulo(triangulo));
                        Console.Write("El area del triangulo es {0}", fachada.CalcularAreaTriguanlo(triangulo));
                        break;
                    case 2:
                        Console.WriteLine("Ingrese las coordenadas del centro");
                        Console.Write("\t Coordenada en X: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("\t Coordenada en Y: ");
                        y = double.Parse(Console.ReadLine());
                        Punto centro = fachada.CrearPunto(x, y);
                        Console.Write("Ingrese el radio: ");
                        double radio = double.Parse(Console.ReadLine());
                        Circulo circulo = fachada.CrearCirculo(centro, radio);
                        Console.WriteLine("El perimetro del circulo es {0}", fachada.CalcularPerimetroCirculo(circulo));
                        Console.Write("El area del circulo es {0}", fachada.CalcularAreaCirculo(circulo));
                        break;
                    case 0:
                        seguir = false;
                        break;
                    default:
                        Console.Write("Opcion incorrecta. Reintente\n");
                        break;
                }
                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}