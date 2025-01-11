using System;
using System.ComponentModel;

namespace O2;

public class Biblotek
{

    List<Bok> bøker;

    string addresse;

    By byer;


    public Biblotek()
    {
        this.bøker = new List<Bok>(); 
    }

    public Biblotek(string addresse, By _by)
    {
        Addresse = addresse;
        Byer = _by;
        this.bøker = new List<Bok>(); 
    }


    public void LeggTilBøker(Bok bok)
    {
        bøker.Add(bok);
    }
    

    public By Byer
    {
        get{ return byer; }
        set {byer = value; }
    }

    public string Addresse
    {
        get { return addresse; }
        set { addresse = value; }
    }

}
