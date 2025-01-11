namespace O2;

public class Sammenligner : IComparer<Hund>
{
    public int Compare(Hund? x, Hund? y)
    {
        return x.Poengsum.CompareTo(y.Poengsum);
    }
}
