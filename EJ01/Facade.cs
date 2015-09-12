using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
	/// <summary>
	/// Clase Fachada del ejercicio01, abstrae implementaciones de las clases Triangulo, Punto y Circulo
	/// </summary>
	class Facade
	{
		/// <summary>
		/// Permite obtener una nueva instancia de la clase Circulo
		/// </summary>
		/// <param name="pCentro">Centro del Circulo</param>
		/// <param name="pRadio">Radio del Circulo</param>
		/// <returns>Una nueva instancia de Circulo</returns>
        public Circulo CrearCirculo(Punto pCentro, double pRadio)
        {
            Circulo circulo = new Circulo(pCentro,pRadio);
            return circulo;
        }
		/// <summary>
		/// Permite obtener una nueva instancia de la clase Triangulo
		/// </summary>
		/// <param name="pPunto1">Punto 1 del triangulo</param>
		/// <param name="pPunto2">Punto 2 del triangulo</param>
		/// <param name="pPunto3">Punto 3 del triangulo</param>
		/// <returns>Una nueva instancia de Triangulo</returns>
		public Triangulo CrearTriangulo(Punto pPunto1, Punto pPunto2, Punto pPunto3)
        {
            Triangulo triangulo = new Triangulo(pPunto1, pPunto2, pPunto3);
            return triangulo;
        }
		/// <summary>
		/// Permite obtener una nueva instancia de la clase Punto
		/// </summary>
		/// <param name="pX">Coordenada X del punto</param>
		/// <param name="pY">Coordenada Y del punto</param>
		/// <returns>Una nueva instancia de Punto</returns>
		public Punto CrearPunto(double pX,double pY)
        {
            Punto punto = new Punto(pX, pY);
            return punto;
        }
		/// <summary>
		/// Obtiene el perimetro de un triangulo
		/// </summary>
		/// <param name="pTriangulo">Triangulo para el cual se desea conocer su perimetro</param>
		/// <returns>Perimetro del Triangulo</returns>
        public double CalcularPerimetroTriangulo(Triangulo pTriangulo)
        {
            return pTriangulo.Perimetro;
        }
		/// <summary>
		/// Obtiene el area de un triangulo
		/// </summary>
		/// <param name="pTriangulo">Triangulo para el cual se desea conocer su area</param>
		/// <returns>Area del Triangulo</returns>
		public double CalcularAreaTriangulo(Triangulo pTriangulo)
        {
            return pTriangulo.Area;
        }
		/// <summary>
		/// Obtiene el perimetro de un circulo
		/// </summary>
		/// <param name="pCirculo">Circulo para el cual se desea conocer su perimetro</param>
		/// <returns>Perimetro del Circulo</returns>
		public double CalcularPerimetroCirculo(Circulo pCirculo)
        {
            return pCirculo.Perimetro;
        }
		/// <summary>
		/// Obtiene el area de un Circulo
		/// </summary>
		/// <param name="pCirculo">Circulo para el cual se desea conocer su area</param>
		/// <returns>Area del Circulo</returns>
		public double CalcularAreaCirculo(Circulo pCirculo)
        {
            return pCirculo.Area;
        }
	}
}
