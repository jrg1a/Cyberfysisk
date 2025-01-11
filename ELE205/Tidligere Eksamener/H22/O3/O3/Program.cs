namespace O3;

class Program
{
    static void Main(string[] args)
    {
        double x = 2.5;
        int n = 3;
        Console.WriteLine($"{x}^{n} = {BeregnPotens(x, n)}");

        x = 2.5;
        n = -3;
        Console.WriteLine($"{x}^{n} = {BeregnPotens(x, n)}");

    }



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

    
}
