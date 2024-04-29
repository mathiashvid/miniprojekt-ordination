using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared.Model;
using System;

namespace ordination_test
{
    [TestClass]
    public class DagligSkaevTest
    {
        [TestMethod]
        public void DoegnDosisTest()
        {
            Dosis[] doser_tc1 = {
                new Dosis(new DateTime(2024, 1, 10, 12, 0, 0), 0.5),
                new Dosis(new DateTime(2024, 1, 10, 12, 40, 0), 1),
                new Dosis(new DateTime(2024, 1, 10, 16, 0, 0), 2.5),
                new Dosis(new DateTime(2024, 1, 10, 18, 45, 0), 3)
            };

            DagligSkæv tc1 = new DagligSkæv(new DateTime(2024, 1, 10), new DateTime(2024, 1, 12), new Laegemiddel("Paracetamol", 1, 1.5, 2, "Styk"), doser_tc1);

            double doegnDosis_tc1 = tc1.doegnDosis();

            // Udskriv den beregnede døgndosis for test case 1
            Console.WriteLine($"Beregnet døgndosis for test case 1: {doegnDosis_tc1}");

            // Bekræft forventet døgndosis for test case 1
            Assert.AreEqual(7, doegnDosis_tc1); // forventet antal 7

            Dosis[] doser_tc2 = {
                new Dosis(new DateTime(2024, 1, 10, 8, 0, 0), 1),
                new Dosis(new DateTime(2024, 1, 10, 12, 0, 0), 2),
                new Dosis(new DateTime(2024, 1, 10, 16, 0, 0), 3),
                new Dosis(new DateTime(2024, 1, 10, 20, 0, 0), 4)
            };

            DagligSkæv tc2 = new DagligSkæv(new DateTime(2024, 1, 10), new DateTime(2024, 1, 12), new Laegemiddel("Paracetamol", 1, 1.5, 2, "Styk"), doser_tc2);

            double doegnDosis_tc2 = tc2.doegnDosis();

            // Udskriv den beregnede døgndosis for test case 2
            Console.WriteLine($"Beregnet døgndosis for test case 2: {doegnDosis_tc2}");

            // Bekræft forventet døgndosis for test case 2
            Assert.AreEqual(10, doegnDosis_tc2); //forventet antal 10
        }
    }
}
