using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
	class Triangulo
	{
		private Punto iPunto1;
		private Punto iPunto2;
		private Punto iPunto3;

		public Triangulo (Punto pPunto1, Punto pPunto2, Punto pPunto3)
		{
			this.iPunto1 = pPunto1;
			this.iPunto2 = pPunto2;
			this.iPunto3 = pPunto3;
		}

		public Punto Punto1
		{
			get { return this.iPunto1; }
		}
		public Punto Punto2
		{
			get { return this.iPunto2; }
		}
		public Punto Punto3
		{
			get { return this.iPunto3; }
		}

		public double Area
		{
			get
			{
				double lado1 = Punto1.CalcularDistanciaDesde(Punto2);
				double lado2 = Punto2.CalcularDistanciaDesde(Punto3);
				double lado3 = Punto3.CalcularDistanciaDesde(Punto1);
				double perimetro = Perimetro;

				return (Math.Sqrt(perimetro * (perimetro - lado1) * (perimetro - lado2) * (perimetro - lado3)));
			}
		}

		public double Perimetro
		{
			get { return Punto1.CalcularDistanciaDesde(Punto2) + Punto2.CalcularDistanciaDesde(Punto3) + Punto3.CalcularDistanciaDesde(Punto1); }
		}
	}
}
