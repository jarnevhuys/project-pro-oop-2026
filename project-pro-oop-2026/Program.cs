using System;

namespace Solution_Scrabble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Objecten, Variabelen
            Woord Woord = new Woord();
            string input = "";
            int totaalAantalKarakters = 0;
            int totaalWaardeKarakters = 0;

            // INPUT
            Console.WriteLine("Geef een woord of zin in:");
            input = Console.ReadLine();

            //Aanroepen Methode/Functie
            Woord.BerekenKarakters(input, totaalAantalKarakters);

            // UITBREIDING
            Random random = new Random();

            foreach (char c in input)
            {
                totaalWaardeKarakters += random.Next(0, 26);
            }

            Console.WriteLine("Totale waarde: " + totaalWaardeKarakters);
        }
    }
}

//klassen
public class Woord
{
    //accessor, mutator (get, set)
    public string input { get; set; }
    public int totaalAantalKarakters {get; set; }
    public int totaalWaardeKarakters {get; set; }

    //methoden, functies
    public void BerekenKarakters(string input, int totaalAantalKarakters)
    {
        foreach (char c in input)
        {
            totaalAantalKarakters++;
        }

        Console.WriteLine("Aantal karakters: " + totaalAantalKarakters);
    }

}