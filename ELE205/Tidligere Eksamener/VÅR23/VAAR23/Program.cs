namespace VAAR23;

class Program
{
    static void Main(string[] args)
    {
        
        Fly f1 = new Fly("Minifly", 2001);
        Fly f2 = new Fly("Privat Jet", 1998);

        PassasjerFly a330 = new PassasjerFly("Airbus", 2024, 350, 50000, Lokasjoner.Berlin);
        PassasjerFly b737 = new PassasjerFly("Boeing", 2012, 190, 40000, Lokasjoner.Roma);

        MilitærFly f35 = new MilitærFly("Jagerfly", 2018, "Dog Fight", Lokasjoner.London);
        MilitærFly a10 = new MilitærFly("Bombefly", 2007, "Infantri", Lokasjoner.Berlin); // brrRRRRRRRRRRTT

        f1.SkrivUt();
        f1.SammenlignTypeBetegnelse(f1, f2);


        a330.SkrivUt();  
        Console.WriteLine(a330.Lokasjon);

        //Console.WriteLine(a330.ToString()); 
        Console.WriteLine(); 
        a330.FlyttTil(Lokasjoner.NewYork);
        a330.SkrivUt(); 
        Console.WriteLine(a330.Lokasjon);

        List<Fly> liste = new List<Fly>{};
        liste.Add(f1);
        liste.Add(f2);
        liste.Add(a330);
        liste.Add(b737);
        liste.Add(f35);
        liste.Add(a10);

        foreach (var fly in liste)
        {
            fly.SkrivUt();
        }

    



    }
}
