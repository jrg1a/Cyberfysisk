namespace Dijkstra;

public class RettetVektetGraf : Graph
{
    public RettetVektetGraf(int antallNoder) : base(antallNoder) { }

    public new void LeggTilKant(int node1, int node2, int vekt) 
    {
        if (node1 >= 0 && node1 < AntallNoder && node2 >= 0 && node2 < AntallNoder)
        {
            vektMatrise[node1, node2] = vekt; 
        }
    }
}
