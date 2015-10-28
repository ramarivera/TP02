using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ06
{
	/// <summary>
	/// Representa una fecha, tanto en el calendario Gregoriano como Juliano. 
	/// Su valor minimo es 01/01/1582 y su valor maximo es 31/12/2582.
	/// Implementa operadores relacionales y aritmetica de Fechas (Resta, suma)
	/// </summary>
	class Fecha
	{
		#region Fecha - Atributos 
		/// <summary>
		/// Numero de dia en formato Gregoriano, sus valores permitidos estan entre 1 y 31, dependiendo del mes.
		/// </summary>
		private readonly int iDia;

		/// <summary>
		/// Numero de mes en formato Gregoriano, sus valores permitidos estan entre 1 y 12.
		/// </summary>
		private readonly int  iMes;

		/// <summary>
		/// Numero de Año en formato Gregoriano, sus valores van desde 1582 hasta 2582
		/// </summary>
		private readonly int  iAño;

		/// <summary>
		/// Numero de Dias en formato Juliano.
		/// </summary>
		private readonly long iDiaJuliano;

		#endregion
		#region Fecha - Constantes
		/// <summary>
		/// Array utilizado para persistir el nombre de los dias de la semana. Esta forma de guardarlos permitiria realizar una localizacion regional de  la clase mas facilmente
		/// </summary>
		private static readonly string[] NOMBRES_DIAS = { "Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };

        /// <summary>
        /// Array utilizado para persistir el nombre de los Meses del Año. Esta forma de guardarlos permitiria realizar una localizacion regional de  la clase mas facilmente
        /// </summary>
        private static readonly string[] NOMBRES_MESES = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
		
        /// <summary>
		/// Almacena los dias de cada mes, para el caso de años no bisiestos
		/// </summary>
		private static readonly int[] DIAS_MESES = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		
        /// <summary>
		/// Almacena coeficientes para cada mes, utilizado para el calculo del nombre del dia de la semana para una fecha
		/// </summary>
		private static readonly int[] COEFICIENTES_MESES = { 6, 2, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
		
        /// <summary>
		/// Numero Minimo permitido de año. Entonces la minima fecha instanciable es 01/01/1990
		/// </summary>
		private static readonly int AÑO_MINIMO = 1700;
		
        /// <summary>
		/// Numero maximo permitido de año. Entonces la maxima fecha instanciable es 31/12/2199
		/// </summary>
		private static readonly int AÑO_MAXIMO = 2582;
		
        /// <summary>
		/// Limite inferior de la fecha en formato Juliana, equivalente al 01/01/1700
		/// </summary>
		private static readonly long BASE_JULIANA = 2341973;
		
        /// <summary>
		/// Limite Superior de la fecha en formato Juliana, equivalente al 31/12/2299
		/// </summary>
		private static readonly long TOPE_JULIANA = 2561117;

		#endregion
		#region Fecha - Constructores
		/// <summary>
		/// Constructor de Instancia, Se ingresan los valores para el calendario Gregoriano
		/// </summary>
		/// <param name="pDia">Numero de Dia</param>
		/// <param name="pMes">Numero de Mes</param>
		/// <param name="pAño">Numero de Año</param>
		/// <exception cref="ArgumentOutOfRangeException"> Arroja excepcion si los valores de pDia, pMes o pAño no se encuentran en el rango valido</exception>
		public Fecha(int pDia, int pMes, int pAño)
		{
			if (pAño < AÑO_MINIMO)
			{
				throw new System.ArgumentOutOfRangeException("pAño",pAño,"El Año no puede ser menor a " + AÑO_MINIMO.ToString());
            }
			if (pAño > AÑO_MAXIMO)
			{
				throw new System.ArgumentOutOfRangeException("pAño", pAño, "El Año no puede ser mayor a " + AÑO_MAXIMO.ToString());
			}
			if (pMes < 1 || pMes > 12)
			{
				throw new System.ArgumentOutOfRangeException("pMes", pMes, "El numero de mes debe estar entre 01 y 12");
			}
			if (pDia > Fecha.DiasDelMesAño(pMes, pAño))
			{
				throw new System.ArgumentOutOfRangeException("pDia", pDia, "El numero de dias es mayor a los dias permitidos para el mes y Año");
			}
			if (pDia < 1)
			{
				throw new System.ArgumentOutOfRangeException("pMes", pMes, "El valor minimo de dia es 01");
			}

			long diaJuliano = Fecha.ToJuliano(pDia, pMes, pAño);

			this.iDia = pDia;
			this.iMes = pMes;
			this.iAño = pAño;
			this.iDiaJuliano = diaJuliano;
		}
		
        /// <summary>
		/// Constructor por defecto de Instancia, devuelve el 01/01/1582
		/// </summary>
		public Fecha() : this(BASE_JULIANA) { }
		
        /// <summary>
		/// Constructor de instancia, se ingresa el numero de dia del calendario Juliano
		/// </summary>
		/// <param name="pDia">Cantidad de dias</param>
		/// <exception cref="ArgumentOutOfRangeException"> Arroja excepcion si el valor de pDia es menor al minimo permitido (BASE_JULIANA)</exception>
		public Fecha(long pDia)
		{
			if (pDia < BASE_JULIANA)
			{
				throw new System.ArgumentOutOfRangeException("pDia", pDia, "El numero de dias no puede ser menor a " + BASE_JULIANA.ToString() + " (por compatibilidad)");
			}

			if (pDia > TOPE_JULIANA)
			{
				throw new System.ArgumentOutOfRangeException("pDia", pDia, "El numero de dias no puede ser mayor a " + TOPE_JULIANA.ToString() + " (por compatibilidad)");
			}

			int[] diaMesAño = new int[3];

			diaMesAño = Fecha.ToGregoriano(pDia);

			this.iDia = diaMesAño[0];
			this.iMes = diaMesAño[1];
			this.iAño = diaMesAño[2];
			this.iDiaJuliano = pDia;

		}
		#endregion
		#region Fecha - Propiedades
		/// <summary>
		/// Propiedad Dia, solo lectura
		/// </summary>
		public int Dia
		{
			get { return this.iDia; }
		}
		
        /// <summary>
		/// Propiedad Mes, solo lectura
		/// </summary>
		public int Mes
		{
			get { return this.iMes; }
		}
		
        /// <summary>
		/// Propiedad Año, solo lectura
		/// </summary>
		public int Año
		{
			get	{ return this.iAño; }
		}
		
        public long DiaJuliano
        {
            get { return this.iDiaJuliano; }
        }
        /// <summary>
		/// Propiedad Bisiesto, nos permite saber si el año de la instancia es bisiesto
		/// </summary>
		/// <returns>Verdadero si el año de la instancia es bisiesto</returns>
		public bool Bisiesto
		{
			get { return Fecha.EsBisiesto(this.Año); }
		}
		
        /// <summary>
		/// Propiedad DiasMesAñoActual, Nos permite conocer el numero de dias que posee el mes y el año de la instancia 
		/// </summary>
		public int DiasMesAñoActual
		{
			get { return Fecha.DiasDelMesAño(this.Mes, this.Año); }
		}
		
        /// <summary>
		/// Propiedad DiaSemanaActual, Nos permite conocer el nombre del dia de la semana de la instancia
		/// </summary>
		public String DiaSemanaActual
		{
			get { return Fecha.DiaSemanaFecha(this.Dia, this.Mes, this.Año); }
		}

		/// <summary>
		/// Pripiedad NombreMesActual, nos permite conocer el nombre del mes de la instancia
		/// </summary>
		public String NombreMesActual
		{
			get { return Fecha.NombreMes(this.Mes); }
		}

		#endregion
		#region Fecha - Metodos Estaticos 
		/// <summary>
		/// Permite determinar si un año es bisiesto
		/// </summary>
		/// <param name="pAño">Año para el cual se desea conocer si es bisiesto</param>
		/// <returns>Verdadero si es bisiesto, falso si no</returns>
		public static bool EsBisiesto(int pAño)
		{
			/*	Si pAño es divisible por 4 y no es divisible por 100 
				O          Es divisible por 400, entonces es bisiesto */
			return (pAño % 4 == 0 && pAño % 100 != 0 || pAño % 400 == 0);
		}

		/// <summary>
		/// Permite determinar la cantidad de dias que tiene un mes en un año determinado
		/// </summary>
		/// <param name="pMes">Mes para el cual se desean conocer los dias maximos</param>
		/// <param name="pAño">Año, para considerar los años bisiestos</param>
		/// <returns>Cantidad de dias del mes y año</returns>
		public static int DiasDelMesAño (int pMes, int pAño)
		{
			// Si el mes es febrero(2) y el Año es bisiesto, los dias son 29; si no se consulta en el array de constantes 
			return (pMes == 2 && Fecha.EsBisiesto(pAño)) ? 29 : DIAS_MESES[pMes - 1]; 
        }

		/// <summary>
		/// Determina el nombre del dia de la semana de una fecha
		/// </summary>
		/// <param name="pDia">Numero de Dia</param>
		/// <param name="pMes">Numero de Mes</param>
		/// <param name="pAño">Numero de Año</param>
		/// <returns>Nombre del dia de la semana para los valores dia/mes/año</returns>
		public static String DiaSemanaFecha(int pDia, int pMes, int pAño)
		{
			int resultado = 0;

			//El metodo aplicado en este algoritmo fue extraido de la siguiente pagina web: http://gaussianos.com/como-calcular-que-dia-de-la-semana-fue/
            //Basicamente genera un coeficiente que determina que dia de la semana fue una fecha, a partir de distitas caracteristicas de la fecha
            
            //En primer lugar verifica a que siglo pertenece el año de la fecha, sumando un determinado numero segun corresponda
			if (1700 <= pAño && pAño <= 1799)
			{
				resultado = 5;
			}
			else if (1800 <= pAño && pAño <= 1899)
			{
				resultado = 3;
			}
			else if (1900 <= pAño && pAño <= 1999)
			{
				resultado = 1;
			}
			else if (2000 <= pAño && pAño <= 2099)
			{
				resultado = 0;
			}
			else if (2100 <= pAño && pAño <= 2199)
			{
				resultado = -2;
			}
			else if (2200 <= pAño && pAño <= 2299)
			{
				resultado = -4;
			}


            //Tomamos los dos últimos dígitos del año en cuestión y a ese número le sumamos un cuarto del mismo (despreciando los decimales)
            //Para obtener los ultimos dos digitos del año, hallamos modulo 100
			resultado += ((pAño % 100) + (pAño % 100) / 4);

			//En caso de que el año sea bisiesta, se resta 1
			resultado += Fecha.EsBisiesto(pAño) ? -1 : 0;

			//Se suma un valor correspondiente al mes de la fecha, almacenado en COEFICIENTES_MESES
			resultado += COEFICIENTES_MESES[pMes - 1];

			//Se suma el dia de la fecha
			resultado += pDia;

			//A la suma final le hallamos modulo 7 y el resultado final será la posicion del arreglo NOMBRES_DIAS correspondiente al dia de la fecha
			return NOMBRES_DIAS[resultado % 7];
		}

		/// <summary>
		/// Devuelve el nombre del mes para el numero correspondiente
		/// </summary>
		/// <param name="pMes"></param>
		/// <returns>Nombre del Mes</returns>
		public static String NombreMes(int pMes)
		{
			return NOMBRES_MESES[pMes - 1];
		}

		/// <summary>
		/// Convierte una fecha del calendario Gregoriano al Juliano
		/// </summary>
		/// <param name="pDia">Dia</param>
		/// <param name="pMes">Mes</param>
		/// <param name="pAño">Año</param>
		/// <returns>Dias del calendario Juliano equivalentes a pDia/pMes/pAño</returns>
		public static long ToJuliano (int pDia, int pMes, int pAño)
		{
			int dia = pDia;
			int mes = pMes;
			int año = pAño;

			if (mes < 3)
			{
				mes = mes + 12;
				año--;
			}

			return dia + (153 * mes - 457) / 5 + 365 * año + (año / 4) - (año / 100) + (año / 400) + 1721119;
		}

		/// <summary>
		/// Convierte una fecha del calendario Juliano a Gregoriano
		/// </summary>
		/// <param name="pUnaFecha">Dias en el calendario Juliano</param>
		/// <returns>[Dia, Mes, Año] equivalentes a pUnaFecha en el calendario Juliano </returns>
		public static int[] ToGregoriano (long pUnaFecha)
		{
			int[] resultado = new int[3];

			long L = pUnaFecha + 68569;
			long N = (long)((4 * L) / 146097);
			L = L - ((long)((146097 * N + 3) / 4));
			long I = (long)((4000 * (L + 1) / 1461001));
			L = L - (long)((1461 * I) / 4) + 31;
			long J = (long)((80 * L) / 2447);
			resultado[0] = (int)(L - (long)((2447 * J) / 80));
			L = (long)(J / 11);
			resultado[1] = (int)(J + 2 - 12 * L);
			resultado[2] = (int)(100 * (N - 49) + I + L);

			return resultado;
		}

		#endregion
		#region Fecha - Aritmetica de Fechas
		/// <summary>
		/// Permite agregar dias a una instancia de Fecha.
		/// </summary>
		/// <param name="pDias">Cantidad de dias a Agregar, mayor igual a 1</param>
		/// <returns>Una nueva Fecha pDias en el futuro a partir de la fecha</returns>
		/// <exception cref="ArgumentOutOfRangeException"> Arroja excepcion si </exception>
		public Fecha AgregarDias(int pDias)
		{
			if (pDias < 1)
			{
				throw new System.ArgumentOutOfRangeException("pDias", pDias, "El numero de dias a agregar debe ser mayor igual a 1");
			}

            // Retorno una nueva fecha cuyos dias julianos sean la suma de pDias y DiaJuliano, de manera de simplificar la operacion
			return new Fecha(this.DiaJuliano + pDias);
		}

		/// <summary>
		/// Permite agregar meses a una instancia de Fecha.
		/// </summary>
		/// <param name="pMeses">Cantidad de meses a Agregar, mayor igual a 1</param>
		/// <returns>Una nueva Fecha pMeses en el futuro a partir de la fecha</returns>
		/// <exception cref="ArgumentOutOfRangeException"> Arroja excepcion si pMes es menor a 1 </exception>
		public Fecha AgregarMeses(int pMeses)
		{
			if (pMeses < 1)
			{
				throw new System.ArgumentOutOfRangeException("pMeses", pMeses, "El numero de meses a agregar debe ser mayor igual a 1");
			}
			if (pMeses > 1)
			{   // Si hay que agregar mas de un mes			

				Fecha auxFecha = this.AgregarMeses(1);			// Aumento en uno el mes
				return auxFecha.AgregarMeses(pMeses - 1);       // Llamo recursivamente a AgregarMeses() con los meses sobrantes
			}
			else
			{   // Si solo hay que agregar un mes
			
				int dias = DiasMesAñoActual;
				return this.AgregarDias(dias);
			}
		}

		/// <summary>
		/// Permite agregar años a una instancia de Fecha. 
		/// </summary>
		/// <param name="pAño">Cantidad de meses a Agregar, mayor igual a 1</param>
		/// <returns>Una nueva Fecha pAños en el futuro a partir de la fecha</returns>
		/// <exception cref="ArgumentOutOfRangeException"> Arroja excepcion si pAño es menor a 1</exception>
		public Fecha AgregarAño (int pAño)
		{
			if (pAño < 1)
			{
				throw new System.ArgumentOutOfRangeException("pAño", pAño, "El numero de años a agregar debe ser mayor igual a 1");
			}

			long acuDias = 0;
            
            //  Realizo un ciclo por cada año, sumando la cantidad de dias correspondientes a cada uno
			for (int i = Año; i < Año + pAño; i++)
			{
				acuDias += Fecha.EsBisiesto(i) ? 366 : 365;		// Si el año es bisiesto, sumo 366 dias
			}

			return new Fecha(this.DiaJuliano + acuDias);
		}

		/// <summary>
		/// Permite calcular la diferencia en dias entre la instancia y pOtraFecha
		/// </summary>
		/// <param name="pOtraFecha">Fecha con la que se desea calcular la diferencia</param>
		/// <returns>Diferencia en dias entre las dos fechas</returns>
		public int RestarFecha (Fecha pOtraFecha)
		{
			return Math.Abs((int)(DiaJuliano - pOtraFecha.DiaJuliano));		
		}

		#endregion
		#region Fecha - Metodos Sobrecargados (Equals, ToString, GetHashCode)
		/// <summary>
		/// Sobre carga del metodo ToString()
		/// </summary>
		/// <returns>Representacion como cadena de texto de la fecha, en formato dd/mm/aaaa</returns>
		public override string ToString()
		{
			return "G: " + Dia.ToString() + "/" + Mes.ToString() + "/" + Año.ToString() + " \tJ: " + DiaJuliano.ToString() ;
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
		/// Metodo Equals() para objetos de la clase Fecha
		/// </summary>
		/// <param name="pFecha">Fecha con la que se desea comparar igualdad</param>
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
		/// Sobrecarga del metodo GetHashCode().
		/// Mas informacion: http://www.loganfranken.com/blog/692/overriding-equals-in-c-part-2/
		/// </summary>
		/// <returns>Integer HashCode</returns>
		public override int GetHashCode()
		{
			// El HashCode debe ser rapido de calcular y con pocas colisiones
			// Buscamos grandes productos semi-aleatorios, por lo tanto somos concientes de que un overflow de integers es posible, el cual no nos afecta
			unchecked
			{
				// Un gran numero primo disminuye las colisiones en grandes conjuntos de objetos
				const int HashingBase = (int)2166136261; //Primo01, casteado a int
				const int HashingMultiplier = 16777619; //Primo02

				int hash = HashingBase;
				//Utilizamos cada propiedad de nuestro objeto, si dicha propiedad es nula, el resultado es 0
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.Dia) ? this.Dia.GetHashCode() : 0);
				//Sucesivamente vamos acumulando los resultados
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.Mes) ? this.Mes.GetHashCode() : 0);
				//Por ultimo en vez de usar +, usamos el operador XOR ^ para obtener una implementacion mas performante
				hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.Año) ? this.Año.GetHashCode() : 0);

                return hash;
			}
		}

		#endregion
		#region Fecha - Metodos de Comparacion
		/// <summary>
		/// Implementa la logica para verificar igualdad de fechas.
		/// Metodo base (junto con EsMayor) de todos los otros metodos de comparacion y operadores relacionales
		/// </summary>
		/// <param name="pOtraFecha">Fecha con la cual realizar la comparacion</param>
		/// <returns>Verdadero si los valores de Dia, Mes y Año coinciden</returns>
		private bool EsIgual(Fecha pOtraFecha)
		{
			return (this.DiaJuliano ==pOtraFecha.DiaJuliano);
		}

		/// <summary>
		/// Implementa la logica para verificar si una fecha es mayor que otra
		/// Metodo base (junto con EsIgual) de todos los otros metodos de comparacion y operadores relacionales
		/// </summary>
		/// <param name="pOtraFecha">Fecha con la cual realizar la comparacion</param>
		/// <returns></returns>
		private bool EsMayor(Fecha pOtraFecha)
		{
			return this.DiaJuliano > pOtraFecha.DiaJuliano;
		}

		/// <summary>
		/// Implementa la logica para verificar si una fecha es menor que otra
		/// </summary>
		/// <param name="pOtraFecha">Fecha con la cual realizar la comparacion</param>
		/// <returns></returns>
		private bool EsMenor(Fecha pOtraFecha)
		{
			return !(this.EsMayor(pOtraFecha) || this.EsIgual(pOtraFecha));
		}

		/// <summary>
		/// Implementa la logica para verificar si una fecha es mayor o igual que otra
		/// </summary>
		/// <param name="pOtraFecha">Fecha con la cual realizar la comparacion</param>
		/// <returns></returns>
		private bool EsMayorIgual(Fecha pOtraFecha)
		{
			return (this.EsIgual(pOtraFecha) || this.EsMayor(pOtraFecha));
		}

		/// <summary>
		/// Implementa la logica para verificar si una fecha es menor o igual que otra
		/// </summary>
		/// <param name="pOtraFecha">Fecha con la cual realizar la comparacion</param>
		/// <returns></returns>
		private bool EsMenorIgual(Fecha pOtraFecha)
		{
			return !this.EsMayor(pOtraFecha);
		}

		#endregion
		#region Fecha - Operadores
		/// <summary>
		/// Operador De Igualdad
		/// </summary>
		/// <param name="pA">Primera fecha</param>
		/// <param name="pB">Segunda Fecha</param>
		/// <returns>Verdadero si los valores de Dia, Mes y Año coinciden</returns>
		public static bool operator ==(Fecha pA, Fecha pB)
		{
			return pA.EsIgual(pB);
		}

		/// <summary>
		/// Operador de Desigualdad
		/// </summary>
		/// <param name="pA">Primera fecha</param>
		/// <param name="pB">Segunda Fecha</param>
		/// <returns>Verdader si los valores de Dia, Mes o Año no son iguales entre si</returns>
		public static bool operator !=(Fecha pA, Fecha pB)
		{
			return !(pA == pB);
		}

		/// <summary>
		/// Operador Mayor
		/// </summary>
		/// <param name="pA">Primera fecha</param>
		/// <param name="pB">Segunda Fecha</param>
		/// <returns>Verdadero si pA es posterior en el calendario a pB</returns>
		public static bool operator >(Fecha pA, Fecha pB)
		{
			return pA.EsMayor(pB);
		}

		/// <summary>
		/// Operador Menor
		/// </summary>
		/// <param name="pA">Primera fecha</param>
		/// <param name="pB">Segunda Fecha</param>
		/// <returns>Verdadero si pA es anterior en el calendario a pB</returns>
		public static bool operator <(Fecha pA, Fecha pB)
		{
			return pA.EsMenor(pB);
		}

		/// <summary>
		/// Operador Mayor-Igual
		/// </summary>
		/// <param name="pA">Primera fecha</param>
		/// <param name="pB">Segunda Fecha</param>
		/// <returns>Verdadero si pA es posterior en el calendario a pB, o si pA es igual a pB</returns>
		public static bool operator >=(Fecha pA, Fecha pB)
		{
			return pA.EsMayorIgual(pB);
		}

		/// <summary>
		/// Operador Menor-Igual
		/// </summary>
		/// <param name="pA">Primera fecha</param>
		/// <param name="pB">Segunda Fecha</param>
		/// <returns>Verdadero si pA es anterior en el calendario a pB, o si pA es igual a pB</returns>
		public static bool operator <=(Fecha pA, Fecha pB)
		{
			return pA.EsMenorIgual(pB);
		}

		/// <summary>
		/// Operador Suma de Dias
		/// </summary>
		/// <param name="pA">Una Fecha</param>
		/// <param name="iB">Cantidad de Dias a Agregar</param>
		/// <returns>Una Fecha iB dias mas en el futuro que pA</returns>
		public static Fecha operator +(Fecha pA, int iB)
		{
			return pA.AgregarDias(iB);
		}

		/// <summary>
		/// Operador Suma de Dias
		/// </summary>
		/// <param name="iB">Cantidad de Dias a Agregar</param>
		/// <param name="pA">Una Fecha</param>
		/// <returns>Una Fecha iB dias mas en el futuro que pA</returns>
		public static Fecha operator +(int iB, Fecha pA)
		{
			return pA + iB;
		}

		/// <summary>
		/// Operador diferencia de Fechas
		/// </summary>
		/// <param name="pA">Primera fecha</param>
		/// <param name="pB">Segunda fecha</param>
		/// <returns>Diferencia en dias entre ambas fechas</returns>
		public static int operator -(Fecha pA, Fecha pB)
		{
			return pA.RestarFecha(pB);
		}

		#endregion
	}
}
