using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Clase Fachada del ejercicio01, abstrae los eventos del sistema
    /// </summary>
    class Facade
	{
        /// <summary>
        /// Obtiene el perimetro de un <see cref="Triangulo"/>
        /// </summary>
        /// <param name="pX1">Coordenada X del punto 1</param>
        /// <param name="pY1">Coordenada Y del Punto 1</param>
        /// <param name="pX2">Coordenada X del punto 2</param>
        /// <param name="pY2">Coordenada Y del Punto 2</param>
        /// <param name="pX3">Coordenada X del punto 3</param>
        /// <param name="pY3">Coordenada Y del Punto 3</param>
        /// <returns>Perimetro del Triangulo</returns>
        public double CalcularPerimetroTriangulo(double pX1, double pY1, double pX2, double pY2, double pX3, double pY3)
        {
            Punto lPunto1 = new Punto(pX1, pY1);
            Punto lPunto2 = new Punto(pX2, pY2);
            Punto lPunto3 = new Punto(pX3, pY3);
            Triangulo lTriangulo = new Triangulo(lPunto1, lPunto2, lPunto3);
            return lTriangulo.Perimetro;
        }

        /// <summary>
        /// Obtiene el area de un <see cref="triangulo"/>
        /// </summary>
        /// <param name="pX1">Coordenada X del punto 1</param>
        /// <param name="pY1">Coordenada Y del Punto 1</param>
        /// <param name="pX2">Coordenada X del punto 2</param>
        /// <param name="pY2">Coordenada Y del Punto 2</param>
        /// <param name="pX3">Coordenada X del punto 3</param>
        /// <param name="pY3">Coordenada Y del Punto 3</param>
        /// <returns>Area del Triangulo</returns>
        public double CalcularAreaTriangulo(double pX1, double pY1, double pX2, double pY2, double pX3, double pY3)
        {
            Punto lPunto1 = new Punto(pX1, pY1);
            Punto lPunto2 = new Punto(pX2, pY2);
            Punto lPunto3 = new Punto(pX3, pY3);
            Triangulo lTriangulo = new Triangulo(lPunto1, lPunto2, lPunto3);
            return lTriangulo.Area;
        }

        /// <summary>
        /// Obtiene el perimetro de un <see cref="Circulo"/>
        /// </summary>
        /// <param name="pX">Coordenada X del centro </param>
        /// <param name="pY">Coordenada Y del centro </param>
        /// <param name="pRadio">Radio del Circulo</param>
        /// <returns>Perimetro del Circulo</returns>
        public double CalcularPerimetroCirculo(double pX, double pY, double pRadio)
        {
            Punto lPunto = new Punto(pX, pY);
            Circulo lCirculo = new Circulo(lPunto, pRadio);
            return lCirculo.Perimetro;
        }

        /// <summary>
        /// Obtiene el Area de un <see cref="Circulo"/>
        /// </summary>
        /// <param name="pX">Coordenada X del centro </param>
        /// <param name="pY">Coordenada Y del centro </param>
        /// <param name="pRadio">Radio del Circulo</param>
        /// <returns>Area del Circulo</returns>
        public double CalcularAreaCirculo(double pX, double pY, double pRadio)
        {
            Punto lPunto = new Punto(pX, pY);
            Circulo lCirculo = new Circulo(lPunto, pRadio);
            return lCirculo.Area;
        }
	}
}
