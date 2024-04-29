using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared.Model;

namespace ordination_test
{
    [TestClass]
    public class PNTest
    {
        [TestMethod]
        public void CreatePNOrdination()
        {
            Laegemiddel laegemiddel = new Laegemiddel("Paracetamol", 1, 1.5, 2, "Styk");
            DateTime startDato = new DateTime(2024, 1, 10);
            DateTime slutDato = new DateTime(2024, 1, 12);
            double antal = 5;

            // Opret PN-ordination
            PN pnOrdination = new PN(startDato, slutDato, antal, laegemiddel);

            // Udskriv detaljer om PN-ordinationen
            Console.WriteLine($"Startdato: {pnOrdination.startDen}");
            Console.WriteLine($"Slutdato: {pnOrdination.slutDen}");
            Console.WriteLine($"Antal enheder: {pnOrdination.antalEnheder}");
            Console.WriteLine($"Lægemiddel: {pnOrdination.laegemiddel.navn}");

            // Bekræft, om PN-ordinationen er oprettet korrekt
            Assert.AreEqual(startDato, pnOrdination.startDen);
            Assert.AreEqual(slutDato, pnOrdination.slutDen);
            Assert.AreEqual(antal, pnOrdination.antalEnheder);
            Assert.AreEqual(laegemiddel, pnOrdination.laegemiddel);
        }
    }
}

