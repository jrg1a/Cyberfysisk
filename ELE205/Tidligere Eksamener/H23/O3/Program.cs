namespace O3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Console.WriteLine(Rekursiv(3));

    }
    

    public static int Rekursiv(int n)
    {
        if(n < 0) return -1; 
        if(n == 1) return 1; 
        if(n == 2) return 2;
        
        return 3 * Rekursiv(n-1) - 2 * Rekursiv(n-2); 
    }
}
