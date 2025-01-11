namespace O2;

public class IdrettsUtøver
{

    private string navn;
    private double rekord;
    public enum Idrett { Løp, Hopp, Svømming, Sykling };
    
    

    public IdrettsUtøver(string _navn, double _rekord, Idrett idrett)
    {
        this.navn = _navn;
        this.rekord = _rekord;
        
    }


    


}
