using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
	class Facade
	{
		public Cuentas CrearCuentas()
		{
			return new Cuentas();
		}

		public void AcreditarSaldo (Cuenta pCuenta, double pSaldo)
		{
			pCuenta.AcreditarSaldo(pSaldo);
		}

		public bool DebitarSaldo (Cuenta pCuenta, double pSaldo)
		{
			return pCuenta.DebitarSaldo(pSaldo);
		}

		string RecuperarSimbolo (Cuenta pCuenta)
		{
			return pCuenta.Moneda.Simbolo;
		}
		public string RecuperarSaldo (Cuenta pCuenta)
		{
			return this.RecuperarSimbolo(pCuenta) + " " + pCuenta.Saldo.ToString() ;
		}
	}
}
