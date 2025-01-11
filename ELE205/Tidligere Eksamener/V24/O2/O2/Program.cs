using System.Security.Cryptography;

namespace O2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Hund.konkurransetype = "Dressage"; 

        Hund h1 = new Hund("Ola", "Baltus");
        
        Hund h2 = new Hund("Kari", "Fantus");

        Hund h3 = new Hund("Askeladden", "Alma");

        List<Hund> deltakere = new List<Hund> {h1, h2, h3};

        h1.RegistrerPoengsum(9, 7, 8);
        h2.RegistrerPoengsum(6, 7, 7);
        h3.RegistrerPoengsum(10,7, 7);

        Console.WriteLine("Uten sortering: ");
        foreach (var item in deltakere)
        {
            Console.WriteLine(item.ToString()); 
        }
        Console.WriteLine("\n");

        deltakere.Sort(new Sammenligner());
        Console.WriteLine("Med sortering: ");
        foreach (var hund in deltakere)
        {
            Console.WriteLine(hund.ToString()); 

        }

        Console.WriteLine("\n");
        Console.WriteLine("Med sortering på navn: ");
        deltakere.Sort(new SammenlignerNavn()); 
        foreach (var hund in deltakere)
        {
            Console.WriteLine(hund.ToString()); 
        }


    }
}
