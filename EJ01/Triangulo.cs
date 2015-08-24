using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
	class Triangulo
	{

		public Punto Punto1 { get; private set; }
		public Punto Punto2 { get; private set; }
		public Punto Punto3 { get; private set; }
		public double Area
		{
			get { return CalcularArea(); }
		}
		public double Perimetro
		{
			get { return CalcularPerimetro(); }
		}

		public Triangulo (Punto pPunto1, Punto pPunto2, Punto pPunto3)
		{
			Punto1 = pPunto1;
			Punto2 = pPunto2;
			Punto3 = pPunto3;
		}


		private double CalcularArea()
		{
			double lado1 = Punto1.CalcularDistanciaDesde(Punto2);
			double lado2 = Punto2.CalcularDistanciaDesde(Punto3);
			double lado3 = Punto3.CalcularDistanciaDesde(Punto1);
			double perimetro = Perimetro;

			return (Math.Sqrt(perimetro * (perimetro - lado1) * (perimetro - lado2) * (perimetro - lado3)));
		}

		private double CalcularPerimetro ()
		{
			return Punto1.CalcularDistanciaDesde(Punto2) + Punto2.CalcularDistanciaDesde(Punto3) + Punto3.CalcularDistanciaDesde(Punto1);
		}
	}
}
