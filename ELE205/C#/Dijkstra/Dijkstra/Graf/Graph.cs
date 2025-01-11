namespace Dijkstra;

/// <summary>
///   Dette er en vektet urettet graf. Dvs. at hver kant har en vekt (nummerisk verdi),
///   som angir en kostnad/avstand. Kantene har ingen rettning, dvs at vekten er lik i begge rettniger
///   mellom node1 og node2.
/// </summary>
public class Graph
{
    public int AntallNoder { get; private set; } // Antall noder i grafen
    public int[,] vektMatrise; // Representerer kantvektene
    private const int INFINITY = int.MaxValue; // Uendelig vekt => ingen kant mellom to noder


    public Graph(int antallNoder) 
    {
        AntallNoder = antallNoder; 
        vektMatrise = new int[AntallNoder, AntallNoder];

        // Initialiserer matrisen med uendelig vekt, bortsett fra diagonal (som er 0)
        for (int i = 0; i < AntallNoder; i++)
        {
            for (int j = 0; j < AntallNoder; j++)
            {
                if (i == j) vektMatrise[i, j] = 0;
                else vektMatrise[i, j] = INFINITY;
            }
        }
    }

    public void LeggTilKant(int node1, int node2, int vekt)
    {
        if (node1 >= 0 && node1 < AntallNoder && node2 >= 0 && node2 < AntallNoder)
        {
            vektMatrise[node1, node2] = vekt;
            vektMatrise[node2, node1] = vekt;
        }
    }


    public int HentVekt(int node1, int node2) {
        return vektMatrise[node1, node2];
    }

    public void VisVektMatrise() 
    {
        for (int i = 0; i < AntallNoder; i++)
        {
            for (int j = 0; j < AntallNoder; j++)
            {
                Console.Write(vektMatrise[i, j] == INFINITY ? "∞ " : $"{vektMatrise[i, j]} ");
            }
            Console.WriteLine();
        }
    }


}
