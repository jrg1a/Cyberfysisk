using System;
using filbehandleriCskarp;

class Program
{
    static void Main(string[] args)
    {
        FilKlasse filHandler = new FilKlasse();

        string filnavn = "testfil.txt";

        // Sjekk om filen eksisterer
        if (!filHandler.SjekkOmFilEksisterer(filnavn))
        {
            Console.WriteLine("Filen eksisterer ikke. Lager ny fil.");
        }

        // Skrive til fil
        filHandler.SkrivTilFil(filnavn, "Dette er en testlinje.");
        filHandler.SkrivTilFil(filnavn, "En annen linje med tekst.");

        // Lese fra fil
        string innhold = filHandler.LesFraFil(filnavn);
        Console.WriteLine("Innholdet i filen er:");
        Console.WriteLine(innhold);
    }
}