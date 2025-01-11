namespace O2;

public class SammenlignerNavn : IComparer<Hund>
{
    public int Compare(Hund? x, Hund? y)
    {
        return x.Navn.CompareTo(y.Navn);
    }
}
