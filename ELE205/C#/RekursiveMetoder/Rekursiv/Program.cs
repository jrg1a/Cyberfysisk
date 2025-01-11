namespace Rekursiv;

/// <summary>
///  En samling av rekursive metoder som ofte dukker opp. 
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Fakultet n!
        int n = 5; 
        Console.WriteLine($"{n}! = {Fakultet(n)}");

        // Fibonacci 
        int n1 = 6;
        Console.WriteLine($"Fibonacci({n1}) = {Fibonacci(n1)}");

        // Hanoi Tårnene
        int n2 = 3; // Antall skiver
        HanoisTarn(n2, 'A', 'B', 'C');

        // Palindrom
        string tekst = "radar";
        if (ErPalindrom(tekst, 0, tekst.Length - 1))
            Console.WriteLine($"'{tekst}' er et palindrom.");
        else
            Console.WriteLine($"'{tekst}' er ikke et palindrom.");

        
        // Palindrom V23
        string tekst1 = "radar";
        if (PalindromV23(tekst1, 0))
            Console.WriteLine($"'{tekst1}' er et palindrom.");
        else
            Console.WriteLine($"'{tekst1}' er ikke et palindrom.");

        
        // Potens x^n 
        double x = 2.5;
        int n3 = 3;
        Console.WriteLine($"{x}^{n3} = {BeregnPotens(x, n3)}");

        // SnuString
        Console.WriteLine($"Snudd versjon av '{tekst1}' er '{SnuString(tekst1)}'");


        // GCD
        int a = 48;
        int b = 18;
        Console.WriteLine($"GCD of {a} and {b} is {GCD(a, b)}");


        //SumList
        int[] array = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Sum of array: {SumList(array, array.Length)}");


        //Kombinasjoner
        int n4 = 5;
        int k = 2;
        Console.WriteLine($"Kombinasjoner({n4}, {k}) = {Kombinasjoner(n4, k)}");

        //FinnStørst Element i en liste
        int[] tallArray = { 3, 5, 9, 2, 8 };
        Console.WriteLine($"Største element i array: {FinnStorst(tallArray, tallArray.Length)}");

        // Genererer alle permusjoner av en streng
        string tekst3 = "abc";
        Console.WriteLine($"Permutasjoner av '{tekst3}':");
        GenererPermutasjoner(tekst3);

    }


    /// <summary>
    /// Finner fakultet rekursivt av et tall n - n!
    /// </summary>
    /// <param name="n">Fakultetstall</param>
    /// <returns></returns>
    public static int Fakultet(int n)
    {
        if (n <= 1) return 1;
        // Rekursjonstrinn: n * Fakultet(n - 1)
        return n * Fakultet(n - 1); 
    }


    /// <summary>
    /// Finner Fibonacci sekvensen av n
    /// 
    /// Basistilfeller: if (n <= 1) return n;
    ///     Når n er 0 eller 1, returnerer funksjonen n direkte, siden Fibonacci(0) = 0 og Fibonacci(1) = 1. 
    ///     Disse tilfellene stopper rekursjonen
    ///     
    /// Rekursjonstrinn: Hvis n er større enn 1, kaller funksjonen seg selv med n - 1 og n - 2, og legger resultatene sammen.
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int Fibonacci(int n)
    {
        if(n <= 1) return n;
        
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }


    /// <summary>
    /// Rekursivt metode for å løse Hanoi tårn problemet!
    /// 
    /// 
    /// </summary>
    /// <param name="n">Antall brikker</param>
    /// <param name="start">Startstolpe</param>
    /// <param name="mellom">Mellomstolpe</param>
    /// <param name="slutt">Sluttstolpe</param>
    public static void HanoisTarn(int n, char start, char mellom, char slutt)
    {
        // Basistilfelle: Flytt én skive direkte fra start til slutt
        if (n == 1)
        {
          Console.WriteLine($"Flytt skive fra {start} til {slutt}");
            return;
        }

        // Flytt n-1 skiver fra start til mellom, med slutt som mellomstasjon
        HanoisTarn(n - 1, start, slutt, mellom);

        // Flytt den største skiven direkte fra start til slutt 
        Console.WriteLine($"Flytt skive fra {start} til {slutt}");

        // Flytt n-1 skiver fra mellom til slutt, med start som mellomstasjon
        HanoisTarn(n - 1, mellom, start, slutt);
    }


    /// <summary>
    /// Sjekker om et ord er palindrom (samme baklangs som forlengs - feks: adada )
    /// </summary>
    /// <param name="tekst"></param>
    /// <param name="start"></param>
    /// <param name="slutt"></param>
    /// <returns></returns>
    public static bool ErPalindrom(string tekst, int start, int slutt)
    {
        // Basistilfelle: Hvis startindeksen er større eller lik sluttindeksen, er teksten et palindrom
        if (start >= slutt)
            return true;

        // Sjekker om første og siste tegn er like
        if (tekst[start] != tekst[slutt])
            return false;

        // Rekursiv sjekk på den neste delen av strengen
        return ErPalindrom(tekst, start + 1, slutt - 1);
    }

    /// <summary>
    /// Skjekker også palindrom (fra V23), bare at da er streng kalt "s" og tall kalt "p". 
    /// </summary>
    /// <param name="streng"></param>
    /// <param name="tall"></param>
    /// <returns></returns>
    private static bool PalindromV23(string streng, int tall)
    {
        bool svar = false;
        if(tall == streng.Length / 2)
            svar = true;
        else
        {
            if(streng[tall] != streng[streng.Length - (1 + tall)])
                svar = false;
            else
                svar = PalindromV23(streng, tall + 1); 
        }
        return svar; 
    }


    /// <summary>
    /// Beregner potensen x^n ved rekursiv metode
    /// </summary>
    /// <param name="x"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static double BeregnPotens(double x, int n)
    {
        // Basistilfelle: Når n er 0, returner 1
        if (n == 0)
            return 1;
        
        // Hvis n er negativt, beregn som 1 / x^|n|
        if (n < 0)
            return 1 / BeregnPotens(x, -n);

        // Rekursjonstrinn: x * x^(n-1)
        return x * BeregnPotens(x, n - 1);
    }

    /// <summary>
    /// Snur en string rekursivt
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string SnuString(string str)
    {
        // Basistilfelle: Hvis strengen er tom eller har ett tegn, returner den som den er
        if (str.Length <= 1)
            return str;

        // Rekursjonstrinn: Ta siste tegn + kall på resten av strengen
        return str[str.Length - 1] + SnuString(str.Substring(0, str.Length - 1));
    }


    /// <summary>
    /// Greates Common Diviser - Euklids Algoritme
    /// Denne metoden finner den største felles divisor (GCD) mellom to tall, ved hjelp av Euklids algoritme
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int GCD(int a, int b)
    {
        // Basistilfelle: Hvis b er 0, returner a
        if (b == 0)
            return a;

        // Rekursjonstrinn: Kall GCD på b og a % b
        return GCD(b, a % b);
    }


    /// <summary>
    /// En metode som beregner summen av alle tall i en liste rekursivt.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int SumList(int[] array, int n)
    {
        // Basistilfelle: Hvis n er 0, returner 0
        if (n <= 0)
            return 0;

        // Rekursjonstrinn: Legg til siste element og kall på resten av listen
        return array[n - 1] + SumList(array, n - 1);
    }


    /// <summary>
    /// Denne metoden beregner antall måter å velge k elementer fra n elementer ved hjelp av rekursjon.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int Kombinasjoner(int n, int k)
    {
        // Basistilfeller: nC0 = 1 og nCn = 1
        if (k == 0 || k == n)
            return 1;

        // Rekursjonstrinn: nCk = (n-1)C(k-1) + (n-1)Ck
        return Kombinasjoner(n - 1, k - 1) + Kombinasjoner(n - 1, k);
    }



    /// <summary>
    /// Finner største element i en liste
    /// </summary>
    /// <param name="array"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int FinnStorst(int[] array, int n)
    {
        // Basistilfelle: Hvis det er ett element igjen, returner det
        if (n == 1)
            return array[0];

        // Rekursjonstrinn: Finn maksimum mellom siste element og det største i resten
        return Math.Max(array[n - 1], FinnStorst(array, n - 1));
    }


    /// <summary>
    /// En metode som genererer alle permutasjoner av en streng rekursivt. Denne metoden skriver ut permutasjonene til konsollen.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="prefix"></param>
    public static void GenererPermutasjoner(string str, string prefix = "")
    {
        // Basistilfelle: Hvis strengen er tom, skriv ut permutasjonen
        if (str.Length == 0)
        {
            Console.WriteLine(prefix);
            return;
        }

        // Rekursjonstrinn: Flytt hvert tegn til starten og kall på resten av strengen
        for (int i = 0; i < str.Length; i++)
        {
            string rem = str.Substring(0, i) + str.Substring(i + 1);
            GenererPermutasjoner(rem, prefix + str[i]);
        }
    }


    /// <summary>
    /// Teller antall forekomster i en streng eller liste
    /// </summary>
    /// <param name="tekst"></param>
    /// <param name="tegn"></param>
    /// <param name="indeks"></param>
    /// <returns></returns>
    public static int TellForekomster(string tekst, char tegn, int indeks = 0)
    {
        if (indeks >= tekst.Length) return 0;
        return (tekst[indeks] == tegn ? 1 : 0) + TellForekomster(tekst, tegn, indeks + 1);
    }


    // Rekursive Mergesort
    public static void MergeSort(int[] array, int[] temp, int venstre, int hoyre)
    {
        if (venstre >= hoyre) return;

        int mid = (venstre + hoyre) / 2;

        MergeSort(array, temp, venstre, mid);
        MergeSort(array, temp, mid + 1, hoyre);
        Merge(array, temp, venstre, mid, hoyre);
    }

    private static void Merge(int[] array, int[] temp, int venstre, int mid, int hoyre)
    {
        int i = venstre, j = mid + 1, k = venstre;

        while (i <= mid && j <= hoyre)
            temp[k++] = array[i] <= array[j] ? array[i++] : array[j++];

        while (i <= mid) temp[k++] = array[i++];
        while (j <= hoyre) temp[k++] = array[j++];

        for (i = venstre; i <= hoyre; i++)
            array[i] = temp[i];
    }



}
