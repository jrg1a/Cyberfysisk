namespace Dijkstra;

public class Node : IComparable<Node>
{
    public int Indeks { get; set; }
    public int Avstand { get; set; }

    public Node(int indeks, int avstand)
    {
        Indeks = indeks;
        Avstand = avstand;
    }


    // Sammenligner avstand, slik vi kan bruke en prioritetskø
    public int CompareTo(Node? other)
    {
        int resultat = Avstand.CompareTo(other.Avstand);
        return resultat == 0 ? Indeks.CompareTo(other.Indeks) : resultat; 
    }
}
