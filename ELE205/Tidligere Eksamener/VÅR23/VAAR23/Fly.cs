namespace VAAR23;

public class Fly
{
    private string typebetegnelse;
    private int produksjonsaar;

    public Fly() 
    {
        this.typebetegnelse = "";
        this.produksjonsaar = 0; 
    }

    public Fly(string typebetegnelse, int produksjonsaar) 
    {
        Typebetegnelse = typebetegnelse;
        Produksjonsaar = produksjonsaar; 

    }

    public string Typebetegnelse 
    {
        get { return typebetegnelse; }
        set { typebetegnelse = value; }
    }

    public int Produksjonsaar
    {
        get { return produksjonsaar; }
        set 
        { 
            if(value < 1900)
            {
                produksjonsaar = 1900;
            } 
            else if(value > 2050) 
            { 
                produksjonsaar = 2050;
            }
            else 
            {
                produksjonsaar = value; 
            }
        }
    }

    public void SkrivUt() 
    {
        Console.WriteLine($"Typebetegnelse: {Typebetegnelse}");
        Console.WriteLine($"Produksjonsår: {Produksjonsaar}"); 
    }

    public override string ToString()
    {
        return ($"{Typebetegnelse} {Produksjonsaar}");
    }

    public bool SammenlignTypeBetegnelse(Fly en, Fly to)
    {
        if(en.Typebetegnelse == to.Typebetegnelse)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
