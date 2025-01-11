namespace O2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Bok b1 = new Bok("Markens Grøde", "Hamsund", 199.99, 388); 
        Bok b2 = new Bok("1984", "Orwell", 149.99, 237); 
        Bok b3 = new Bok("Yolo", "test", 399, 1249); 

        Biblotek biblotek = new Biblotek("Deichman", By.OSLO);

        biblotek.LeggTilBøker(b1);
        biblotek.LeggTilBøker(b2);
        biblotek.LeggTilBøker(b3);

        

    }
}
