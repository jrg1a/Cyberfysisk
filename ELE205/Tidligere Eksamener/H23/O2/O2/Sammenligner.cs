using System;

namespace O2;

public class Sammenligner : IComparer<Bok>
{
    public int Compare(Bok? x, Bok? y)
    {
        return x.Pris.CompareTo(y.Pris); 
    }
}
