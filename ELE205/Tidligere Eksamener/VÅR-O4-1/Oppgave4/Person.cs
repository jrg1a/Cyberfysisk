namespace Oppgave4;

public class Person
{
    string fornavn;
    string etternavn;
    int alder;

    public Person() 
    {
        fornavn = "";
        etternavn = "";
        alder = 0;
    }

    public Person(string fornavn, string etternavn, int alder) 
    {
        Fornavn = fornavn;
        Etternavn = etternavn;
        Alder = alder; 
    }

    public string Fornavn
    {
        get { return this.fornavn;}
        set { fornavn = value; }
    }

    public string Etternavn
    {
        get{ return etternavn; }
        set{ etternavn = value; }
    }

    public int Alder
    {
        get{ return alder; }
        set{ alder = value; }
    }

}
