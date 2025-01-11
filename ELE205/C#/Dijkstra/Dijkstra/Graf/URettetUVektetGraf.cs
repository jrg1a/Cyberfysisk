namespace Dijkstra;

public class URettetUVektetGraf : Graph
{
    public URettetUVektetGraf(int antallNoder) : base(antallNoder) { }

    public new void LeggTilKant(int node1, int node2)
    {
        if (node1 >= 0 && node1 < AntallNoder && node2 >= 0 && node2 < AntallNoder)
        {
            vektMatrise[node1, node2] = 1;
            vektMatrise[node2, node1] = 1;
        }
    }

    public new int HentVekt(int node1, int node2)
    {
        return vektMatrise[node1, node2] == 1 ? 1 : 0;
    }
}
