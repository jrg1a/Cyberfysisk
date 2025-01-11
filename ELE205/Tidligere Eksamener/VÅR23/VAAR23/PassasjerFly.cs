namespace VAAR23;

public class PassasjerFly : Fly
{
    private int passasjertall;
    private int rekkevidde;
    private Lokasjoner lokasjon; 

    public PassasjerFly(string typebetegnelse, int produksjonsaar ,int passasjertall, int rekkevidde, Lokasjoner lokasjon) : base(typebetegnelse, produksjonsaar)
    {
        this.passasjertall = passasjertall;
        this.rekkevidde = rekkevidde;
        this.lokasjon = lokasjon;
    }

    // Tilgangsmedlemmer for private datamedlemmer
    public int Passasjertall
    {
        get { return passasjertall; }
    }

    public int Rekkevidde
    {
        get { return rekkevidde; }
    }

    public Lokasjoner Lokasjon
    {
        get { return lokasjon; }
    }

     public void FlyttTil(Lokasjoner nyLokasjon)
    {
        lokasjon = nyLokasjon; 
    }



}
