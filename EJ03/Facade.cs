using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Clase Fachada del ejercicio03, abstrae implementaciones de las clases Garage, Auto y Motor
    /// </summary>
    class Facade
    {
        /// <summary>
        /// Permite crear un nuevo auto
        /// </summary>
        /// <param name="pMarca">Marca del auto</param>
        /// <param name="pModelo">Modelo del auto</param>
        /// <param name="pCv">Caballos vapor del auto</param>
        /// <returns>Devuelve el auto que se ha creado</returns>
        public Auto CrearAuto(string pMarca, string pModelo, int pCv)
        {
            return new Auto(pMarca,pModelo,pCv);
        }

        /// <summary>
        /// Permite agregar una averia al auto que está en el garage
        /// </summary>
        /// <param name="pGarage">Garage donde se encuentra el auto</param>
        /// <param name="pPrecioAveria">Monto de la averia a agregar</param>
        /// <param name="pDescripcionAveria">Descripcion de la averia a agregar</param>
        public void AgregarAveria(Garage pGarage,double pPrecioAveria, string pDescripcionAveria)
        {
            pGarage.IncorporarAveria(pPrecioAveria, pDescripcionAveria);
        }

        /// <summary>
        /// Permite mostrar la informacion del auto que esta en el garage
        /// </summary>
        /// <param name="pGarage">Garage donde se encuentra el auto</param>
        /// <returns>Devuelve la instancia del auto que esta en el garage</returns>
        public Auto MostrarAuto(Garage pGarage)
        {
            return pGarage.Auto;
        }
    }
}
