namespace O1;

public class Sammenligner : IComparer<OljeFelt>
{
    public int Compare(OljeFelt? x, OljeFelt? y)
    {
        return x.FeltNavn.Length.CompareTo(y.FeltNavn.Length); 
    }
}
