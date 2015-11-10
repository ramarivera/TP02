using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;

namespace EJ06.Test
{
    [TestClass]
    public class FechaMetodosEstaticosTest
    {
        [TestMethod]
        public void AñoBisiesto_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2012);

            Assert.IsTrue(Fecha.EsBisiesto(fecha.Año));
        }

        [TestMethod]
        public void CantidadDiasMesAñoNormal_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2012);

            Assert.AreEqual(30, Fecha.DiasDelMesAño(fecha.Mes, fecha.Año));
        }

        [TestMethod]
        public void CantidadDiasMesAñoBisiesto_Test()
        {
            Fecha fecha = new Fecha(8, 2, 2012);

            Assert.AreEqual(29, Fecha.DiasDelMesAño(fecha.Mes, fecha.Año));
        }

        [TestMethod]
        public void NombreDiaSemana_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2015);

            Assert.AreEqual("Lunes", Fecha.DiaSemanaFecha(fecha.Dia,fecha.Mes,fecha.Año));
        }

        [TestMethod]
        public void NombreMes_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2015);
           
            Assert.AreEqual("Junio", Fecha.NombreMes(fecha.Mes));
        }

        [TestMethod]
        public void ToJuliano_Test()
        {
            Fecha fecha = new Fecha(8, 6, 2015);

            Assert.AreEqual(2457182, Fecha.ToJuliano(fecha.Dia,fecha.Mes,fecha.Año));
        }

        [TestMethod]
        public void ToGregoriano_Test()
        {
            long diasJuliano = 2457182;

            Fecha fecha = new Fecha(diasJuliano);
            int[] arreglo = Fecha.ToGregoriano(diasJuliano);
            Fecha fecha2 = new Fecha(arreglo[0], arreglo[1], arreglo[2]);
            
            Assert.AreEqual(fecha,fecha2);
        }

    }
}
