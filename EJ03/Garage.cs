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
            get
            {
                Auto aux = this.iAuto;
                this.iAuto = null;
                return aux;
            }
                 
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
            bool aceptado = false;
            if (this.iAuto == null)
            {
                this.iAuto = pAuto;
                aceptado = true;
            }
            return aceptado;
        }

        /// <summary>
        /// Agrega una averia al auto en el garage
        /// </summary>
        /// <param name="pPrecioAveria">Monto de la nueva averia</param>
        /// <param name="pDescripcionAveria">Descripcion de la nueva averia</param>
        public bool IncorporarAveria(double pPrecioAveria, string pDescripcionAveria)
        {
            bool incorporada = false;
            if (this.iAuto != null)
            {
                this.iAuto.SumarAveria(pPrecioAveria);
                string averia = (pDescripcionAveria.Trim()).ToUpper();
                if (averia == "ACEITE")
                {
                    this.iAuto.Motor.AgregarLitrosAceite(10);
                }
                incorporada = true;
            }
            return incorporada;
            
        }
    }
}
