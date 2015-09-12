using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ06
{
	class Program
	{
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

		static Fecha CargarFecha()
		{
			int dia, mes, anio;
			Console.Write("\t Dia: ");
			dia = int.Parse(Console.ReadLine());
			Console.Write("\t Mes: ");
			mes = int.Parse(Console.ReadLine());
			Console.Write("\t Año: ");
			anio = int.Parse(Console.ReadLine());
			return new Fecha(dia, mes, anio);
		}

	
		static void Main(string[] args)
		{
			Fecha lFecha1, lFecha2;
            SeparadorMenuPrincipal();
			Console.WriteLine("Ingrese la fecha inicial");
			lFecha1 = CargarFecha();
            bool seguir = true;
			while (seguir)
			{
				int aux = 0;
				SeparadorOperatoria();
				Console.WriteLine("Ingrese la Operacion que desea realizar");
				Console.WriteLine("1:\t Mostrar Fecha");
				Console.WriteLine("2:\t Agregar Dias");
				Console.WriteLine("3:\t Agregar Meses");
				Console.WriteLine("4:\t Agregar Años");
				Console.WriteLine("5:\t Comparar con");
				Console.WriteLine("6:\t Restar con");
				Console.WriteLine("0:\t Salir");
				Console.Write("Opcion elegida: ");
				switch (int.Parse(Console.ReadLine()))
				{
					case 1:
						Console.WriteLine("La cadena que representa a la fecha es: {0}",lFecha1.ToString());
						Console.WriteLine("El dia es {0} y el mes es {1}",lFecha1.DiaSemanaActual,lFecha1.NombreMesActual);
						Console.ReadKey();
						Console.WriteLine();
						break;
					case 2:
						Console.Write("Ingrese la cantidad de dias que desea agregar: ");
						aux = int.Parse(Console.ReadLine());
						lFecha1 = lFecha1.AgregarDias(aux);
						Console.WriteLine();
						break;
					case 3:
						Console.Write("Ingrese la cantidad de meses que desea agregar: ");
						aux = int.Parse(Console.ReadLine());
						lFecha1 = lFecha1.AgregarMeses(aux);
						Console.WriteLine();
						break;
					case 4:
						Console.Write("Ingrese la cantidad de anios que desea agregar: ");
						aux = int.Parse(Console.ReadLine());
						lFecha1 = lFecha1.AgregarAño(aux);
						Console.WriteLine();
						break;
					case 5:
						lFecha2 = CargarFecha();
						if (lFecha2 == lFecha1)
						{
							Console.WriteLine("Las fechas son Iguales");
						}
						else
						{
							Console.WriteLine("Las fechas son distintas");
						}
						if (lFecha1>lFecha2)
						{
							Console.WriteLine("Fecha01 es mayor que Fecha02");
						}
						else
						{
							if (lFecha1!=lFecha2 && lFecha1<lFecha2)
							{
								Console.WriteLine("Fecha 02 es mayor que Fecha01");
							}
						}
						Console.ReadKey();
						Console.WriteLine();
						break;
					case 6:
						lFecha2 = CargarFecha();
						Console.WriteLine("La diferencia entre ambas es {0}",lFecha1-lFecha2);
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

