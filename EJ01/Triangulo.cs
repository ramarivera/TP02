using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
	/// <summary>
	/// Representa un triangulo, permitiendo obtener su perimetro y area
	/// </summary>
	class Triangulo
	{
		/// <summary>
		/// Punto 01 del triangulo
		/// </summary>
		private Punto iPunto1;
		/// <summary>
		/// Punto 02 del triangulo
		/// </summary>
		private Punto iPunto2;
		/// <summary>
		/// Punto 03 del triangulo
		/// </summary>
		private Punto iPunto3;
		/// <summary>
		/// Propiedad Punto 01, solo lectura
		/// </summary>
        public Punto Punto1
        {
            get { return this.iPunto1; }
            private set { this.iPunto1 = value; }
        }
		/// <summary>
		/// Propiedad Punto 02, solo lectura
		/// </summary>
		public Punto Punto2
        {
            get { return this.iPunto2; }
            private set { this.iPunto2 = value; }
        }
		/// <summary>
		/// Propiedad Punto 03, solo lectura
		/// </summary>
		public Punto Punto3
        {
            get { return this.iPunto3; }
            private set { this.iPunto3 = value; }
        }
		/// <summary>
		/// Propiedad Area, Recupera el area del triangulo
		/// </summary>
		public double Area
		{
			get {
				double lado1 = Punto1.CalcularDistanciaDesde(Punto2);
				double lado2 = Punto2.CalcularDistanciaDesde(Punto3);
				double lado3 = Punto3.CalcularDistanciaDesde(Punto1);
				double perimetro = Perimetro;

				return (Math.Sqrt(perimetro * (perimetro - lado1) * (perimetro - lado2) * (perimetro - lado3)));
				}
		}
		/// <summary>
		/// Propiedad Perimetro, Recupera el perimetro del triangulo
		/// </summary>
		public double Perimetro
		{
			get { return Punto1.CalcularDistanciaDesde(Punto2) + Punto2.CalcularDistanciaDesde(Punto3) + Punto3.CalcularDistanciaDesde(Punto1); }
		}
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		/// <param name="pPunto1">Primer Punto</param>
		/// <param name="pPunto2">Segundo Punto</param>
		/// <param name="pPunto3">Tercer Punto</param>
		public Triangulo (Punto pPunto1, Punto pPunto2, Punto pPunto3)
		{
			iPunto1 = pPunto1;
			iPunto2 = pPunto2;
			iPunto3 = pPunto3;
		}
	}
}
