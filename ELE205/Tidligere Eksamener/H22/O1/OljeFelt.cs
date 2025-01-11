using System.Numerics;

namespace O1;

public class OljeFelt : IProduksjonsFelt
{
    private string feltNavn;
    private string eier;
    private int oljeIgjen;
    enum Land {Norge, Danmark, Storbritannia}

    static double oljepris;

    public OljeFelt(string feltNavn) 
    {
        FeltNavn = feltNavn; 
    }

    public OljeFelt(string feltNavn, string eier, int oljeIgjen)
    {
        FeltNavn = feltNavn;
        Eier = eier;
        OljeIgjen = oljeIgjen;
    }

    public double ØkonomiskFeltVerdi() 
    {
        
        double verdi = Oljepris * OljeIgjen; 
        return verdi; 
        // return Oljepris * OljeIgjen;
    }

    public string FeltNavn
    {
        get { return feltNavn; }
        set 
        { 
            if(value == string.Empty) 
            {
                throw new ArgumentException("Feltnavnet kan ikke være blankt!"); 
            }
            else 
            {
                feltNavn = value; 
            }
        }

    }

    public bool SammeEierSom(OljeFelt? other) 
    {
        return this.Eier == other.Eier; 
    }

    public bool SammeEier(OljeFelt? x, OljeFelt? y) 
    {
        return x.Eier == y.Eier; 
    }

    public override string ToString()
    {
        return $"Feltnavn: {FeltNavn} - Eier: {Eier} - Mengde oljefat igjen: {OljeIgjen} millioner"; 
    }

    public void SkrivUtInfo()
    {
        Console.WriteLine($"Feltnavn: {FeltNavn}");
        Console.WriteLine($"Eier: {Eier}");
        Console.WriteLine($"Mengde oljefat igjen: {OljeIgjen}");
        Console.WriteLine($"Land: {Land.Norge}");
        Console.WriteLine($"Oljepris: {Oljepris}");

    }

    public static bool operator== (OljeFelt? x, OljeFelt? y)
    {
        return x.FeltNavn == y.FeltNavn; 
    }

    public static bool operator!= (OljeFelt? x, OljeFelt? y)
    {
        return x.FeltNavn != y.FeltNavn; 
    }


    public string Eier
    {
        get { return eier; }
        set { eier = value; }
    }

    public int OljeIgjen
    {
        get { return oljeIgjen; }
        private set // Ikke alle skal ha tilgang til å endre hvor mye olje som er igjen - derfor private
        {
            if(value < 0) oljeIgjen = 0;
            else oljeIgjen = value; 
        }
    }

    public double Oljepris
    {
        get { return oljepris; }
        set 
        {
            oljepris = value; 
        }
    }

}
