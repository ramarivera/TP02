using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    class Facade
    {
        public Auto CrearAuto(string pMarca, string pModelo, int pCv)
        {
            return new Auto(pMarca,pModelo,pCv);
        }

        public void AgregarAveria(Garage Garage,double pPrecioAveria, string pDescripcionAveria)
        {
            Garage.IncorporarAveria(pPrecioAveria, pDescripcionAveria);
        }

        public Auto MostrarAuto(Garage Garage)
        {
            return Garage.Auto;
        }
    }
}
