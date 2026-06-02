using System;
using System.Linq.Expressions;

namespace Solution_Scrabble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TRY CATCH THROW
            try
            {
                //OBJECT AANMAKEN
                Woord woord = new Woord();

                // INPUT
                Console.WriteLine("Geef een woord of zin in:");
                woord.Input = Console.ReadLine();

                //THROW
                if (woord.Input == "")
                {
                    throw new Exception("Je moet een woord ingeven.");
                }

                //AANROEPEN METHODES/FUNCTIES (BASIS)
                woord.BerekenKarakters(woord.Input, woord.TotaalAantalKarakters);

                //AANROEPEN METHODES/FUNCTIES (UITBREIDING)
                woord.BerekenWaarde(woord.Input, woord.TotaalWaardeKarakters);

                //POLYMORFISME AANROEPEN
                Console.WriteLine("Kies mode: normal / hard / extreme");
                string mode = Console.ReadLine();
                woord.BerekenWaarde(woord.Input, woord.TotaalWaardeKarakters, mode);
            }
            catch (Exception fout)
            {
                Console.WriteLine(fout.Message);
            }
        }
    }
}

//INTERFACE (ABSTRACTIE)
interface iKarakterTeller
{
    void BerekenKarakters(string Input, int TotaalAantalKarakters);
    //NORMALE BEREKENING
    void BerekenWaarde(string Input, int TotaalWaardeKarakters);

    //POLYMORFISME BEREKENING (OVERLOADING)
    void BerekenWaarde(string Input, int TotaalWaardeKarakters, string Mode);
}

//KLASSEN (OVERERVING) (ACCESSOR, MUTATOR (GET, SET)) (ENCAPSULATIE)
public class Tekst
{
    public string Input { get; set; }
}
//KLASSEN
public class Woord : Tekst, iKarakterTeller
{
    //ACCESSOR, MUTATOR (GET, SET) (ENCAPSULATIE)
    public int TotaalAantalKarakters { get; set; }
    public int TotaalWaardeKarakters { get; set; }

    // CONSTRUCTOR
    public Woord()
    {
        Input = "";
        TotaalAantalKarakters = 0;
        TotaalWaardeKarakters = 0;

        Console.WriteLine("Spel opgestart!");
    }

    //METHODES/FUNCTIES
    public void BerekenKarakters(string Input, int TotaalAantalKarakters)
    {
        foreach (char c in Input)
        {
            TotaalAantalKarakters++;
        }

        Console.WriteLine("Aantal karakters: " + TotaalAantalKarakters);
    }

    //METHODES/FUNCTIES
    public void BerekenWaarde(string Input, int TotaalWaardeKarakters)
    {
        Random random = new Random();

        foreach (char c in Input)
        {
            TotaalWaardeKarakters += random.Next(0, 26);
        }

        Console.WriteLine("Totale waarde: " + TotaalWaardeKarakters);
    }

    //POLYMORFISME (OVERLOADING)
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
        Console.WriteLine("Mode: " + Mode);
        Console.WriteLine("Totale waarde:" + TotaalWaardeKarakters);
    }

}