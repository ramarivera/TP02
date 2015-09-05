using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    class Garage
    {
        private Auto iAuto;
        private int iNumeroAutosAtendidos;

        public Auto Auto
        {
            get { return this.iAuto; }
            private set { this.iAuto = value; }
        }

        public int NumeroAutosAtendidos
        {
            get { return this.iNumeroAutosAtendidos; }
            private set { this.iNumeroAutosAtendidos = value; }
        }

        public bool AceptarAuto(Auto pAuto)
        {
            if (this.NoHayAuto())
            {
                Auto = pAuto;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IncorporarAveria(double pPrecioAveria, string pDescripcionAveria)
        {
            this.Auto.SumarAveria(pPrecioAveria);
            if (pDescripcionAveria == "aceite")
            {
                this.Auto.Motor.AgregarLitrosAceite(10);
            }
        }

        public bool NoHayAuto()
        {
            if (this.Auto == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void QuitarAuto(Auto auto)
        {
            this.Auto = null;
        }


    }
}
