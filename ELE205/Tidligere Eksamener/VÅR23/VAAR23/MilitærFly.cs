namespace VAAR23;

public class MilitærFly : Fly
{
    private string våpenklasse;
    private Lokasjoner lokasjon;


    public MilitærFly(string typebetegnelse, int produksjonsaar, string våpenklasse, Lokasjoner lokasjon) 
    : base(typebetegnelse, produksjonsaar)
    {
        Våpenklasse = våpenklasse;
        Lokasjon = lokasjon; 
    }

    public string Våpenklasse
    {
        get { return våpenklasse; }
        private set {this.våpenklasse = value; }
    }

    public Lokasjoner Lokasjon
    {
        get { return lokasjon; }
        set { lokasjon = value; }
    }

    public new void SkrivUt()
    {
        Console.WriteLine($"Typebetegnelse: {Typebetegnelse}");
        Console.WriteLine($"Produksjonsår: {Produksjonsaar}");
        Console.WriteLine($"Våpenklasse: {Våpenklasse}");
        Console.WriteLine($"Lokasjon: {Lokasjon}");
    }

     public void FlyttTil(Lokasjoner nyLokasjon)
    {
        lokasjon = nyLokasjon; 
    }


    /*
    public Lokasjon Lokasjon
    {
        get { return lokasjon; }
        set
        {
            if (Enum.IsDefined(typeof(Lokasjon), value))  // Validerer at verdi er gyldig
            {
                lokasjon = value;
            }
            else
            {
                throw new ArgumentException("Ugyldig lokasjon");
            }
        }
    }
    */

}
