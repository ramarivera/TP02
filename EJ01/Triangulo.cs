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

        public Punto Punto1
        {
            get { return this.iPunto1; }
            private set { this.iPunto1 = value; }
        }

        public Punto Punto2
        {
            get { return this.iPunto2; }
            private set { this.iPunto2 = value; }
        }

        public Punto Punto3
        {
            get { return this.iPunto3; }
            private set { this.iPunto3 = value; }
        }

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
			iPunto1 = pPunto1;
			iPunto2 = pPunto2;
			iPunto3 = pPunto3;
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
