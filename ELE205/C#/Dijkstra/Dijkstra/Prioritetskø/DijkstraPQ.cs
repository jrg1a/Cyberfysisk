namespace Dijkstra;

public class DijkstraPQ
{
    private const int INFINITY = int.MaxValue; 

    public int[] FinnKortesteSti(Graph graf, int startNode)
    {
        int antallNoder = graf.AntallNoder;
        int[] avstander = new int[antallNoder];
        bool[] betraktet = new bool[antallNoder];

        // Initialiser avstander
        for (int i = 0; i < antallNoder; i++)
        {
            avstander[i] = INFINITY;
        }
        avstander[startNode] = 0;

        // Prioritetskø for å holde noder sortert etter avstand
        SortedSet<Node> pq = new SortedSet<Node>();
        pq.Add(new Node(startNode, 0));

        while (pq.Count > 0)
        {
            // Fjern noden med kortest avstand fra startnoden
            Node minsteNode = pq.Min;
            pq.Remove(minsteNode);

            int v = minsteNode.Indeks;
            if (betraktet[v]) continue;

            // Marker noden som betraktet
            betraktet[v] = true;

            // Oppdater avstander til naboer
            for (int d = 0; d < antallNoder; d++)
            {
                if (!betraktet[d] && graf.HentVekt(v, d) != INFINITY &&
                    avstander[v] != INFINITY &&
                    avstander[v] + graf.HentVekt(v, d) < avstander[d])
                {
                    // Fjern og oppdater avstanden i prioritetskøen
                    pq.Remove(new Node(d, avstander[d])); // Fjern tidligere verdi hvis den finnes
                    avstander[d] = avstander[v] + graf.HentVekt(v, d);
                    pq.Add(new Node(d, avstander[d]));    // Legg til ny avstand
                }
            }
        }

        return avstander;
    }


}
