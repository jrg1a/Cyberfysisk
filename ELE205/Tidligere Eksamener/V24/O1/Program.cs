namespace O1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Kurs kokkekurs = new Kurs();
        kokkekurs.navn = "Kokkekurs"; 
        StudieEmne Matematikk = new StudieEmne("Matematikk", 1001, 10, Semester.HØST);
        StudieEmne Fysikk = new StudieEmne("Fysikk", 1002, 15, Semester.HØST);
        StudieEmne Elektro = new StudieEmne("Elektrofaglig basis", 1003, 5, Semester.HØST);
        StudieEmne Programmering = new StudieEmne("Programmering", 1004, 7.5, Semester.VÅR);

        if(Matematikk >= Fysikk) Console.WriteLine("Matematikk har flere eller like mange studiepoeng fysikk");
        else Console.WriteLine("Fysikk har flere studiepoeng enn matematikk"); 

        List<StudieEmne> emneListe = new List<StudieEmne> { Matematikk, Fysikk, Elektro, Programmering};

        foreach(var emne in emneListe)
        {
            Console.WriteLine(emne.ToString()); 
        }

        List<Kurs> nyListe = new List<Kurs> { Matematikk, kokkekurs, Fysikk, Elektro, Programmering};

        foreach(var s in nyListe)
        {
            if(s is StudieEmne)
            {
                Console.WriteLine(s.ToString());
            } 
            else
            {
                Console.WriteLine(s.navn); 
            }
        } 
    }
}
