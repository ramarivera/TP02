using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa en par de <see cref="Cuenta"/>, una en pesos y otra en dolares
    /// </summary>
	class Cuentas
	{
        /// <summary>
        /// Representa una cuenta en dolares
        /// </summary>
		private Cuenta iCuentaEnDolares;
        /// <summary>
        /// Representa una cuenta en pesos
        /// </summary>
		private Cuenta iCuentaEnPesos;

        /// <summary>
        /// Propiedad CuentaEnDolares, solo lectura
        /// </summary>
		public Cuenta CuentaEnDolares
		{
			get { return this.iCuentaEnDolares; }
			private set { this.iCuentaEnDolares = value; }
		}

        /// <summary>
        /// Propiedad CuentaEnPesos, solo lectura
        /// </summary>
		public Cuenta CuentaEnPesos
		{
			get { return this.iCuentaEnPesos; }
			private set { this.iCuentaEnPesos = value;  }
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Cuentas"/>
        /// </summary>
		public Cuentas()
		{
			Moneda lDolar = new Moneda("USD", "Dolar", "U$S");
			Moneda lPeso = new Moneda("ARS", "Peso Argentino", "$");
            this.CuentaEnDolares = new Cuenta(lDolar);
            this.CuentaEnPesos = new Cuenta(lPeso);
		}
	}
}
