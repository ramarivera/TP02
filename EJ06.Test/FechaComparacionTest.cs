using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;

namespace EJ06.Test
{
    [TestClass]
    public class FechaComparacionTest
    {
        [TestMethod]
        public void FechasIguales_IsTrueTest()
        {
            Fecha fecha1 = new Fecha(8, 6, 1994);
            Fecha fecha2 = new Fecha(8, 6, 1994);

            Assert.IsTrue(fecha1 == fecha2);
        }

        [TestMethod]
        public void FechaMayorAOtra_IsTrueTest()
        {
            Fecha fecha1 = new Fecha(8, 6, 1994);
            Fecha fecha2 = new Fecha(8, 7, 1994);

            Assert.IsTrue(fecha2 > fecha1);
        }

        [TestMethod]
        public void FechaMenosAOtra_IsTrueTest()
        {
            Fecha fecha1 = new Fecha(8, 6, 1994);
            Fecha fecha2 = new Fecha(8, 7, 1994);

            Assert.IsTrue(fecha1 < fecha2);
        }
    }
}
