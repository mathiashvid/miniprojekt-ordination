namespace shared.Model;

public class PN : Ordination {
	public double antalEnheder { get; set; }
    public List<Dato> dates { get; set; } = new List<Dato>();

    public PN (DateTime startDen, DateTime slutDen, double antalEnheder, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen) {
		this.antalEnheder = antalEnheder;
	}

    public PN() : base(null!, new DateTime(), new DateTime()) {
    }

    /// <summary>
    /// Registrerer at der er givet en dosis på dagen givesDen
    /// Returnerer true hvis givesDen er inden for ordinationens gyldighedsperiode og datoen huskes
    /// Returner false ellers og datoen givesDen ignoreres
    /// </summary>
    public bool givDosis(Dato givesDen)
    {
        // Tjek om givesDen er inden for ordinationens gyldighedsperiode
        if (givesDen.dato >= startDen.Date && givesDen.dato <= slutDen.Date)
        {
            // Husk at datoen givesDen
            dates.Add(givesDen);
            return true;
        }
        else
        {
            // Datoen givesDen er uden for ordinationens gyldighedsperiode, ignorér den
            return false;
        }
    }


    public override double doegnDosis() {
        double sum = 0;
        if (dates.Count()>0) {
            DateTime min = dates.First().dato;
            DateTime max = dates.First().dato;

            foreach (Dato d in dates)
            {
                if (d.dato < min)
                {
                    min = d.dato;
                }
                if (d.dato > max)
                {
                    max = d.dato;
                }
            }
            int dage = (int)(max - min).TotalDays + 1;
            sum = samletDosis() / dage;
        }

        return sum;
    }


    public override double samletDosis() {
        return dates.Count() * antalEnheder;
    }

    public int getAntalGangeGivet() {
        return dates.Count();
    }

	public override String getType() {
		return "PN";
	}
}
