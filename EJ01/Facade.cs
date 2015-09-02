using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
	class Facade
	{
        public Circulo CrearCirculo(Punto pCentro, double pRadio)
        {
            Circulo circulo = new Circulo(pCentro,pRadio);
            return circulo;
        }

        public Triangulo CrearTriangulo(Punto pPunto1, Punto pPunto2, Punto pPunto)
        {
            Triangulo triangulo = new Triangulo(pPunto1, pPunto2, pPunto2);
            return triangulo;
        }

        public Punto CrearPunto(double pX,double pY)
        {
            Punto punto = new Punto(pX, pY);
            return punto;
        }

        public double CalcularPerimetroTriangulo(Triangulo pTriangulo)
        {
            return pTriangulo.Perimetro;
        }

        public double CalcularAreaTriguanlo(Triangulo pTriangilo)
        {
            return pTriangilo.Area;
        }

        public double CalcularPerimetroCirculo(Circulo pCirculo)
        {
            return pCirculo.Perimetro;
        }

        public double CalcularAreaCirculo(Circulo pCirculo)
        {
            return pCirculo.Area;
        }
	}
}
