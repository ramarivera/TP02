using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Representa un auto
    /// </summary>
    class Auto
    {
        /// <summary>
        /// Representa el motor del auto
        /// </summary>
        private Motor iMotor;
        /// <summary>
        /// Representa la marca del auto
        /// </summary>
        private string iMarca;
        /// <summary>
        /// Representa el modelo del auto
        /// </summary>
        private string iModelo;
        /// <summary>
        /// Representa el monto total de las averias del auto
        /// </summary>
        private double iPrecioAverias;

        /// <summary>
        /// Propiedad Marca, solo lectura
        /// </summary>
        public string Marca
        {
            get { return this.iMarca; }
            private set { this.iMarca = value; }
        }

        /// <summary>
        /// Propiedad Modelo, solo lectura
        /// </summary>
        public string Modelo
        {
            get { return this.iModelo; }
            private set { this.iModelo = value; }
        }

        /// <summary>
        /// Propiedad Motor, solo lectura
        /// </summary>
        public Motor Motor
        {
            get { return this.iMotor; }
            private set { this.iMotor = value; }
        }

        /// <summary>
        /// Propiedad PrecioAverias, solo lectura
        /// </summary>
        public double PrecioAverias
        {
            get { return this.iPrecioAverias; }
            private set { this.iPrecioAverias = value; }
        }

        /// <summary>
        /// Constructor de la clase Auto
        /// </summary>
        /// <param name="pMarca">Marca del auto</param>
        /// <param name="pModelo">Modelo del auto</param>
        /// <param name="pCv">Caballos vapor del auto</param>
        public Auto(string pMarca, string pModelo, int pCv)
        {
            this.Marca = pMarca;
            this.Modelo = pModelo;
            this.Motor = new Motor(pCv);
        }

        /// <summary>
        /// Permite sumar una nueva averia al auto
        /// </summary>
        /// <param name="pPrecioAveria"></param>
        public void SumarAveria(double pPrecioAveria)
        {
            this.PrecioAverias += pPrecioAveria;
        }


    }
}
