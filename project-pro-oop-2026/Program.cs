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
                Woord Woord = new Woord();

                // INPUT
                Console.WriteLine("Geef een woord of zin in:");
                Woord.input = Console.ReadLine();

                //THROW
                if (Woord.input == "")
                {
                    throw new Exception("Je moet een woord ingeven.");
                }

                //AANROEPEN METHODES/FUNCTIES (BASIS)
                Woord.BerekenKarakters(Woord.input, Woord.totaalAantalKarakters);

                //AANROEPEN METHODES/FUNCTIES (UITBREIDING)
                Woord.BerekenWaarde(Woord.input, Woord.totaalWaardeKarakters);
            }
            catch (Exception fout)
            {
                Console.WriteLine(fout.Message);
            }
        }
    }
}

//INTERFACE
interface iKarakterTeller
{
    string input { get; set; }
    int totaalAantalKarakters { get; set; }
    int totaalWaardeKarakters { get; set; }
    void BerekenKarakters(string input, int totaalAantalKarakters);
}

//KLASSEN
public class Woord : iKarakterTeller
{
    //ACCESSOR, MUTATOR (GET, SET)
    public string input { get; set; }
    public int totaalAantalKarakters { get; set; }
    public int totaalWaardeKarakters { get; set; }

    // CONSTRUCTOR
    public Woord()
    {
        input = "";
        totaalAantalKarakters = 0;
        totaalWaardeKarakters = 0;

        Console.WriteLine("Spel opgestart!");
    }

    //METHODES/FUNCTIES
    public void BerekenKarakters(string input, int totaalAantalKarakters)
    {
        foreach (char c in input)
        {
            totaalAantalKarakters++;
        }

        Console.WriteLine("Aantal karakters: " + totaalAantalKarakters);
    }

    //METHODES/FUNCTIES
    public void BerekenWaarde(string input, int totaalWaardeKarakters)
    {
        Random random = new Random();

        foreach (char c in input)
        {
            totaalWaardeKarakters += random.Next(0, 26);
        }

        Console.WriteLine("Totale waarde: " + totaalWaardeKarakters);
    }

}