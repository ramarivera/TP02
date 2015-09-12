using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Representa un garage de autos
    /// </summary>
    class Garage
    {
        /// <summary>
        /// Reprensenta un auto que esta en el garage
        /// </summary>
        private Auto iAuto;
        /// <summary>
        /// Representa la cantidad de autos atendidos hasta el momento
        /// </summary>
        private int iNumeroAutosAtendidos;

        /// <summary>
        /// Propiedad Auto, solo lectura
        /// </summary>
        public Auto Auto
        {
            get { return this.iAuto; }
            private set { this.iAuto = value; }
        }

        /// <summary>
        /// Propiedad NumeroAutosAtendidos, solo lectura
        /// </summary>
        public int NumeroAutosAtendidos
        {
            get { return this.iNumeroAutosAtendidos; }
            private set { this.iNumeroAutosAtendidos = value; }
        }

        /// <summary>
        /// Acepta un auto a ingresar al garage en caso de que ya no haya uno
        /// </summary>
        /// <param name="pAuto">Auto a ingresar en el garage</param>
        /// <returns>Devuelve un booleano que indica si se acepto el auto o no </returns>
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

        /// <summary>
        /// Agrega una averia al auto en el garage
        /// </summary>
        /// <param name="pPrecioAveria">Monto de la nueva averia</param>
        /// <param name="pDescripcionAveria">Descripcion de la nueva averia</param>
        public void IncorporarAveria(double pPrecioAveria, string pDescripcionAveria)
        {
            this.Auto.SumarAveria(pPrecioAveria);
            if (pDescripcionAveria == "aceite")
            {
                this.Auto.Motor.AgregarLitrosAceite(10);
            }
        }

        /// <summary>
        /// Determina si actualmente hay un auto en el garage
        /// </summary>
        /// <returns>Devuelve un booleano que es verdadero si no hay un auto en el garage</returns>
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

        /// <summary>
        /// Quita el auto que se encuentra en el garage
        /// </summary>
        /// <param name="pAuto">Auto a quitar del garage</param>
        public void QuitarAuto(Auto pAuto)
        {
            this.Auto = null;
        }


    }
}
