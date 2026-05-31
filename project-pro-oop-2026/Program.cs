using System;

namespace Solution_Scrabble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Object aanmaken
            Woord Woord = new Woord();

            // INPUT
            Console.WriteLine("Geef een woord of zin in:");
            Woord.input = Console.ReadLine();

            //Aanroepen Methode/Functie (basis)
            Woord.BerekenKarakters(Woord.input, Woord.totaalAantalKarakters);

            //Aanroepen Methode/Fucntie (uitbreiding)
            Woord.BerekenWaarde(Woord.input, Woord.totaalWaardeKarakters);
            
        }
    }
}

//interface
interface iKarakterTeller
{
    string input { get; set; }
    int totaalAantalKarakters { get; set; }
    int totaalWaardeKarakters { get; set; }
    void BerekenKarakters(string input, int totaalAantalKarakters);
}

//klassen
public class Woord : iKarakterTeller
{
    //accessor, mutator (get, set)
    public string input { get; set; }
    public int totaalAantalKarakters { get; set; }
    public int totaalWaardeKarakters { get; set; }

    // Constructor
    public Woord()
    {
        input = "";
        totaalAantalKarakters = 0;
        totaalWaardeKarakters = 0;

        Console.WriteLine("Spel opgestart!");
    }

    //methoden, functies
    public void BerekenKarakters(string input, int totaalAantalKarakters)
    {
        foreach (char c in input)
        {
            totaalAantalKarakters++;
        }

        Console.WriteLine("Aantal karakters: " + totaalAantalKarakters);
    }

    //methoden, fucnties
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