using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
	/// <summary>
	/// Representa un circulo, permitiendo obtener su area y perimetro
	/// </summary>
    class Circulo
    {
		/// <summary>
		/// Representa el punto central del circulo
		/// </summary>
		private Punto iCentro;
		/// <summary>
		/// Representa el radio del circulo, independiente de la unidad de medicion
		/// </summary>
		private double iRadio;

		/// <summary>
		/// Propiedad Centro, solo lectura
		/// </summary>
		public Punto Centro
		{
			get { return this.iCentro; }
            private set { this.iCentro = value; }
		}
		/// <summary>
		/// Propiedad Radio, solo lectura
		/// </summary>
		public double Radio
		{
			get { return this.iRadio; }
            private set { this.iRadio = value; }
		}
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="pCentro">Centro del circulo</param>
		/// <param name="pRadio">Radio del circulo</param>
		public Circulo(Punto pCentro, double pRadio)
		{
			Centro = pCentro;
			Radio = pRadio;
		}
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="pX">Coordenada X del Centro del Circulo</param>
		/// <param name="pY">Coordenada Y del Centro del Circulo</param>
		/// <param name="pRadio">Radio del circulo</param>
		public Circulo(double pX, double pY, double pRadio) : this(new Punto(pX, pY), pRadio) { }
		
		/// <summary>
		/// Recupera el area del circulo
		/// </summary>
		public double Area
		{
			get { return Math.PI * Math.Pow(Radio, 2); }
		}

		/// <summary>
		/// Recupera el perimetro del circulo (O la longitud de la circunferencia del mismo)
		/// </summary>
		public double Perimetro
		{
			get { return Math.PI * 2 * Radio; }
		} 
	}
}
