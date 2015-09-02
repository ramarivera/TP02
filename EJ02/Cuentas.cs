using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
	class Cuentas
	{
		private Cuenta iCuentaEnDolares;
		private Cuenta iCuentaEnPesos;

		public Cuenta CuentaEnDolares
		{
			get { return this.iCuentaEnDolares; }
			private set { this.iCuentaEnDolares = value; }
		}

		public Cuenta CuentaEnPesos
		{
			get { return this.iCuentaEnPesos; }
			private set { this.iCuentaEnPesos = value;  }
		}

		public Cuentas()
		{
			Moneda dolar = new Moneda("USD", "Dolar", "U$S");
			Moneda peso = new Moneda("ARS", "Peso Argentino", "$");
			CuentaEnDolares = new Cuenta(dolar);
			CuentaEnPesos = new Cuenta(peso);
		}
	}
}
