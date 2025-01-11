using System;

namespace O2;

public class Bok
{

    string tittel;

    string forfatter;

    double pris;

    int sidetall;


    public Bok()
    {

    }
    public Bok(string _tittel, string _forfatter, double _pris, int _sidetall)
    {
        Tittel = _tittel;
        Forfatter = _forfatter;
        Pris = _pris;
        Sidetall = _sidetall;
    }

    public string Tittel
    {
        get { return tittel; }
        set 
        {
            if(string.IsNullOrEmpty(value)) tittel = "ukjent"; 
            else tittel = value; 
        }
    }

    public string Forfatter
    {
        get {return forfatter; }
        set 
        { 
            if(string.IsNullOrEmpty(value)) forfatter = "ukjent"; 
            else forfatter = value; 
        }
    }

    public int Sidetall
    {
        get{ return sidetall;}
        set 
        {
            if(value <= 0) throw new ArgumentException("Kan ikke være null!");
            else sidetall = value; 
        }
    }

    public double Pris
    {
        get {return pris; }
        set 
        {
            if(value <= 0) throw new ArgumentException("Ugyldig pris"); 
            else pris = value; 
        }
    }

}
