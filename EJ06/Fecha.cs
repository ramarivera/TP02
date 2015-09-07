using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ06
{
	/// <summary>
	/// 
	/// </summary>
	class Fecha
	{
		#region Fecha - Atributos 
		/// <summary>
		/// 
		/// </summary>
		private int readonly iDia;
		/// <summary>
		/// 
		/// </summary>
		private int readonly iMes;
		/// <summary>
		/// 
		/// </summary>
		private int readonly iAnio;
		#endregion
		#region Fecha - Constantes
		/// <summary>
		/// 
		/// </summary>
		private const  string[] NOMBRES_DIAS = { "Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };
		private const string[] NOMBRES_MESES = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
		/// <summary>
		/// 
		/// </summary>
		private const int[] DIAS_MESES = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		private static readonly int[] COEFICIENTES_MESES = { 6, 2, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
		private const int ANIO_MINIMO = 1900;
		private const int ANIO_MAXIMO = 2199;
		#endregion
		#region Fecha - Constructores
		/// <summary>
		/// Constructor de la clase Fecha
		/// </summary>
		/// <param name="pDia">Numero de Dia</param>
		/// <param name="pMes">Numero de Mes</param>
		/// <param name="pAnio">Numero de Anio</param>
		/// <exception cref="ArgumentOutOfRangeException"> Arroja excepcion si los valores de dias, mes o año no resultan validos</exception>
		public Fecha(int pDia, int pMes, int pAnio)
		{
			if (pAnio < ANIO_MINIMO)
			{
				throw new System.ArgumentOutOfRangeException("pAnio",pAnio,"El Anio no puede ser menor a " + ANIO_MINIMO.ToString());
            }
			if (pAnio > ANIO_MAXIMO)
			{
				throw new System.ArgumentOutOfRangeException("pAnio", pAnio, "El Anio no puede ser mayor a " + ANIO_MAXIMO.ToString());
			}
			if (pMes < 1 || pMes > 12)
			{
				throw new System.ArgumentOutOfRangeException("pMes", pMes, "El numero de mes debe estar entre 01 y 12");
			}
			if (pDia > Fecha.DiasDelMesAnio(pMes, pAnio))
			{
				throw new System.ArgumentOutOfRangeException("pDia", pDia, "El numero de dias es mayor a los dias permitidos para el mes y anio");
			}
			if (pDia < 1)
			{
				throw new System.ArgumentOutOfRangeException("pMes", pMes, "El valor minimo de dia es 01");

			}
			this.iDia = pDia;
			this.iMes = pMes;
			this.iAnio = pAnio;

		}

		public Fecha() : this(1, 1, ANIO_MINIMO) { }
		#endregion
		#region Fecha - Propiedades
		/// <summary>
		/// 
		/// </summary>
		public int Dia
		{
			get { return this.iDia; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Mes
		{
			get { return this.iMes; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Anio
		{
			get	{ return this.iAnio; }
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool Bisiesto
		{
			get { return Fecha.EsBisiesto(Anio); }
		}
		/// <summary>
		/// 
		/// </summary>
		public int DiasMesAnioActual
		{
			get { return DiasDelMesAnio(Mes, Anio); }
		}
		/// <summary>
		/// 
		/// </summary>
		public String DiaSemanaActual
		{
			get { return Fecha.DiaSemanaFecha(Dia, Mes, Anio); }
		}
		/// <summary>
		/// 
		/// </summary>
		public String NombreMesActual
		{
			get { return Fecha.NombreMes(Mes); }
		}
		#endregion
		#region Fecha - Metodos Estaticos 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pAnio"></param>
		/// <returns></returns>
		public static bool EsBisiesto(int pAnio)
		{
			return (pAnio % 4 == 0 && pAnio % 100 != 0 || pAnio % 400 == 0);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pMes"></param>
		/// <param name="pAnio"></param>
		/// <returns></returns>
		public static int DiasDelMesAnio (int pMes, int pAnio)
		{
			return (pMes == 2 && Fecha.EsBisiesto(pAnio)) ? 29 : DIAS_MESES[pMes - 1]; 
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static String DiaSemanaFecha(int pDia, int pMes, int pAnio)
		{
			int resultado = 0;

			//
			if (pAnio >= 1900 && pAnio < 2000)
			{
				resultado++;
			}
			else
			{
				if (pAnio >= 2100 && pAnio < 2200)
				{
					resultado -= 2;
				}
			}

			//
			resultado += ((pAnio % 100) + (pAnio % 100) / 4);

			//
			resultado += Fecha.EsBisiesto(pAnio) ? -1 : 0;

			//
			resultado += COEFICIENTES_MESES[pMes - 1];

			//
			resultado += pDia;

			//
			return NOMBRES_DIAS[resultado % 7];
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pMes"></param>
		/// <returns></returns>
		public static String NombreMes(int pMes)
		{
			return NOMBRES_MESES[pMes - 1];
		}
		#endregion
		#region Fecha - Metodos "Agregar"
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pDias"></param>
		/// <returns></returns>
		public Fecha AgregarDias(int pDias)
		{
			int maxDias, nuevoDia;


			maxDias = DiasMesAnioActual;
			nuevoDia = Dia + pDias;

			if (!(nuevoDia > maxDias))
			{
				//No salte de Mes
				return new Fecha(nuevoDia, Mes, Anio);
			}
			else
			{
				Fecha auxFecha = new Fecha(1, Mes, Anio);
				auxFecha = auxFecha.AgregarMeses(1);
				return auxFecha.AgregarDias(nuevoDia - maxDias - 1);
			}

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pMeses"></param>
		/// <returns></returns>
		public Fecha AgregarMeses(int pMeses)
		{
			if (pMeses > 1)
			{
				// int auxMes = pMeses - 1;
				Fecha auxFecha = this.AgregarMeses(1);
				return auxFecha.AgregarMeses(pMeses-1);
			}
			else
			{
				if (Dia == 31)
				{
					if (Mes == 12)
					{
						Fecha auxFecha = new Fecha(Dia, 1, Anio);
						return auxFecha.AgregarAnio(1);
					}
					else
					{
						int maxDias = Fecha.DiasDelMesAnio(Mes + 1, Anio);
						return new Fecha(maxDias, Mes + 1, Anio);
					}
				}
				else
				{
					return new Fecha(Dia, Mes + 1, Anio);
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pAnio"></param>
		/// <returns></returns>
		public Fecha AgregarAnio (int pAnio)
		{
			int nuevoDia, nuevoMes, nuevoAnio;

			nuevoAnio = Anio + pAnio;

			if (Dia==29 && Mes==2)
			{
				if (Fecha.EsBisiesto(nuevoAnio))
				{
					nuevoDia = 29;
					nuevoMes = 2;
				}
				else
				{
					nuevoDia = 1;
					nuevoMes = 3;
				}
			}
			else
			{
				nuevoDia = Dia;
				nuevoMes = Mes;
			}

			return new Fecha(nuevoDia, nuevoMes, nuevoAnio);
			
		}
		#endregion
		#region Fecha - Metodos Sobrecargados (Equals, ToString, GetHashCode)
		public override string ToString()
		{
			return Dia.ToString() + "/" + Mes.ToString() + "/" + Anio.ToString();
		}
		
		/// <summary>
		/// Sobrecarga del metodo Equals()
		/// </summary>
		/// <param name="obj">Objeto con el que se desea comparar igualdad</param>
		/// <returns>Verdadero o Falso, segun la igualdad del objeto</returns>
		public override bool Equals(object obj)
		{
			// Si obj es (apunta a) null, falso
			if (Object.ReferenceEquals(null, obj))
			{
				return false;
			}
			// Si obj es (apunta a) this, verdadero
			if (Object.ReferenceEquals(this, obj))
			{
				return true;
			}

			// Si los tipos son distintos, falso
			// Esto me permite castear con () sin controlar por (obj)null
			if (obj.GetType() != this.GetType())
			{
				return false;
			}

			// Aplico logica particular, casteando previamente a Fecha
			return (this.EsIgual((Fecha)obj));
		}
		/// <summary>
		/// Metodo Equals para objetos de la clase Fecha
		/// </summary>
		/// <param name="pFecha">Fecha con la que desea controlar igualdad (NO IDENTIDAD)</param>
		/// <returns>Verdadero o Falso, dependiendo la igualdad de los elementos</returns>
		public bool Equals(Fecha pFecha)
		{
			// Si pFecha es (apunta a) null, falso
			if (Object.ReferenceEquals(null, pFecha))
			{
				return false;
			}

			// Si pFecha es (apunta a) this, verdadero
			if (Object.ReferenceEquals(this, pFecha))
			{
				return true;
			}

			// Aplico logica particular
			return (this.EsIgual(pFecha));
		}
		/// <summary>
		/// Sobrecarga del metodo GetHashCode()
		/// http://www.loganfranken.com/blog/692/overriding-equals-in-c-part-2/
		/// El HashCode debe ser rapido de calcular y con pocas colisiones
		/// </summary>
		/// <returns>Integer HashCode</returns>
		public override int GetHashCode()
		{
			// Buscamos grandes productos semi-aleatorios, por lo tanto somos concientes de que un overflow de integers es posible, el cual no nos afecta
			unchecked
			{
				// Un gran numero primo disminuye las colisiones en grandes conjuntos de objetos
				const int HashingBase = (int)2166136261; //Primo01, casteado a int
				const int HashingMultiplier = 16777619; //Primo02

				int hash = HashingBase;
				//Utilizamos cada propiedad de nuestro objeto, si dicha propiedad es nula, el resultado es 0
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Dia) ? Dia.GetHashCode() : 0);
				//Sucesivamente vamos acumulando los resultados
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Mes) ? Mes.GetHashCode() : 0);
				//Por ultimo en vez de usar +, usamos el operador XOR ^ para obtener una implementacion mas performante
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Anio) ? Anio.GetHashCode() : 0);
				return hash;
			}
		}
		#endregion
		#region Fecha - Metodos de Comparacion
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pOtraFecha"></param>
		/// <returns></returns>
		private bool EsIgual(Fecha pOtraFecha)
		{
			return (Anio == pOtraFecha.Anio && Mes == pOtraFecha.Mes && Dia == pOtraFecha.Dia);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pOtraFecha"></param>
		/// <returns></returns>
		private bool EsMayor(Fecha pOtraFecha)
		{
			// 12/11/2012 y 04/10/2012
			if (Anio < pOtraFecha.Anio)
			{
				if (Anio == pOtraFecha.Anio)
				{
					if (Mes < pOtraFecha.Mes)
					{
						if (Mes == pOtraFecha.Mes)
						{
							if (Dia <= pOtraFecha.Dia)
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					}
				}
				else
				{
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pOtraFecha"></param>
		/// <returns></returns>
		private bool EsMenor(Fecha pOtraFecha)
		{
			return !(this.EsMayor(pOtraFecha) || this.EsIgual(pOtraFecha));
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pOtraFecha"></param>
		/// <returns></returns>
		private bool EsMayorIgual(Fecha pOtraFecha)
		{
			return (this.EsIgual(pOtraFecha) || this.EsMayor(pOtraFecha));
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pOtraFecha"></param>
		/// <returns></returns>
		private bool EsMenorIgual(Fecha pOtraFecha)
		{
			return !this.EsMayor(pOtraFecha);
		}
		#endregion
		#region Fecha - Operadores
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pA"></param>
		/// <param name="pB"></param>
		/// <returns></returns>
		public static bool operator ==(Fecha pA, Fecha pB)
		{
			return pA.EsIgual(pB);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pA"></param>
		/// <param name="pB"></param>
		/// <returns></returns>
		public static bool operator !=(Fecha pA, Fecha pB)
		{
			return !(pA == pB);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pA"></param>
		/// <param name="pB"></param>
		/// <returns></returns>
		public static bool operator >(Fecha pA, Fecha pB)
		{
			return pA.EsMayor(pB);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pA"></param>
		/// <param name="pB"></param>
		/// <returns></returns>
		public static bool operator <(Fecha pA, Fecha pB)
		{
			return pA.EsMenor(pB);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pA"></param>
		/// <param name="pB"></param>
		/// <returns></returns>
		public static bool operator >=(Fecha pA, Fecha pB)
		{
			return pA.EsMayorIgual(pB);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pA"></param>
		/// <param name="pB"></param>
		/// <returns></returns>
		public static bool operator <=(Fecha pA, Fecha pB)
		{
			return pA.EsMenorIgual(pB);
		}
		#endregion
	}
}
