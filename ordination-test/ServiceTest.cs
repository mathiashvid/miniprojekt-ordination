namespace ordination_test;

using Microsoft.EntityFrameworkCore;

using Service;
using Data;
using shared.Model;

[TestClass]
public class ServiceTest
{
    private DataService service;

    [TestInitialize]
    public void SetupBeforeEachTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrdinationContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName: "test-database");
        var context = new OrdinationContext(optionsBuilder.Options);
        service = new DataService(context);
        service.SeedData();
    }

    [TestMethod]
    public void PatientsExist()
    {
        // Udskriv om patienterne eksisterer i systemet
        Console.WriteLine($"Findes der patienter i systemet: {service.GetPatienter() != null}");

        Assert.IsNotNull(service.GetPatienter());
    }

    [TestMethod]
    public void OpretDagligFast()
    {
        Patient patient = service.GetPatienter().First();
        Laegemiddel lm = service.GetLaegemidler().First();

        // Udskriv antallet af eksisterende daglige faste før oprettelse
        Console.WriteLine($"Antal eksisterende daglige faste før oprettelse: {service.GetDagligFaste().Count()}");

        Assert.AreEqual(1, service.GetDagligFaste().Count());

        service.OpretDagligFast(patient.PatientId, lm.LaegemiddelId,
            2, 2, 1, 0, DateTime.Now, DateTime.Now.AddDays(3));

        // Udskriv antallet af daglige faste efter oprettelse
        Console.WriteLine($"Antal eksisterende daglige faste efter oprettelse: {service.GetDagligFaste().Count()}");

        Assert.AreEqual(2, service.GetDagligFaste().Count());
    }
    [TestMethod]
    public void TestAnbefaletDosisPrDøgnLet()
    {

        {
            // Hent en patient med normal vægt jane 63,4 kg
            Patient patient = (Patient)service.GetPatienter().Where(p => p.PatientId == 1).First();
            // Hent et lægemiddel for namorl vægt 0,15
            Laegemiddel lm = service.GetLaegemidler().First();
            // Beregn den anbefalede dosis
            double anbefaletDosis = service.GetAnbefaletDosisPerDøgn(patient.PatientId, lm.LaegemiddelId);

            // Udskriv den anbefalede dosis
            Console.WriteLine($"Anbefalet dosis for patient med normal vægt: {anbefaletDosis}");

            // Tjek om den anbefalede dosis er korrekt 
            Assert.AreEqual(9.51, service.GetAnbefaletDosisPerDøgn(patient.PatientId, lm.LaegemiddelId));
        }


        {
            // Hent en patient med tung vægt  200 kg
            Patient patient = (Patient)service.GetPatienter().Where(p => p.PatientId == 2).First();
            patient.vaegt = 200;
            // Hent et lægemiddel last og first byttes rundt tror vi, når den henter lægemiddel * med 0,16
            Laegemiddel lm = service.GetLaegemidler().Last();
            // Beregn den anbefalede dosis
            double anbefaletDosis = service.GetAnbefaletDosisPerDøgn(patient.PatientId, lm.LaegemiddelId);

            // Udskriv den anbefalede dosis
            Console.WriteLine($"Anbefalet dosis for patient med høj vægt: {anbefaletDosis}");

            // Tjek om den anbefalede dosis er korrekt
            Assert.AreEqual(32, service.GetAnbefaletDosisPerDøgn(patient.PatientId, lm.LaegemiddelId));
        }

        {
            // Hent en patient med lav vægt 20 kg 0,025 * 20
            Patient patient = (Patient)service.GetPatienter().Where(p => p.PatientId == 3).First();
            patient.vaegt = 20;
            // Hent et lægemiddel for let vægt 0,025
            Laegemiddel lm = service.GetLaegemidler().First();
            // Beregn den anbefalede dosis
            double anbefaletDosis = service.GetAnbefaletDosisPerDøgn(patient.PatientId, lm.LaegemiddelId);

            // Udskriv den anbefalede dosis
            Console.WriteLine($"Anbefalet dosis for patient med lav vægt: {anbefaletDosis}");

            // Tjek om den anbefalede dosis er korrekt
            Assert.AreEqual(2, service.GetAnbefaletDosisPerDøgn(patient.PatientId, lm.LaegemiddelId));
        }
    }

}
