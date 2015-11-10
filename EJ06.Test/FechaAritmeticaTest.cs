using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;

namespace EJ06.Test
{
    [TestClass]
    public class FechaAritmeticaTest
    {

        [TestMethod]
        public void AgregarDias_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            long diasJulianos = Fecha.ToJuliano(fecha.Dia, fecha.Mes, fecha.Año);
            Fecha fechaNueva = new Fecha(18, 6, 2015);

            Assert.AreEqual(fechaNueva, fecha.AgregarDias(10));
        }

        [TestMethod]
        public void AgregarDiasPasandoAOtroMes_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaNueva = new Fecha(8, 7, 2015);

            Assert.AreEqual(fechaNueva, fecha.AgregarDias(30));
        }

        [TestMethod]
        public void AgregarMeses_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaNueva = new Fecha(8, 9, 2015);

            Assert.AreEqual(fechaNueva, fecha.AgregarMeses(3));
        }

        [TestMethod]
        public void AgregarMesesPasandoAOtroAño_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaNueva = new Fecha(8, 6, 2016);

            Assert.AreEqual(fechaNueva, fecha.AgregarMeses(12));
        }

        [TestMethod]
        public void AgregarAños_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
            Fecha fechaNueva = new Fecha(8, 6, 2017);

            Assert.AreEqual(fechaNueva, fecha.AgregarAño(2));
        }

        [TestMethod]
        public void RestarFechas_Test()
        {
            Fecha fecha1 = new Fecha(8, 6, 2015);
            Fecha fecha2 = new Fecha(8, 3, 2015);

            Assert.AreEqual(92,fecha1.RestarFecha(fecha2));
        }
    }
}
