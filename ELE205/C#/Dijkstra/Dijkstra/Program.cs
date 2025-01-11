namespace Dijkstra;

class Program
{
    static void Main(string[] args)
    {
        Graph graf = new Graph(5);

        graf.LeggTilKant(0, 1, 10);
        graf.LeggTilKant(0, 2, 3);
        graf.LeggTilKant(1, 2, 1);
        graf.LeggTilKant(1, 3, 2);
        graf.LeggTilKant(2, 3, 8);
        graf.LeggTilKant(3, 4, 7);

        graf.VisVektMatrise(); 

        
        int startNode = 0;

        DijkstraSPF dijkstra = new DijkstraSPF();
        var (avstander, forgjengere) = dijkstra.FinnKortesteSti(graf, startNode);

        // Vis avstandene til hver node
        Console.WriteLine("Avstander til hver node fra startnoden:");
        for (int i = 0; i < avstander.Length; i++)
        {
            Console.WriteLine($"Node {i}: {avstander[i]}");
        }

        // Vis sti-informasjon for hver node
        Console.WriteLine("\nStier fra startnoden:");
        for (int i = 0; i < forgjengere.Length; i++)
        {
            if (i != startNode)
            {
                Console.Write($"Sti til node {i}: ");
                SkrivUtSti(i, forgjengere);
                Console.WriteLine();
            }
        }
    }


    static void SkrivUtSti(int node, int[] forgjengere)
    {
        if (forgjengere[node] == -1)
        {
            Console.Write(node);
            return;
        }
        SkrivUtSti(forgjengere[node], forgjengere);
        Console.Write($" -> {node}");
    }
}
