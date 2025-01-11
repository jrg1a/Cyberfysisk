using System;

namespace O1;

public class SammenlignerAntall : IComparer<FotballKlubb>
{
    public int Compare(FotballKlubb? x, FotballKlubb? y)
    {
        return x.AntallMedlemmer.CompareTo(y.AntallMedlemmer); 
    }
    
}
