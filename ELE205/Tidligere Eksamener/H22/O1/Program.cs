namespace O1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        OljeFelt f1 = new OljeFelt("Ekofisk", "Equinor", 15000);
        OljeFelt f2 = new OljeFelt("Gullfaks", "Equinor", 205003);
        OljeFelt f3 = new OljeFelt("Troll", "Shell", 9999);
        OljeFelt f4 = new OljeFelt("Oseberg", "Statoil", 98712);
        OljeFelt f5 = new OljeFelt("Statfjord", "Aker BP", 120034);

        List<OljeFelt> liste = new List<OljeFelt> { f1, f2, f3}; 

        liste.Sort(new Sammenligner()); 

        foreach(var felt in liste) 
        {
            Console.WriteLine(felt.ToString()); 
        }

        List<IProduksjonsFelt> liste2 = new List<IProduksjonsFelt> {f1, f2, f3, f4, f5}; //legger de inn her, for det er raskere enn liste.Add(f1); osv

        foreach(var f in liste2) 
        {
            f.SkrivUtInfo(); 
        }

    }
}
