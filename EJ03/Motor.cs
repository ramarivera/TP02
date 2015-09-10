using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Representa un motor de un auto
    /// </summary>
    class Motor
    {
        /// <summary>
        /// Representa los litros de aceite del motor
        /// </summary>
        private int iLitrosAceite;
        /// <summary>
        /// Representa los caballos vapor de un motor
        /// </summary>
        private int iCv;

        /// <summary>
        /// Propiedad LitrosAceite, solo lectura
        /// </summary>
        public int LitrosAceite
        {
            get { return this.iLitrosAceite; }
            private set { this.iLitrosAceite = value; }
        }

        /// <summary>
        /// Propiedad CV, solo lectura
        /// </summary>
        public int CV
        {
            get { return this.iCv; }
            private set { this.iCv = value; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pCv">Cantidad de caballos vapor del motor</param>
        public Motor(int pCv)
        {
            LitrosAceite = 0;
            CV = pCv;
        }

        /// <summary>
        /// Agregar litros de aceite al motor
        /// </summary>
        /// <param name="pLitrosDeAceite">Libros de aceite a agregar</param>
        public void AgregarLitrosAceite(int pLitrosDeAceite)
        {
            LitrosAceite = pLitrosDeAceite;
        }


    }
}
