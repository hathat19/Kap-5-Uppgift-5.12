using System;
using System.ComponentModel.Design;

namespace Uppgift5_12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Färger
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            //-------------------------------------------

            int nrOfDice = 0;
            int facesPerDie = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Hur många tärningar vill du kasta?");
                    nrOfDice = int.Parse(Console.ReadLine());

                    Console.WriteLine("Hur många sidor ska varje tärning ha?");
                    facesPerDie = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Skriv bara heltal, tack!");
                    continue;
                }
                break;
            }
            
            Random rnd = new Random();

            int[,] result = new int[nrOfDice, 2];
            /*
            result[i, 0] = värdet på tärningen (i+1)
            result[i, 1] = om tärningen är låst eller inte. Om värdet är 1 så är den låst. Om värdet är 0 är tärningen inte låst. 
             */

            Console.WriteLine("Skriv tärningens/tärningarnas nummer sepererade med ett mellanslag för att låsa den/dem!");

            //Skapa slumpvärden
            for (int i = 0; i < nrOfDice; i++)
            {

                result[i, 0] = rnd.Next(1, (facesPerDie+1));
                Console.WriteLine($"Tärning {i+1}: {result[i,0]}");
            }
            Console.WriteLine($"Skriv \"{nrOfDice+1}\" för att rulla alla.\n");

            string[] dicesLockedByUser = new string[nrOfDice];
            int nrOfDiceLocked = 0;

            while (true)
            {
                try
                {
                    dicesLockedByUser = Console.ReadLine().Split(" ");
                    string lockedOrNot = "not";

                    //Går igenom varje tal i result
                    for (int i = 0; i < nrOfDice; i++)
                    {
                        //Om redan låst, så skippa
                        if (result[i, 1] == 1)
                        {
                            continue;
                        }

                        for (int j = 0; j < dicesLockedByUser.Length; j++)
                        {
                            //Lås tärning eller ej?
                            if (int.Parse(dicesLockedByUser[j]) == i + 1)
                            {
                                result[i, 1] = 1;
                                nrOfDiceLocked += 1;
                                lockedOrNot = "locked";
                            }

                        }

                        //Om tärningen inte låstes ska ett nytt slumptal slumpas fram
                        if (lockedOrNot == "not")
                        {
                            result[i, 0] = rnd.Next(1, (facesPerDie + 1));
                        }
                    }

                    //Dvs. alla är låsta
                    if (nrOfDiceLocked == nrOfDice)
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Något gick snett, försök igen!");
                }

                //Utskrift
                for (int i = 0; i < nrOfDice; i++)
                {
                    Console.Write($"Tärning {i + 1}: {result[i, 0]}");
                    if (result[i, 1] == 1)
                    {
                        Console.Write(" (Låst)\n");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine($"Skriv \"{nrOfDice + 1}\" för att rulla alla som inte låsta.\n");
            }

            //Utskrift av resultat
            Console.WriteLine("Ditt resultat:");
            for (int i = 0; i < nrOfDice; i++)
            {
                Console.WriteLine($"Tärning {i + 1}: {result[i, 0]}");
            }
        }
    }
}
/*Skapa ett program som ska simulera tärningskast i Yatzy. När programmet börjar ska
5 tärningar kastas, tärningarna ska vara numrerade från 1 till 5. Programmet ska
skriva ut vad tärningkasten blev, därefter ska användaren få bestämma vilka
tärningar som ska låsas och därmed aldrig kastas igen. Numret för de tärningar som
ska låsas ska skrivas in på en rad sepererade med mellanslag. Därefter ska
programmet kasta om alla tärningar som inte är låsta kastas om igen, därefter
bestämmer användaren vilka tärningar som ska låsas o.s.v. Programmet ska inte
avslutas förrän användaren har låst alla tärningarna. Det ska finnas variabler längst
upp i programmets kod som bestämmer antalet tärningar som finns och hur många
sidor tärningarna har.*/