using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvausPeliCA
{
    class Program
    {
        static void Main(string[] args)
        {
            //Muuttujien alustaminen:
            List<int> GuessedList = new List<int>();        

            Random GuessNumber = new Random();

            int guessed = 0;
            int rounds = 0;
            int randomNumber = GuessNumber.Next(1, 100);

            DateTime guessStart = DateTime.Now;
            DateTime guessEnd;

            Double timeDifference;

            CultureInfo culture = new CultureInfo("fi-FI");

            Console.WriteLine("Try to guess the right number between 1 and 100.");

            //Luupataan arvausta, niinkauan kuin pelaaja arvaa oikean luvun:
            while (randomNumber != guessed)                       

            {
                guessed = int.Parse(Console.ReadLine());
                rounds = rounds + 1;
                GuessedList.Add(guessed);

                if (guessed > randomNumber)

                {
                    Console.WriteLine("Number is smaller, pls try again.");
                }

                else if (guessed < randomNumber)
                {
                    Console.WriteLine("Number is bigger, pls guess again.");
                }
            }

            //Kun oikea random numero on arvattu, lasketaan arvauskerrat ja arvaukseen kulunut aika
            guessEnd = DateTime.Now;
            timeDifference = guessEnd.Subtract(guessStart).TotalSeconds;

            Console.WriteLine("Congatulations, your guessnumber is right! It took" + " " + rounds + " " + "times" + " " +  "to guess.",
                                "Time spent: " + timeDifference + " seconds.");

            //Listataan arvatut numerot:
            Console.WriteLine("List of numbers guessed: ");

            for (int i = 0; i< GuessedList.Count; i++)
            {
                Console.Write(GuessedList[i] + " ");
            }


            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
