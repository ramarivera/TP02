using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class Punto
    {
		private double iX;
		private double iY;

		public Punto (double pX, double pY)
		{
			this.iX = pX;
			this.iY = pY;
		}

		public double X
		{
			get { return this.iX; }
            private set { this.iX = value; }
		}

		public double Y
		{
			get { return this.iY; }
            private set { this.iY = value; }
		}

		public double CalcularDistanciaDesde (Punto pPunto)
		{
			double disX, disY;
			disX = (this.X - pPunto.X);
			disY = (this.Y - pPunto.Y);
			return Math.Sqrt(Math.Pow(disX,2)+Math.Pow(disY,2));
		}

	}
}
