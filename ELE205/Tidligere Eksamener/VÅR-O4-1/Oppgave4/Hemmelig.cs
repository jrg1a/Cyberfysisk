namespace Oppgave4;

public class Hemmelig
{

    private static bool hemmeligMetode(string streng, int tall)
    {
        bool svar = false;
        if(tall == streng.Length / 2) svar = true;
        else
        {
            if(streng[tall] != streng[streng.Length - (1 + tall)]) svar = false;
            else svar = hemmeligMetode(streng, tall+1); 
        }
        return svar; 
        throw new ArgumentException();
    }
}

