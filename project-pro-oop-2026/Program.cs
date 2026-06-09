using System;
using System.Linq.Expressions;

namespace Solution_Scrabble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //(TRY CATCH) vangt fouten op zodat het programma niet crasht
            try
            {
                //(OBJECT AANMAKEN) van klasse woord
                Woord woord = new Woord();

                // vraagt (INPUT) aan de gebuiker
                Console.WriteLine("Geef een woord of zin in:");
                Console.WriteLine("------------------------");
                woord.Input = Console.ReadLine();

                //(THROW) gooit een fout weg als de gebruiker niks invoert
                if (woord.Input == "")
                {
                    throw new Exception("Je moet een woord ingeven.");
                }

                //Roept de (METHODE) op die het aantal karakters telt (basis)
                woord.BerekenKarakters(woord.Input, woord.TotaalAantalKarakters);

                //Roept de (METHODE) op die een totale waarde berekent (uitbreiding)
                woord.BerekenWaarde(woord.Input, woord.TotaalWaardeKarakters);

                //Vraagt een spelmodus en controleert of de spelmodus klopt
                Console.WriteLine("Speel nu met een mode");
                Console.WriteLine("------------------------");
                Console.WriteLine("Kies mode: normal / hard / extreme");
                Console.WriteLine("------------------------");
                string mode = Console.ReadLine();

                if (mode != "normal" && mode != "hard" && mode != "extreme")
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Ongelde spelmode gekozen");
                    Console.WriteLine("------------------------");
                    return;
                }

                //Roept een (OVERLOAD) methode op met extra parameter (POLYMORFISME
                woord.BerekenWaarde(woord.Input, woord.TotaalWaardeKarakters, mode);
            }
            catch (Exception fout)
            {
                //Toont de foutemelding aan de gebruiker.
                Console.WriteLine(fout.Message);
            }
        }
    }
}

//(INTERFACE) bepaalt welke methodes verplicht aanwzeig moeten zijn (ABSTRACTIE)
interface iBereken
{
    void BerekenKarakters(string Input, int TotaalAantalKarakters);
    //Methode voor normale berekening
    void BerekenWaarde(string Input, int TotaalWaardeKarakters);

    //Methode voor (POLYMORFISME)
    void BerekenWaarde(string Input, int TotaalWaardeKarakters, string Mode);
}

//(KLASSEN) aanmaken
public class Tekst
{
    //(AUTO-PROPERTY)met (ACCESSOR, MUTATOR) om invoer opslaat (ENCAPSULATIE)
    public string Input { get; set; }
}

//(KLASSEN) aanmaken en woord (ERFT) eigenschappen van Tekst en implenteert ook de (INTERFACE) (OVERERVING)
public class Woord : Tekst, iBereken
{
    //Properties voor oplsaan van resultaten (ACCESSOR, MUTATOR) (AUTO-PROPERTIES) (ENCAPSULATIE)
    public int TotaalAantalKarakters { get; set; }
    public int TotaalWaardeKarakters { get; set; }

    // (CONSTRUCTOR) geeft de eigenschappen van de beginwaarden van het object
    public Woord()
    {
        Input = "";
        TotaalAantalKarakters = 0;
        TotaalWaardeKarakters = 0;

        Console.WriteLine("------------------------");
        Console.WriteLine("Spel opgestart!");
    }

    //(METHODE) telkt het aantal karakters
    public void BerekenKarakters(string Input, int TotaalAantalKarakters)
    {
        foreach (char c in Input)
        {
            TotaalAantalKarakters++;
        }

        Console.WriteLine("------------------------");
        Console.WriteLine("Aantal karakters: " + TotaalAantalKarakters);
    }

    //(METHODE) berekent random waarde
    public void BerekenWaarde(string Input, int TotaalWaardeKarakters)
    {
        Random random = new Random();

        foreach (char c in Input)
        {
            TotaalWaardeKarakters += random.Next(0, 26);
        }

        Console.WriteLine("Totale waarde: " + TotaalWaardeKarakters);
        Console.WriteLine("------------------------");
    }

    //POLYMORFISME door gebruik van game modes (OVERLOADING)
    public void BerekenWaarde(string Input, int TotaalWaardeKarakters, string Mode)
    {
        Random random = new Random();

        foreach (char c in Input)
        {
            TotaalWaardeKarakters += random.Next(0, 26);
        }

        if (Mode == "hard")
        {
            TotaalWaardeKarakters *= 2;
        }
        else if (Mode == "extreme")
        {
            TotaalWaardeKarakters *= 3;
        }
        Console.WriteLine("------------------------");
        Console.WriteLine("Mode: " + Mode);
        Console.WriteLine("Totale waarde:" + TotaalWaardeKarakters);
        Console.WriteLine("------------------------");
    }

}