using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class Cuenta
    {
        private Moneda iMoneda;
        private double iSaldo;

		public double Saldo
		{
			get { return this.iSaldo; }
			private set { this.iSaldo = value; }
		}

		public Moneda Moneda
		{
			get { return this.iMoneda; }
			private set { this.iMoneda = value; }
		}
		
        public Cuenta(double pSaldoInicial, Moneda pMoneda)
		{
			Saldo = pSaldoInicial;
			Moneda = pMoneda;
		}
		public Cuenta(Moneda pMoneda) : this(0, pMoneda) { }

		public void AcreditarSaldo (double pSaldo )
		{
			Saldo += pSaldo;
		}

		public bool DebitarSaldo (double pSaldo )
		{
			if (Saldo < pSaldo)
			{
				return false;
			}
			else
			{
				Saldo -= pSaldo;
				return true;
			}
		}
    }
}
