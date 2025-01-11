namespace Oppgave4;

public class Elev : Person
{
    int matteKarakter;
    int norskKarater; 
    int naturfagsKarakter;

    public Elev() : base() 
    {

    }

    public Elev(string fornavn, string etternavn, int alder, int matteKarakter, int norskKarater, int naturfagsKarakter) : base(fornavn, etternavn, alder)
    {
        MatteKarater = matteKarakter;
        NorskKarater = norskKarater;
        NaturfagsKarakter = naturfagsKarakter;
    }

    public int MatteKarater
    {
        get {return matteKarakter; }
        set 
        {
            if (value >= 1 && value <= 6) matteKarakter = value;
            else throw new ArgumentException("Karakterer må være mellom 1 og 6"); 
        }
    }

    public int NorskKarater
    {
        get { return norskKarater; }
        set 
        {
            if (value >= 1 && value <= 6) norskKarater = value;
            else throw new ArgumentException("Karakterer må være mellom 1 og 6"); 
        }
    }

    public int NaturfagsKarakter
    {
        get { return naturfagsKarakter; }
        set
        {
            if (value >= 1 && value <= 6) naturfagsKarakter = value;
            else throw new ArgumentException("Karakterer må være mellom 1 og 6"); 
        }
    }

    public double Gjennomsnitt
    {
        get 
        {
            return (MatteKarater + NorskKarater + NaturfagsKarakter) / 3.0;
        }
    }

}

public class Sammenligner : IComparer<Elev>
{
    public int Compare(Elev? x, Elev? y)
    {
        return x.Gjennomsnitt.CompareTo(y.Gjennomsnitt); 
    }
}

