namespace O1;

public class FotballKlubb : Klubb
{
    
    int divisjon;
    public static string land;
    public List<string> spillere; 

    Random r = new Random(); 


    public FotballKlubb() : base()
    {
        this.divisjon = 0;
        this.spillere = new List<string>(); 
    }

    public FotballKlubb(string klubbNavn, int antallMedlemmer, Farge draktfarge, int divisjon) : base(klubbNavn, antallMedlemmer, draktfarge)
    {
        Divisjon = divisjon;
        this.spillere = new List<string>();        
    }

    public int Divisjon
    {
        get {return divisjon; }
        set 
        {
            if(value < 0)
            {
                throw new ArgumentException("Divisjon kan ikke være negativ!"); 
            }
            else
            {
                divisjon = value; 
            }
        }
    }

    public override string ToString()
    {
        return $"Klubbnavn: {KlubbNavn} \t Draktfarge: {DraktFarge}";
    }

    public string SpillerMot(FotballKlubb motstander)
    {
        if (motstander == null)
        {
            throw new ArgumentNullException(nameof(motstander), "Motstander kan ikke være null.");
        }

        int neste = r.Next(0, 2);
        return neste == 0 ? "H" : "B";
    }

    public bool SammeDraktFarge(FotballKlubb? x, FotballKlubb? y)
    {
        if(x == null || y == null) throw new ArgumentNullException("Klubb kan ikke være null!"); 
        return x.DraktFarge == y.DraktFarge; 
    }




}
