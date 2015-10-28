using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa una cuenta, en pesos o dolares, la cual tiene un saldo
    /// </summary>
    class Cuenta
    {
        /// <summary>
        /// Representa de qué moneda es la cuenta, si pesos o dolares
        /// </summary>
        private Moneda iMoneda;
        /// <summary>
        /// Reprenseta el saldo de la cuenta
        /// </summary>
        private double iSaldo;

        /// <summary>
        /// Propiedad Saldo, solo lectura
        /// </summary>
		public double Saldo
		{
			get { return this.iSaldo; }
			private set { this.iSaldo = value; }
		}

        /// <summary>
        /// Propiedad <see cref="Moneda"/>, solo lectura
        /// </summary>
		public Moneda Moneda
		{
			get { return this.iMoneda; }
			private set { this.iMoneda = value; }
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Cuenta"/>, tomando como parametros el saldo inicial y la <see cref="Moneda"/>
        /// </summary>
        /// <param name="pSaldoInicial">Saldo inicial de la cuenta</param>
        /// <param name="pMoneda">Tipo de moneda de la cuenta</param>
        public Cuenta(double pSaldoInicial, Moneda pMoneda)
		{
			this.Saldo = pSaldoInicial;
            this.Moneda = pMoneda;
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Cuenta"/>, tomando como parametro la <see cref="Moneda"/>
        /// </summary>
        /// <param name="pMoneda">Tipo de moneda de la cuenta</param>
		public Cuenta(Moneda pMoneda) : this(0, pMoneda) { }

        /// <summary>
        /// Acredita en la <see cref="Cuenta"/> el monto ingresado
        /// </summary>
        /// <param name="pSaldo">Monto a acreditar</param>
		public void AcreditarSaldo (double pSaldo )
		{
            this.Saldo += pSaldo;
		}

        /// <summary>
        /// Debita de la <see cref="Cuenta"/> el monto ingresado
        /// </summary>
        /// <param name="pSaldo">Monto de debitar</param>
        /// <returns>Devuelve un booleado que indica si se pudo debitar el saldo o no</returns>
		public bool DebitarSaldo (double pSaldo )
		{
			if (this.Saldo < pSaldo)
			{
				return false;
			}
			else
			{
                this.Saldo -= pSaldo;
				return true;
			}
		}
    }
}
