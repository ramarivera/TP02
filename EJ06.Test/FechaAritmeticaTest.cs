using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;

namespace EJ06.Test
{
    [TestClass]
    public class FechaAritmeticaTest
    {

        [TestMethod]
        public void AgregarDias_AreEqualTest()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaEsperada = new Fecha(18, 6, 2015);

            Fecha fechaResultante = fecha.AgregarDias(10);

            Assert.AreEqual(fechaEsperada, fechaResultante);
        }

        [TestMethod]
        public void AgregarDias_PasandoAOtroMes_AreEqualTest()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaEsperada = new Fecha(8, 7, 2015);

            Fecha fechaResultante = fecha.AgregarDias(30);

            Assert.AreEqual(fechaEsperada, fechaResultante);
        }

        [TestMethod]
        public void AgregarMeses_AreEqualTest()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaEsperada = new Fecha(8, 9, 2015);

            Fecha fechaResultante = fecha.AgregarMeses(3);

            Assert.AreEqual(fechaEsperada, fechaResultante);
        }

        [TestMethod]
        public void AgregarMeses_PasandoAOtroAño_AreaEqualTest()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaEsperada = new Fecha(8, 6, 2016);

            Fecha fechaResultante = fecha.AgregarMeses(12);

            Assert.AreEqual(fechaEsperada, fechaResultante);
        }

        [TestMethod]
        public void AgregarAños_AreEqualTest()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaEsperada = new Fecha(8, 6, 2017);

            Fecha fechaResultante = fecha.AgregarAño(2);

            Assert.AreEqual(fechaEsperada, fechaResultante);
        }

        [TestMethod]
        public void RestarFechas_AreEqualTest()
        {
            Fecha fecha1 = new Fecha(8, 6, 2015);
            Fecha fecha2 = new Fecha(8, 3, 2015);

            int diferencia = fecha1.RestarFecha(fecha2);

            Assert.AreEqual(92,diferencia);
        }
    }
}
