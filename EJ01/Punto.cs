using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
	/// <summary>
	/// Representa un punto en el espacio de R2
	/// </summary>
    class Punto
    {
		/// <summary>
		/// Coordenada X del punto
		/// </summary>
		private double iX;
		/// <summary>
		/// Coordenada Y del punto
		/// </summary>
		private double iY;
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="pX">Coordenada X del punto</param>
		/// <param name="pY">Coordenada Y del punto</param>
		public Punto (double pX, double pY)
		{
			this.iX = pX;
			this.iY = pY;
		}
		/// <summary>
		/// Propiedad Coordenada X, solo lectura
		/// </summary>
		public double X
		{
			get { return this.iX; }
            private set { this.iX = value; }
		}
		/// <summary>
		/// Propiedad Coordenada Y, solo lectura
		/// </summary>
		public double Y
		{
			get { return this.iY; }
            private set { this.iY = value; }
		}
		/// <summary>
		/// Permite calcular la distancia entre el punto y otro punto
		/// </summary>
		/// <param name="pPunto">Punto hasta el cual se desea calcular la distancia</param>
		/// <returns>Double, representa la distancia entra ambos puntos</returns>
		public double CalcularDistanciaDesde (Punto pPunto)
		{
			double disX, disY;
			disX = (this.X - pPunto.X);
			disY = (this.Y - pPunto.Y);
			return Math.Sqrt(Math.Pow(disX,2)+Math.Pow(disY,2));
		}

	}
}
