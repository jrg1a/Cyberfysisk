namespace O4;

class Program
{
    static void Main(string[] args)
    {

        int tall = 2;

        double sum = Rekursiv(tall);
        double sum2 = RekursivAlt(tall); 
        Console.WriteLine("Sum: " + sum); 
        Console.WriteLine("Sum: " + sum2); 
    }


/*
Lag en rekursiv metode som beregner summen: 
𝑛
𝑥=1 ∑ 1/𝑥^2

(heltallet x går fra 1 til n) når heltallet n (n>0) er gitt som argument. 
Dersom du ikke klarer å lage en rekursiv metode kan du
implementere en «ikke-rekursiv» løsning. Dette vil imidlertid kunne gi trekk i uttellingen.
*/
    public static double Rekursiv(int n)
    {
        if(n == 1) return 1;

        return (1/(Math.Pow(n, 2))) + Rekursiv(n-1); 
        
    }

    public static double RekursivAlt(int n)
    {
        double svar = 0;
        if (n == 1) svar = 1;
        else
        {
            svar = 1/Math.Pow(n,2) + Rekursiv(n-1);
        }
        return svar; 
    }
}
