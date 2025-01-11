namespace Oppgave4;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<Person> liste = new List<Person> {};

        Person start = new Person();
        liste.Add(start);

        Elev mej = new Elev("Jørgen", "Austnes", 28, 6, 4, 6);
        Elev e2 = new Elev("Donald", "Trump", 100, 2, 1, 1);
        Elev e3 = new Elev("Elon", "Musk", 13, 4, 1, 5); // 13 år og edgy 
        Elev e4 = new Elev("Ola", "Nordman", 29, 5, 4, 5);
        liste.Add(mej);
        liste.Add(e2);
        liste.Add(e3);
        liste.Add(e4);

        Console.WriteLine($"{mej.Fornavn} har et karaktergjennomsnitt på {mej.Gjennomsnitt:F2}");

        // Alle over 20 år
        foreach(var person in liste)
        {
            if(person.Alder > 20)
            {
                Console.WriteLine($"Alder: {person.Alder}");
            }
        }

        List<Elev> elevListe = liste.OfType<Elev>().ToList();

        elevListe.Sort(new Sammenligner());

        foreach(var elev in elevListe)
        {
            Console.WriteLine($"{elev.Fornavn} {elev.Etternavn}, Gjennomsnitt: {elev.Gjennomsnitt:F2}");
        }


    }
}
