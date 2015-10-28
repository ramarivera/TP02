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
        /// Garage sobre el que la fachada realizará las operaciones
        /// </summary>
        private Garage iGarage;
        /// <summary>
        /// Permite crear un nuevo auto
        /// </summary>
        /// <param name="pMarca">Marca del auto</param>
        /// <param name="pModelo">Modelo del auto</param>
        /// <param name="pCv">Caballos vapor del auto</param>
        /// <returns>Devuelve el auto que se ha creado</returns>
        
        public Facade()
        {
            this.iGarage = new Garage();
        }
        public bool AgregarAuto(string pMarca, string pModelo, int pCv)
        {
            Auto auto = new Auto(pMarca, pModelo, pCv);
            return (this.iGarage.AceptarAuto(auto));
            //return this.iGarage.AceptarAuto(new Auto(pMarca, pModelo, pCv));
        }

        /// <summary>
        /// Permite agregar una averia al auto que está en el garage
        /// </summary>
        /// <param name="pGarage">Garage donde se encuentra el auto</param>
        /// <param name="pPrecioAveria">Monto de la averia a agregar</param>
        /// <param name="pDescripcionAveria">Descripcion de la averia a agregar</param>
        public bool AgregarAveria(double pPrecioAveria, string pDescripcionAveria)
        {
            return this.iGarage.IncorporarAveria(pPrecioAveria, pDescripcionAveria);
        }

        /// <summary>
        /// Permite obtener la informacion del auto que esta en el garage
        /// </summary>
        /// <param name="pGarage">Garage donde se encuentra el auto</param>
        /// <returns>Devuelve la instancia del auto que esta en el garage</returns>
        public String[] GetDatosAuto()
        {
            String[] datos = new String[5];
            Auto lAuto = this.iGarage.Auto;
            datos[0] = lAuto.Marca;
            datos[1] = lAuto.Modelo;
            datos[2] = (lAuto.Motor.LitrosAceite).ToString();
            datos[3] = (lAuto.Motor.CV).ToString();
            datos[4] = (lAuto.PrecioAverias).ToString();
            return datos;
        }
    }
}
