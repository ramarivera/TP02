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
        /// <param name="pCoordX">Coordenadas en el Eje X de los 3 puntos del triangulo</param>
        /// <param name="pCoordY">Coordenadas en el Eje Y de los 3 puntos del triangulo</param>
        /// <returns>Perimetro del Triangulo</returns>
        public double CalcularPerimetroTriangulo(double[] pCoordX, double[] pCoordY)
        {
            Punto lPunto1 = new Punto(pCoordX[0], pCoordY[0]);
            Punto lPunto2 = new Punto(pCoordX[1], pCoordY[1]);
            Punto lPunto3 = new Punto(pCoordX[2], pCoordY[2]);
            Triangulo lTriangulo = new Triangulo(lPunto1, lPunto2, lPunto3);
            return lTriangulo.Perimetro;
        }

        /// <summary>
        /// Obtiene el area de un <see cref="triangulo"/> 
        /// </summary>
        /// <param name="pCoordX">Coordenadas en el Eje X de los 3 puntos del triangulo</param>
        /// <param name="pCoordY">Coordenadas en el Eje Y de los 3 puntos del triangulo</param>
        /// <returns>Area del Triangulo</returns>
        public double CalcularAreaTriangulo(double[] pCoordX, double[] pCoordY)
        {
            Punto lPunto1 = new Punto(pCoordX[0], pCoordY[0]);
            Punto lPunto2 = new Punto(pCoordX[1], pCoordY[1]);
            Punto lPunto3 = new Punto(pCoordX[2], pCoordY[2]);
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
