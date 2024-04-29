using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared.Model;

namespace ordination_test
{
    [TestClass]
    public class OrdinationTest
    {
        [TestMethod]
        public void AntalDageTest()
        {
            // Test case 1
            PN tc1 = new PN(new DateTime(2024, 11, 20), new DateTime(2024, 11, 23), 1, new Laegemiddel("Paracetamol", 1, 1.5, 2, "Ml"));

            int antalDage_tc1 = tc1.antalDage();

            // Udskriv antal dage for test case 1
            Console.WriteLine($"Antal dage for test case 1: {antalDage_tc1}");

            // Bekræft forventet antal dage for test case 1
            Assert.AreEqual(4, antalDage_tc1);

            // Test case 2
            PN tc2 = new PN(new DateTime(2024, 1, 10), new DateTime(2024, 1, 20), 1, new Laegemiddel("Paracetamol", 1, 1.5, 2, "Ml"));

            int antalDage_tc2 = tc2.antalDage();

            // Udskriv antal dage for test case 2
            Console.WriteLine($"Antal dage for test case 2: {antalDage_tc2}");

            // Bekræft forventet antal dage for test case 2
            Assert.AreEqual(11, antalDage_tc2);
        }
    }
}
