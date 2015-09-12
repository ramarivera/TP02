using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ05
{
	/// <summary>
	/// Representa un numero complejo, con sus correspondientes operaciones.
	/// Fuente de la Matematica de la clase: https://es.wikipedia.org/wiki/N%C3%BAmero_complejo
	/// Provee tambien sobrecarga de operadores aritmeticos, de igualdad (== y !=)
	/// </summary>
    /// <remarks>
    /// Se definen los operadores relaciones como parte del ejercicio, aunque los numeros complejos no tengan orden 
    /// </remarks>
	class Complejo
    {
		/// <summary>
		/// Compoenente real del numero complejo z
		/// </summary>
		private double iReal;
		/// <summary>
		/// Componente imaginario del numero complejo z
		/// </summary>
		private double iImaginario;
		/// <summary>
		/// Constructor de la clase Complejo, 
		/// Un numero complejo z tiene la forma a + bi
		/// </summary>
		/// <param name="pReal">Componente Real, a</param>
		/// <param name="pImaginario">Componente Imaginario, b</param>
		public Complejo (double pReal, double pImaginario )
		{
			this.iReal = pReal;
			this.iImaginario = pImaginario;
		}
		/// <summary>
		/// Propiedad Componente Real, solo lectura.
		/// Equivalente a Re(z)
		/// </summary>
		public double Real
		{
			get { return this.iReal; }
		}
		/// <summary>
		/// Propiedad Componente Imaginario, solo lectura.
		/// Equivalente a Im(z)
		/// </summary>
		public double Imaginario
		{
			get { return this.iImaginario; }
		}
		
        /// <summary>
        /// Implementacion propia del metodo Atan2
        /// </summary>
        /// <param name="pY">Argumento 1</param>
        /// <param name="pX">Argumento 2</param>
        /// <returns>Devuelve el angulo cuya tangente es el cociente de pX y pY</returns>
		private double Atan2(double pY, double pX)
		{
			int signo = (pY >= 0 ? 1 : -1); // Math.Sign()
			return (Math.PI / 2) * signo - (Math.Atan(pX / pY));
		}

        /// <summary>
        /// Propiedad Argumento en radianes, solo lectura
        /// </summary>
		public double ArgumentoEnRadianes
		{
			get { return Math.Atan2(Imaginario, Real); }
		}
	
        /// <summary>
        /// Propiedad Argumento en grados, solo lectura
        /// </summary>
		public double ArgumentoEnGrados
		{
			get {  return (ArgumentoEnRadianes * (180 / Math.PI) ); }
		}

        /// <summary>
        /// Devuelve otra instancia de la clase conteniendo el complejo conjugado de esta instancia
        /// </summary>
		public Complejo Conjugado
		{
			get { return (new Complejo(Real,-1 * Imaginario)); }
		}

        /// <summary>
        /// Propiedad Magnitud, solo lectura
        /// </summary>
		public double Magnitud
		{
			get { return Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginario, 2)); }
		}

        /// <summary>
        /// Verifica si un numero es real
        /// </summary>
        /// <returns>Devuelve un boolean que es verdadero si el numero es real</returns>
		public bool EsReal()
		{
			return (Imaginario == 0);
		}

        /// <summary>
        /// Verifica si un numero es imaginario
        /// </summary>
        /// <returns>Devuelve un booleano que es verdadero si el numero es imaginario</returns>
		public bool EsImaginario ()
		{
			return !EsReal();
		}
		/// <summary>
		/// Sobrecarga del metodo Equals()
		/// </summary>
		/// <param name="obj">Objeto con el que se desea comparar igualdad</param>
		/// <returns>Verdadero o Falso, segun la igualdad del objeto</returns>
		public override bool Equals(object obj)
		{
			if (Object.ReferenceEquals(null, obj))
			{
				return false;
			}

			if (Object.ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != this.GetType())
			{
				return false;
			}
			
			// Aplico logica particular
			return (this.EsIgual((Complejo) obj));
		}

        /// <summary>
        /// Metodo Equals() para objetos de la clase Complejo
        /// </summary>
        /// <param name="number">Numero con el que se desea comparar igualdad</param>
        /// <returns>Verdadero o Falso, dependiendo la igualdad de los elementos</returns>
		public bool Equals(Complejo number)
		{
			// Is null?
			if (Object.ReferenceEquals(null, number))
			{
				return false;
			}

			// Is the same object?
			if (Object.ReferenceEquals(this, number))
			{
				return true;
			}

			return (this.EsIgual(number));
		}

		/// <summary>
		/// Sobrecarga del metodo GetHashCode()
		/// http://www.loganfranken.com/blog/692/overriding-equals-in-c-part-2/
		/// </summary>
		/// <returns>Integer HashCode</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				const int HashingBase = (int)2166136261;
				const int HashingMultiplier = 16777619;

				int hash = HashingBase;
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Real) ? Real.GetHashCode() : 0);
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Imaginario) ? Imaginario.GetHashCode() : 0);
				return hash;
			}
		}

		/// <summary>
		/// Sobrecarga del operador ==
		/// </summary>
		/// <param name="pA">Complejo A </param>
		/// <param name="pB">Complejo B</param>
		/// <returns>Verdadero si Complejo A = Complejo B</returns>
		public static bool operator ==(Complejo pA, Complejo pB)
		{
			// Si las referencias son iguales o ambos son nulos, verdadero
			if (System.Object.ReferenceEquals(pA, pB))
			{
				return true;
			}
			// Si uno es nulo pero el otro no, falso
			if (((object)pA == null) || ((object)pB == null))
			{
				return false;
			}
			//Aplico logica particular 
			return pA.Equals(pB);

		}
		/// <summary>
		/// Sobrecarga del operador !=
		/// </summary>
		/// <param name="pA">Complejo A </param>
		/// <param name="pB">Complejo B</param>
		/// <returns>Verdadero si not(Complejo A = Complejo B)</returns>
		public static bool operator !=(Complejo pA, Complejo pB)
		{
			// Complemento del operador  == 
			return !(pA == pB);
		}

		/// <summary>
		/// Implementa la logica de igualdad particular de la clase 
		/// </summary>
		/// <param name="pOtroComplejo">Complejo con el que se desea comparar</param>
		/// <returns>Verdadero si pOtroComplejo es igual al Complejo que invoco el metodo</returns>
        public bool EsIgual (Complejo pOtroComplejo)
		{
			// Si los componentes son iguales, los numeros son iguales
			return ((pOtroComplejo.Imaginario == Imaginario) && (pOtroComplejo.Real == Real));
        }
		/// <summary>
		/// Implementa la logica de igualdad particular de la clase
		/// </summary>
		/// <param name="pReal"></param>
		/// <param name="pImaginario"></param>
		/// <returns>Verdadero si un Complejo con los valores pReal y pImaginario
		/// es igual al Complejo que invoco el metodo</returns>
		public bool EsIgual (double pReal, double pImaginario)
		{
			// Factorizado en funcion de EsIgual(Complejo pOtroComplejo)
			return (this.EsIgual(new Complejo(pReal, pImaginario)));
		}

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="pA">Complejo A </param>
        /// <param name="pB">Complejo B</param>
        /// <returns>Devuelve el resultado de la suma de pA y pB</returns>
		public static Complejo operator + (Complejo pA, Complejo pB)
		{
			return pA.Sumar(pB);
		}

        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="pA">Complejo A </param>
        /// <param name="pB">Complejo B</param>
        /// <returns>Devuelve el resultado de la resta de pA y pB</returns>
		public static Complejo operator -(Complejo pA, Complejo pB)
		{
			return pA.Restar(pB);
		}

        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="pA">Complejo A </param>
        /// <param name="pB">Complejo B</param>
        /// <returns>Devuelve el resultado del producto de pA y pB</returns>
		public static Complejo operator *(Complejo pA, Complejo pB)
		{
			return pA.MultiplicarPor(pB);
		}

        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="pA">Complejo A </param>
        /// <param name="pB">Complejo B</param>
        /// <returns>Devuelve el resultado de la division de pA sobre pB</returns>
		public static Complejo operator /(Complejo pA, Complejo pB)
		{
			return pA.DividirPor(pB);
		}

        /// <summary>
        /// Implementa la logica de suma de la clase
        /// </summary>
        /// <param name="pOtroComplejo">Un numero complejo</param>
        /// <returns>Devuelve el resultado de la suma de dos numeros complejos</returns>
		public Complejo Sumar (Complejo pOtroComplejo)
		{
			return new Complejo((Real + pOtroComplejo.Real), (Imaginario + pOtroComplejo.Imaginario));
		}

        /// <summary>
        /// Implementa la logica de resta de la clase
        /// </summary>
        /// <param name="pOtroComplejo">Un numero complejo</param>
        /// <returns>Devuelve el resultado de la resta de dos numeros complejos</returns>
		public Complejo Restar(Complejo pOtroComplejo)
		{
			return new Complejo((Real - pOtroComplejo.Real), (Imaginario - pOtroComplejo.Imaginario));
		}

        /// <summary>
        /// Implementa la logica del producto de la clase
        /// </summary>
        /// <param name="pOtroComplejo">Un numero complejo</param>
        /// <returns>Devuelve el resultado del producto de dos numeros complejos</returns>
		public Complejo MultiplicarPor(Complejo pOtroComplejo)
		{
			double a, b, c, d;
			a = Real;
			b = Imaginario;
			c = pOtroComplejo.Real;
			d = pOtroComplejo.Imaginario;
			return  new Complejo((a*c-b*d),(a*d+b*c));
		}

        /// <summary>
        /// Implementa la logica de division de la clase
        /// </summary>
        /// <param name="pOtroComplejo">Un numero complejo, divisor</param>
        /// <returns>Devuelve el resultado de la division de un numeros complejo sobre el divisor</returns>
		public Complejo DividirPor(Complejo pOtroComplejo)
		{
			double a, b, c, d;
			a = Real;
			b = Imaginario;
			c = pOtroComplejo.Real;
			d = pOtroComplejo.Imaginario;
			return new Complejo(((a * c + b * d) / (c * c + d * d)), ((b * c - a * d) / (c * c + d * d)));
		}

        /// <summary>
        /// Implementa la logica de es mayor de la clase
        /// </summary>
        /// <param name="pOtroComplejo">Un numero complejo</param>
        /// <returns>Devuelve un booleano que es verdadero si el numero que llama al metodo es mayor al numero parametro del metodo</returns>
		public bool EsMayor (Complejo pOtroComplejo)
		{
			return Magnitud > pOtroComplejo.Magnitud;
		}

        /// <summary>
        /// Implementa la logica de es mayor o igual de la clase
        /// </summary>
        /// <param name="pOtroComplejo">Un numero complejo</param>
        /// <returns>Devuelve un booleano que es verdadero si el numero que llama al metodo es mayor o igual al numero parametro del metodo</returns>
		public bool EsMayorIgual(Complejo pOtroComplejo)
		{
			return ((this == pOtroComplejo) || (this.EsMayor(pOtroComplejo)));
		}

        /// <summary>
        /// Implementa la logica de es menor de la clase
        /// </summary>
        /// <param name="pOtroComplejo">Un numero complejo</param>
        /// <returns>Devuelve un booleano que es verdadero si el numero que llama al metodo es menor al numero parametro del metodo</returns>
		public bool EsMenor(Complejo pOtroComplejo)
		{
			return !(this.EsMayorIgual(pOtroComplejo));
		}

        /// <summary>
        /// Implementa la logica de es menor o igual de la clase
        /// </summary>
        /// <param name="pOtroComplejo">Un numero complejo</param>
        /// <returns>Devuelve un booleano que es verdadero si el numero que llama al metodo es menor o igual al numero parametro del metodo</returns>
		public bool EsMenorIgual(Complejo pOtroComplejo)
		{
			return !(this.EsMayor(pOtroComplejo));
		}

        /// <summary>
        /// Sobrecarga del operador >
        /// </summary>
        /// <param name="pA">Complejo A </param>
        /// <param name="pB">Complejo B</param>
        /// <returns>Verdadero si Complejo A > Complejo B</returns>
		public static bool operator >(Complejo pA, Complejo pB)
		{
			return pA.EsMayor(pB);
		}

        /// <summary>
        /// Sobrecarga del operador <
        /// </summary>
        /// <param name="pA">Complejo A </param>
        /// <param name="pB">Complejo B</param>
        /// <returns>Verdadero si Complejo A < Complejo B</returns>
		public static bool operator <(Complejo pA, Complejo pB)
		{
			return pA.EsMenor(pB);
		}

        /// <summary>
        /// Sobrecarga del operador >=
        /// </summary>
        /// <param name="pA">Complejo A </param>
        /// <param name="pB">Complejo B</param>
        /// <returns>Verdadero si Complejo A >= Complejo B</returns>
		public static bool operator >=(Complejo pA, Complejo pB)
		{
			return pA.EsMayorIgual(pB);
		}

        /// <summary>
        /// Sobrecarga del operador <=
        /// </summary>
        /// <param name="pA">Complejo A </param>
        /// <param name="pB">Complejo B</param>
        /// <returns>Verdadero si Complejo A <= Complejo B</returns>
		public static bool operator <=(Complejo pA, Complejo pB)
		{
			return pA.EsMenorIgual(pB);
		}


	}
}
