using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;

namespace EJ06.Test
{
    [TestClass]
    public class FechaMetodosEstaticosTest
    {
        [TestMethod]
        public void EsBisiesto_IsTrue()
        {
            Fecha fecha = new Fecha(8, 6, 2012);

            Assert.IsTrue(Fecha.EsBisiesto(fecha.Año));
        }

        [TestMethod]
        public void DiasDelMesAño_MesJunio()
        {
            Fecha fecha = new Fecha(8, 6, 2012);

            int dias = Fecha.DiasDelMesAño(fecha.Mes, fecha.Año);

            Assert.AreEqual(30, dias);
        }

        [TestMethod]
        public void DiasDelMesAño_FebreroBisiesto()
        {
            Fecha fecha = new Fecha(8, 2, 2012);

            int dias = Fecha.DiasDelMesAño(fecha.Mes, fecha.Año);

            Assert.AreEqual(29, dias);
        }

        [TestMethod]
        public void DiaSemanaFecha_Lunes()
        {
            Fecha fecha = new Fecha(8, 6, 2015);

            string nombre = Fecha.DiaSemanaFecha(fecha.Dia, fecha.Mes, fecha.Año);

            Assert.AreEqual("Lunes", nombre);
        }

        [TestMethod]
        public void NombreMes_Junio()
        {
            Fecha fecha = new Fecha(8, 6, 2015);

            string nombre = Fecha.NombreMes(fecha.Mes);

            Assert.AreEqual("Junio", nombre);
        }

        [TestMethod]
        public void ToJuliano_AreEqual()
        {
            Fecha fecha = new Fecha(8, 6, 2015);

            long fechaJuliana = Fecha.ToJuliano(fecha.Dia, fecha.Mes, fecha.Año);

            Assert.AreEqual(2457182, fechaJuliana);
        }

        [TestMethod]
        public void ToGregoriano_AreEqual()
        {
            long diasJuliano = 2457182;

            Fecha fecha = new Fecha(diasJuliano);
            int[] arreglo = Fecha.ToGregoriano(diasJuliano);
            Fecha fecha2 = new Fecha(arreglo[0], arreglo[1], arreglo[2]);
            
            Assert.AreEqual(fecha,fecha2);
        }

    }
}
