namespace O1;

public class StudieEmne : Kurs
{
    int emnekode;
    double studiepoeng;

    public Semester semester;

    public List<string> studenter;
    private static int høyesteEmneKode;


    // g) 
    public StudieEmne()
    {
        navn = null;
        emnekode = 0;
        semester = Semester.HØST;
        studenter = new List<string>{};
        høyesteEmneKode = 1000;
    }

    // h)
    public StudieEmne(string _navn, int _emnekode, double _studiepoeng, Semester _semester)
    {
        this.navn = _navn;
        Emnekode = _emnekode;
        Studiepoeng = _studiepoeng;
        this.semester = _semester;
        this.studenter = new List<string>{}; 
        høyesteEmneKode = 1000;

        if (SjekkEmneKode(_emnekode) == false) 
        {
            Console.WriteLine("Emnekoden er ikke høy nokk. Settes til standard innstillinger: emnekode 0 og Høst-semester"); 
            Emnekode = 0;
            this.semester = Semester.HØST;
        }
        else høyesteEmneKode = emnekode;

    
    }

    public override string ToString()
    {
        return $"Navn på kurset: {this.navn} , Emnekode: {Emnekode} , Studiepoeng: {Studiepoeng}";
    }

    public void SkrivUt()
    {
        Console.WriteLine($"Kursnavn: {this.navn}");
        Console.WriteLine($"Emnekoden er {Emnekode}, og gir {Studiepoeng} studiepoeng.");
        Console.WriteLine($"Kurset går på {semester}");
        Console.WriteLine("Studenter påmeldt: ");
        foreach(var s in studenter)
        {
            Console.Write($"{s}, "); 
        }
    }

    public static bool operator>= (StudieEmne x, StudieEmne y)
    {
        return x.Emnekode >= y.Emnekode; 
    }

    public static bool operator<= (StudieEmne x, StudieEmne y)
    {
        return x.Emnekode <= y.Emnekode; 
    }

    public int Emnekode
    {
        get {return emnekode; }
        private set { emnekode = value;} //Tolket det som at det skulle være en set, men ikke tilgjengelig for andre
    }

    public double Studiepoeng
    {
        get {return studiepoeng;}
        set {studiepoeng = value;}
    }

    public bool SjekkEmneKode(int _emnekode)
    {
        return _emnekode > høyesteEmneKode; 
    }






}
