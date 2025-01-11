using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace O2;

public class Hund
{
    string navn;
    string eier;
    public static string konkurransetype;
    double poengsum;

    public Hund()
    {
        Poengsum = 0;    
    }

    public Hund(string _navn, string _eier)
    {
        Navn = _navn;
        Eier = _eier;
        Poengsum = 0;

    }

    public string Navn
    {
        get { return navn; }
        set {navn = value; }
    }

    public string Eier
    {
        get { return eier; }
        set{ eier = value; }
    }

    public double Poengsum
    {
        get {return poengsum;}
        set
        { 
            if(value <= 30 && value >= 0)
            {
                poengsum = value;
            }
            else 
            {
                throw new ArgumentOutOfRangeException("Poengsummen må være mellom 0 og 30!"); 
            }
        }
    }


    public void RegistrerPoengsum(int p1, int p2, int p3) 
    {
        Poengsum = p1 + p2 + p3;

    }

    public override string ToString()
    {
        return $"Navn: {Navn} - Poengsum: {Poengsum}";
    }






}
