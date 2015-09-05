using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    class Auto
    {
        private Motor iMotor;
        private string iMarca;
        private string iModelo;
        private double iPrecioAverias;

        public string Marca
        {
            get { return this.iMarca; }
            private set { this.iMarca = value; }
        }

        public string Modelo
        {
            get { return this.iModelo; }
            private set { this.iModelo = value; }
        }

        public Motor Motor
        {
            get { return this.iMotor; }
            private set { this.iMotor = value; }
        }

        public double PrecioAverias
        {
            get { return this.iPrecioAverias; }
            private set { this.iPrecioAverias = value; }
        }

        public Auto(string pMarca, string pModelo, int pCv)
        {
            Marca = pMarca;
            Modelo = pModelo;
            Motor = new Motor(pCv);
        }

        public void SumarAveria(double pPrecioAveria)
        {
            PrecioAverias += pPrecioAveria;
        }


    }
}
