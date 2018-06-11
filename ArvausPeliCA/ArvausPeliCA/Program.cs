using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ArvausPeliCA
{
    class Program
    {
        static void Main(string[] args)
        {
            //Taustavärien määritykset
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            //Tuodaan musiikit sovellukseen
            //SoundPlayer soundPlayer = new SoundPlayer();
            //soundPlayer.SoundLocation = @"D:\VisualStudio2017\ArvausPeliCA\ArvausPeliCA\ArvausPeliCA\abba_-_the_winner_takes_it_all-92cwKCU8Z5c_fmt43.wav";

            //soundPlayer.LoadAsync();
            //soundPlayer.Play();

            string file = @"D:\VisualStudio2017\ArvausPeliCA\ArvausPeliCA\GuessList.txt"; //aiemman arvauksen sisälttävä tekstitiedosto
            //haetaan aiempi vastaus
            string previousGuess = File.ReadAllText(file);

            //Muuttujien alustaminen:
            Random GuessNumber = new Random();

            int guessed = 0;
            int rounds = 0;
            int randomNumber = GuessNumber.Next(1, 100);
            string name;

            DateTime guessStart = DateTime.Now;
            DateTime guessEnd;

            Boolean ok = false;

            Double timeDifference;

            CultureInfo culture = new CultureInfo("fi-FI");

            List<int> GuessedList = new List<int>();

            //Kerrotaan edellisen kierroksen oikea vastaus
            Console.Write("Previous guess was " + previousGuess + ".");
            Console.WriteLine();

            //Toivotetaan pelaaja tervetulleeksi
            Console.WriteLine("Hello, Welcome to the random guess game! Press enter to continue>");
            Console.ReadLine();

            //Pyydetään pelaajaa kertomaan nimensä
            Console.WriteLine("What's, your name? ");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + ", lets start the game. Press enter to continue>");
            Console.ReadLine();

            //Pyydetään pelaajaa arvaamaan numero väliltä 1-100
            Console.WriteLine("Try to guess the right number between 1 and 100.");

            //Luupataan arvausta, niinkauan kuin pelaaja arvaa oikean luvun:
            while (randomNumber != guessed)
            {
                try { 
                guessed = int.Parse(Console.ReadLine());
                rounds = rounds + 1;
                GuessedList.Add(guessed);

                  

                    if (guessed > randomNumber)

                {
                    Console.WriteLine("Number is smaller, pls try again.");
                }
                    if (guessed > 100)
                    {
                        Console.WriteLine("Your number is over 100, use only numbers between 1-100.");
                    }


                    else if (guessed < randomNumber)
                {
                    Console.WriteLine("Number is bigger, pls guess again.");
                }
            }
                catch
                {
                    Console.WriteLine("Use only numbers (1-100)!");
                    ok = false;
                }
            }


            //Kun oikea random numero on arvattu, lasketaan arvauskerrat ja arvaukseen kulunut aika
            guessEnd = DateTime.Now;

                timeDifference = guessEnd.Subtract(guessStart).TotalSeconds;

                Console.WriteLine("Congatulations, your guessnumber is right! It took" + " " + rounds + " " + "times" + " " + "to guess.",
                                    "Time spent: " + timeDifference + " seconds.");
            if (GuessedList.Count < 6)
            {
                Console.WriteLine("****** Tämä on Loisto suoritus! ******");
            }
            else if (GuessedList.Count > 6 && GuessedList.Count < 11)
            {
                Console.WriteLine("****** Tämä on keskinkertainen suoritus!");
            }
            else
            {
                Console.WriteLine("****** Tämä on sait sentään suoritettua!");
            }

            //Listataan arvatut numerot:
            Console.WriteLine("List of numbers guessed: ");

                for (int i = 0; i < GuessedList.Count; i++)
                {
                    //Console.Write(i + GuessedList[i].ToString() + " ");

                    Console.WriteLine("Kierroksella " + (i + 1) + " arvaus oli: " + GuessedList[i].ToString());
                }

               

                Console.WriteLine("");
                Console.WriteLine("");
                File.WriteAllText(file, guessed.ToString()); //oikean arvauksen tallentaminen tekstitiedostoon
                Console.Write("Press any key to quit the random number game>");
                Console.ReadLine();


            }
        }
    }

    


