using System;
using System.IO;

namespace filbehandleriCskarp;

public class FilKlasse
{
    // Metode for å skrive til en fil
    public void SkrivTilFil(string filnavn, string tekst)
    {
        try
        {
            // Bruker StreamWriter for å skrive til fil
            using (StreamWriter writer = new StreamWriter(filnavn, append: true))
            {
                writer.WriteLine(tekst);
            }
            Console.WriteLine("Tekst skrevet til fil.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"En feil oppstod under skriving til fil: {ex.Message}");
        }
    }

    // Metode for å lese fra en fil
    public string LesFraFil(string filnavn)
    {
        try
        {
            // Bruker StreamReader for å lese fra fil
            using (StreamReader reader = new StreamReader(filnavn))
            {
                string innhold = reader.ReadToEnd();
                Console.WriteLine("Fil lest.");
                return innhold;
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Filen finnes ikke.");
            return string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"En feil oppstod under lesing fra fil: {ex.Message}");
            return string.Empty;
        }
    }

    // Metode for å sjekke om en fil eksisterer
    public bool SjekkOmFilEksisterer(string filnavn)
    {
        return File.Exists(filnavn);
    }
}