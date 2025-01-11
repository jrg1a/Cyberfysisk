namespace O1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Klubb k1 = new Klubb("A", 17, Farge.BRUN);
        Klubb k2 = new Klubb("X", 22, Farge.GRØNN);
        Klubb k3 = new Klubb("VIF", 28, Farge.BLÅ);

        FotballKlubb fk1 = new FotballKlubb("Brann", 20, Farge.RØD, 1);
        FotballKlubb fk2 = new FotballKlubb("Molde", 19, Farge.BLÅ, 1);
        FotballKlubb fk3 = new FotballKlubb("RBK", 25, Farge.HVIT, 1);

        List<Klubb> liste = new List<Klubb> {k1, k2, k3, fk1, fk2, fk3 };

        fk1.spillere.Add("Bård Finne");
        fk1.spillere.Add("Niklas Castro");
        fk1.spillere.Add("Aune Heggebøs"); 

        fk2.spillere.Add("Noldus Nisse"); 
        fk2.spillere.Add("Tape Tapersen");
        fk2.spillere.Add("Stink Stinkesen"); 

        fk3.spillere.Add("Hjem Brent"); 
        fk3.spillere.Add("Trønder Bart");
        fk3.spillere.Add("Karl ogco"); 


        foreach (var k in liste)
        {
            if(k is FotballKlubb fotballKlubb)
            {
                Console.WriteLine("Fotballklubb info: "); 
                Console.WriteLine(fotballKlubb.KlubbNavn);
                Console.WriteLine(fotballKlubb.Divisjon);
                Console.WriteLine(fotballKlubb.DraktFarge);
                Console.WriteLine("\n");  
            }
            else
            {
                Console.WriteLine(k.KlubbNavn);
                Console.WriteLine("Er ikke fotballklubb");
            }
        }

        List<FotballKlubb> flist = new List<FotballKlubb> {fk1, fk2, fk3 };

        flist.Sort(new SammenlignerAntall()); 
        
        foreach (var i in flist)
        {
            Console.WriteLine(i.ToString()); 
        }

        flist.Sort(new SammenlignerAntall());
        Console.WriteLine(""); 

        foreach (var k in flist)
        {
            Console.WriteLine(k.ToString());
        }




        var klubb1 = new FotballKlubb("Lyn", 20, Farge.RØD, 1);
        klubb1.spillere.Add("Anders");
        klubb1.spillere.Add("Bent");

        var klubb2 = new FotballKlubb("Vålerenga", 25, Farge.BLÅ, 1);
        klubb2.spillere.Add("Kari");
        klubb2.spillere.Add("Per");

        var klubb3 = new FotballKlubb("Brann", 30, Farge.RØD, 1);
        // Tom spillerliste

        var klubber = new List<FotballKlubb> { klubb1, klubb2, klubb3 };

        // Sorter lista
        klubber.Sort(new SammenlignerNavn());

        // Skriv ut klubbnavnene
        foreach (var klubb in klubber)
        {
            Console.WriteLine(klubb.KlubbNavn);
        }
    }


}
