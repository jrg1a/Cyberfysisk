using System;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveTowerOfHanoi(3, 'A', 'C', 'B');
        }

        static void SolveTowerOfHanoi(int n, char start_stang, char maal_stang, char reserve_stang)
        {
            if (n == 0) return;

            // Flytt de(n-1) diskene fra start_stang til reserve_stang, ved å bruke to_rod som mellomstasjon
            SolveTowerOfHanoi(n - 1, start_stang, reserve_stang, maal_stang);

            // Flytt den n-te disken direkte fra from_rod til to_rod
            Console.WriteLine($"Move disk {n} from rod {start_stang} to rod {maal_stang}");

            // Flytt de(n-1) diskene fra aux_rod til to_rod, ved å bruke from_rod som mellomstasjon
            SolveTowerOfHanoi(n - 1, reserve_stang, maal_stang, start_stang);
        }
    }
}