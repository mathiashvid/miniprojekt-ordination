using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared.Model;
using System;

namespace ordination_test
{
    [TestClass]
    public class Dagligfasttest
    {
        [TestMethod]
        public void DoegnDosisTest()
        {
            DagligFast tc1 = new DagligFast(new DateTime(2024, 1, 10), new DateTime(2024, 1, 12), new Laegemiddel("Paracetamol", 1, 1.5, 2, "Styk"), 1, 2, 2, 0);

            double doegnDosis_tc1 = tc1.doegnDosis();

            // Udskriv den beregnede døgndosis for test case 1
            Console.WriteLine($"Beregnet døgndosis for test case 1: {doegnDosis_tc1}");

            // Bekræft forventet døgndosis for test case 1
            Assert.AreEqual(5, doegnDosis_tc1); //forventet doegndosis 5

            DagligFast tc2 = new DagligFast(new DateTime(2024, 1, 10), new DateTime(2024, 1, 12), new Laegemiddel("Paracetamol", 1, 1.5, 2, "Styk"), 3, 3, 3, 3);

            double doegnDosis_tc2 = tc2.doegnDosis();

            // Udskriv den beregnede døgndosis for test case 2
            Console.WriteLine($"Beregnet døgndosis for test case 2: {doegnDosis_tc2}");

            // Bekræft forventet døgndosis for test case 2
            Assert.AreEqual(12, doegnDosis_tc2); //forventet doegndosis 12
        }

        [TestMethod]
        public void SamletDosisTest()
        {
            DagligFast tc1 = new DagligFast(
                new DateTime(2024, 1, 10),
                new DateTime(2024, 1, 12),
                new Laegemiddel("Paracetamol", 1, 1.5, 2, "Styk"),
                1, 2, 2, 0);

            double samletDosis_tc1 = tc1.samletDosis();

            // Udskriv den beregnede samlede dosis for test case 1
            Console.WriteLine($"Beregnet samlet dosis for test case 1: {samletDosis_tc1}");

            // Bekræft forventet samlet dosis for test case 1
            Assert.AreEqual(15, samletDosis_tc1); // Forventet samlet dosis: 15 enheder

            DagligFast tc2 = new DagligFast(
                new DateTime(2024, 1, 10),
                new DateTime(2024, 1, 13),
                new Laegemiddel("Paracetamol", 1, 1.5, 2, "Styk"),
                3, 3, 3, 3);

            double samletDosis_tc2 = tc2.samletDosis();

            // Udskriv den beregnede samlede dosis for test case 2
            Console.WriteLine($"Beregnet samlet dosis for test case 2: {samletDosis_tc2}");

            // Bekræft forventet samlet dosis for test case 2
            Assert.AreEqual(48, samletDosis_tc2); // Forventet samlet dosis: 48 enheder
        }
    }
}
