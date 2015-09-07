using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ06
{
	class Fecha
	{
		/// <summary>
		/// 
		/// </summary>
		private int iDia;
		/// <summary>
		/// 
		/// </summary>
		private int iMes;
		/// <summary>
		/// 
		/// </summary>
		private int iAnio;
		/// <summary>
		/// 
		/// </summary>
		private static readonly string[] NOMBRES_DIAS = { "Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };
		private static readonly string[] NOMBRES_MESES = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
		/// <summary>
		/// 
		/// </summary>
		private static readonly int[] DIAS_MESES = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		private static readonly int[] COEFICIENTES_MESES = { 6, 2, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
		private static readonly int ANIO_MINIMO = 1900;
		private static readonly int ANIO_MAXIMO = 2199;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pDia"></param>
		/// <param name="pMes"></param>
		/// <param name="pAnio"></param>
		/// <exception cref="ArgumentException"> Arroja excepcion si el año esta fuera de rango</exception>
		public Fecha(int pDia, int pMes, int pAnio)
		{
			if (pAnio < ANIO_MINIMO)
			{
				throw new System.ArgumentException("El Anio no puede ser menor a " + ANIO_MINIMO.ToString(), "pAnio");
			}
			if (pAnio > ANIO_MAXIMO)
			{
				throw new System.ArgumentException("El Anio no puede ser mayor a " + ANIO_MAXIMO.ToString(), "pAnio");
			}
			this.iDia = pDia;
			this.iMes = pMes;
			this.iAnio = pAnio;

		}

		public Fecha() : this(1, 1, ANIO_MINIMO) { }

		public int Dia
		{
			get { return this.iDia; }
		}

		public int Mes
		{
			get { return this.iMes; }
		}
		public int Anio
		{
			get	{ return this.iAnio; }
		}

		public static bool EsBisiesto(int pAnio)
		{
			return (pAnio % 4 == 0 && pAnio % 100 != 0 || pAnio % 400 == 0);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool Bisiesto
		{
			get { return Fecha.EsBisiesto(Anio); }
		}
		

		public static int DiasDelMesAnio (int pMes, int pAnio)
		{
			return (pMes == 2 && Fecha.EsBisiesto(pAnio)) ? 29 : DIAS_MESES[pMes - 1]; 
        }

		public int DiasMesAnioActual
		{
			get { return DiasDelMesAnio(Mes, Anio); }
		}

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
				Fecha auxFecha = this.AgregarMeses(1);
				return auxFecha.AgregarDias(nuevoDia - maxDias);
			}

		}

		public Fecha AgregarMeses(int pMeses)
		{
			if (pMeses > 1)
			{
				// int auxMes = pMeses - 1;
				Fecha auxFecha = this.AgregarMeses(1);
				return auxFecha.AgregarMeses(pMeses--);
			}
			else
			{
				if (DiasMesAnioActual == 31)
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
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public String DiaSemanaFecha()
		{
			int resultado = 0;
			int anio = Anio;

			//
			if (anio >= 1900 && anio < 2000)
			{
				resultado++;
			}
			else
			{
				if (anio >= 2100 && anio < 2200)
				{
					resultado -= 2;
				}
			}

			//
			resultado += ((anio % 100) + (anio % 100) / 4);

			//
			resultado += this.EsBisiesto() ? -1 : 0;

			//
			resultado += COEFICIENTES_MESES[Mes - 1];

			//
			resultado += Dia;

			//
			return NOMBRES_DIAS[resultado % 7];
        }

		private bool EsIgual (Fecha pOtraFecha)
		{
			return (Anio == pOtraFecha.Anio && Mes == pOtraFecha.Mes && Dia == pOtraFecha.Dia);
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
			return (this.EsIgual((Fecha)obj));
		}

		public bool Equals(Fecha fecha)
		{
			// Is null?
			if (Object.ReferenceEquals(null, fecha))
			{
				return false;
			}

			// Is the same object?
			if (Object.ReferenceEquals(this, fecha))
			{
				return true;
			}

			return (this.EsIgual(fecha));
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
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Dia) ? Dia.GetHashCode() : 0);
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Mes) ? Mes.GetHashCode() : 0);
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Anio) ? Anio.GetHashCode() : 0);
				return hash;
			}
		}

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

		private bool EsMenor(Fecha pOtraFecha)
		{
			return !(this.EsMayor(pOtraFecha) || this.EsIgual(pOtraFecha));
		}

		private bool EsMayorIgual(Fecha pOtraFecha)
		{
			return (this.EsIgual(pOtraFecha) || this.EsMayor(pOtraFecha));
		}

		private bool EsMenorIgual(Fecha pOtraFecha)
		{
			return !this.EsMayor(pOtraFecha);
		}

		public static bool operator ==(Fecha pA, Fecha pB)
		{
			return pA.EsIgual(pB);
		}

		public static bool operator !=(Fecha pA, Fecha pB)
		{
			return !(pA == pB);
		}

		public static bool operator >(Fecha pA, Fecha pB)
		{
			return pA.EsMayor(pB);
		}

		public static bool operator <(Fecha pA, Fecha pB)
		{
			return pA.EsMenor(pB);
		}

		public static bool operator >=(Fecha pA, Fecha pB)
		{
			return pA.EsMayorIgual(pB);
		}

		public static bool operator <=(Fecha pA, Fecha pB)
		{
			return pA.EsMenorIgual(pB);
		}



	}
}
