using System;

namespace O1;

public class SammenlignerNavn : IComparer<FotballKlubb>
{
    public int Compare(FotballKlubb? x, FotballKlubb? y)
    {
        // Håndtering av null-objekter
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        // Håndtering av klubber uten spillere
        if (x.spillere == null || x.spillere.Count == 0) return -1;
        if (y.spillere == null || y.spillere.Count == 0) return 1;

        // Sammenlign første spiller i listen
        return x.spillere[0].CompareTo(y.spillere[0]);
    }
}