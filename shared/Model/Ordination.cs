namespace shared.Model;

public abstract class Ordination {
    public int OrdinationId { get; set; }
    public DateTime startDen { get; set; }
    public DateTime slutDen { get; set; }
    public Laegemiddel laegemiddel { get; set; }
    
    public Ordination(Laegemiddel laegemiddel, DateTime startDen = new DateTime(), DateTime slutDen = new DateTime()) {
    	this.startDen = startDen;
    	this.slutDen = slutDen;
        this.laegemiddel = laegemiddel;
    }

    public Ordination()
    {
        this.laegemiddel = null!;
    }

    /// <summary>
    /// Antal hele dage mellem startdato og slutdato. Begge dage inklusive.
    /// </summary>
    public int antalDage()
    {
        // Beregn antallet af hele dage mellem startdato og slutdato inklusive
        TimeSpan periode = slutDen.Date - startDen.Date;
        return periode.Days + 1; // inklusive b�de start- og slutdatoen
    }


    public override String ToString() {
        return startDen.ToString();
    }

    /// <summary>
    /// Returnerer den totale dosis der er givet i den periode ordinationen er gyldig
    /// </summary>
    public abstract double samletDosis();

    /// <summary>
    /// Returnerer den gennemsnitlige dosis givet pr dag i den periode ordinationen er gyldig
    /// </summary>
    public abstract double doegnDosis();

    /// <summary>
    /// Returnerer ordinationstypen som en String
    /// </summary>
    public abstract String getType();
}
