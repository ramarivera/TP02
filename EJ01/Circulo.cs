using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class Circulo
    {
		private Punto iCentro;
		private double iRadio;


		public Punto Centro
		{
			get { return this.iCentro; }
		}
		public double Radio
		{
			get { return this.iRadio; }
		}

		public Circulo(Punto pCentro, double pRadio) : this(pCentro.X, pCentro.Y, pRadio) { }

		public Circulo(double pX, double pY, double pRadio)
		{
			this.iRadio = pRadio;
			this.iCentro = new Punto(pX, pY);
		}

		public double Area
		{
			get { return Math.PI * Math.Pow(Radio, 2); }
		}

		public double Perimetro
		{
			get { return Math.PI * 2 * Radio; }
		} 
	}
}
