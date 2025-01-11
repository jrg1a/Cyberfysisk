using System.Security.Cryptography.X509Certificates;

namespace O1;

public class Klubb
{

    string klubbNavn;
    int antallMedlemmer;

    Farge farge; 


    public Klubb()
    {
        this.klubbNavn = "Unamed";
        this.antallMedlemmer = 0;
 
    }


    public Klubb(string _klubbNavn, int _antallMedlemmer, Farge _farge)
    {
        KlubbNavn = _klubbNavn;
        AntallMedlemmer = _antallMedlemmer;
        this.farge = _farge; 
    }



    public string KlubbNavn 
    {
        get {return klubbNavn; }
        set 
        {
            if(string.IsNullOrEmpty(value))
            {
                klubbNavn = "x";
            }
            else
            {
                klubbNavn = value;
            }
        }
    }

    public int AntallMedlemmer
    {
        get { return antallMedlemmer; }
        set 
        { 
            if( value < 0) antallMedlemmer = 0;
            else antallMedlemmer = value; 
        }
    }


    public Farge DraktFarge
    {
        get { return farge; }
    }

}
