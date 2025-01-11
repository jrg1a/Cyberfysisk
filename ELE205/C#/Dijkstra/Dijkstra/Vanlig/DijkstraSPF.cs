namespace Dijkstra;

public class DijkstraSPF
{

    private const int INFINITY = int.MaxValue; 
    
    public (int[] avstander, int[] forgjengere) FinnKortesteSti(Graph graf, int startNode) 
    {
        int antallNoder = graf.AntallNoder;
        int[] avstander = new int[antallNoder];
        bool[] betraktet = new bool[antallNoder];

        int[] forgjengere = new int[antallNoder]; 

        for (int i = 0; i < antallNoder; i++)
        {
            avstander[i] = INFINITY;
            forgjengere[i] = -1; // -1 indikerer ingen forgjengere
        }
        avstander[startNode] = 0;

        for (int i = 0; i < antallNoder-1; i++)
        {
            int v = FinnMinsteAvstand(avstander, betraktet);
            betraktet[v] = true;

            for(int d = 0; d < antallNoder; d++)
            {   //
                if(!betraktet[d] && graf.HentVekt(v, d) != INFINITY && avstander[v] != INFINITY &&
                avstander[v] + graf.HentVekt(v,d) < avstander[d]) 
                {
                    avstander[d] = avstander[v] + graf.HentVekt(v, d);
                    forgjengere[d] = v;
                }
            }
        }

        return (avstander, forgjengere); 
    }


    private int FinnMinsteAvstand(int[] avstander, bool[] betraktet)
    {
        int min = INFINITY, minIndex = -1;

        for (int i = 0; i < avstander.Length; i++)
        {
            if (!betraktet[i] && avstander[i] <= min)
            {
                min = avstander[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

}
