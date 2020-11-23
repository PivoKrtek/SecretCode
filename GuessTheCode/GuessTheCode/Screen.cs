using System;
using System.Collections.Generic;

namespace GuessTheCode
{
    class Screen
    {
        public static void Welcome()
        {
            GameName();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tYour mission is to find out the secret code, as fast as you can.");
            Console.WriteLine("\tThe code consists of 3-6 secret colors, in a certain order.");
            Console.WriteLine("\tIf your guessed code has a position with right color, you will get a WHITE mark in the side.");
            Console.WriteLine("\tBut you don't know which position is right.");
            Console.WriteLine("\tIf you have guessed on a color, but it is on wrong position, you will get a gray mark in the side.\n");
            Program.LengthOfCode = ChooseTheLevel();

            Console.WriteLine("\n\t\tPress ENTER to start (That also means you will start time running!).");
        }
        public static void GameName()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            // Console.WriteLine("\n\t ██████╗ ██╗   ██╗███████╗███████╗███████╗     ██████╗ ██████╗ ██████╗ ███████╗\n\t██╔════╝ ██║   ██║██╔════╝██╔════╝██╔════╝    ██╔════╝██╔═══██╗██╔══██╗██╔════╝\n\t██║  ███╗██║   ██║█████╗  ███████╗███████╗    ██║     ██║   ██║██║  ██║█████╗  \n\t██║   ██║██║   ██║██╔══╝  ╚════██║╚════██║    ██║     ██║   ██║██║  ██║██╔══╝  \n\t╚██████╔╝╚██████╔╝███████╗███████║███████║    ╚██████╗╚██████╔╝██████╔╝███████╗\n\t ╚═════╝  ╚═════╝ ╚══════╝╚══════╝╚══════╝     ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝");
            Console.WriteLine("\n\t███████╗███████╗ ██████╗██████╗ ███████╗████████╗     ██████╗ ██████╗ ██████╗ ███████╗\n\t██╔════╝██╔════╝██╔════╝██╔══██╗██╔════╝╚══██╔══╝    ██╔════╝██╔═══██╗██╔══██╗██╔════╝\n\t███████╗█████╗  ██║     ██████╔╝█████╗     ██║       ██║     ██║   ██║██║  ██║█████╗  \n\t╚════██║██╔══╝  ██║     ██╔══██╗██╔══╝     ██║       ██║     ██║   ██║██║  ██║██╔══╝  \n\t███████║███████╗╚██████╗██║  ██║███████╗   ██║       ╚██████╗╚██████╔╝██████╔╝███████╗\n\t╚══════╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚══════╝   ╚═╝        ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝");
        }
        public static void HiddenSecretCode()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t\t\t-----------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t    ----------------------------------");
            Console.WriteLine("\t\t\t\t     *Here under is your secret code*");
            Console.WriteLine("\t\t\t\t    ----------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t-----------------------------------------------------------");
        }
            
        public static int ChooseTheLevel()
        {
            Console.WriteLine("\tAt first choose, how many positions should your secret code consists of? (3 - 6)");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\t\t3 - Easy");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t4 - Medium");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t5 - Hard");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t6 - Advanced");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tChoose and press ENTER.");
            Console.Write("\tYour choice: ");
            return InputNumber(3, 6);
            
        }
        public static void Choices()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n\t\t\t1.\t2.\t3.\t4.\t5.\t6.\t7.\t8.\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\t\t\t██");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t██");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t██");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\t██");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\t██");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\t██");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t██");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t██\n");
        }
        public static void Result(int lapNumber)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Program.ReturnSeconds();
            Console.WriteLine($"\n\n\t\t\t\tCONGRATULATIONS! You figured out the secret code!");
            Console.WriteLine($"\t\t\t\tYou managed on {lapNumber} guesses and {Program.Seconds} seconds.\n");
        }

        public static void ChooseYourGuess()
        {
            List<Dot> lista = new List<Dot>();
            
            for (int i = 0; i < Program.LengthOfCode; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"\n\t\t\t\tWhat is your guess for each position?");
                    Console.WriteLine($"\t\t\t\tPress number and then ENTER: ");
                }
                Console.Write($"\t\t\t\tPosition {i + 1}: ");
                int choice = InputNumber(1,8);
                
                lista.Add(new Dot(choice, i + 1));
            }
            Code.ListOfCodes.Add(new Code(lista));

        }
        public static int InputNumber(int minimumchoice, int maxchoice)
        {
            bool ok;
            int inputNumber = 0;

            while (true)
            {
                ok = int.TryParse(Console.ReadLine(), out inputNumber);
                if (!ok || inputNumber < minimumchoice || inputNumber > maxchoice)
                {
                    Console.WriteLine("\t\t\t\tWrong input. Try again.");
                }
                else { break; }
            }
            return inputNumber;
        }
        public static int InputNumber(List<int> lista, int position)
        {
            bool ok;
            int inputNumber = 0;

            while (true)
            {
                ok = int.TryParse(Console.ReadLine(), out inputNumber);
                if (!ok)
                {
                    Console.WriteLine("\t\t\t\tWrong input. Try again.");
                }
                else if (ok)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (inputNumber == lista[i])
                            return inputNumber;
                    }
                    Console.WriteLine("\t\t\t\tWrong input. Try again.");
                }
                else
                {
                    Console.WriteLine("\t\t\t\tWrong input. Try again.");
                }
                Console.Write($"\t\t\t\tPosition {position}: ");
            }
        }
        public static void PlayAgain()
        {
            Console.WriteLine("\t\t\t\tWant to play again?");
            Console.WriteLine("\t\t\t\t[1] --> YES!");
            Console.WriteLine("\t\t\t\t[0] --> NO.");
            Console.Write("\t\t\t\t");
        }

        public static void BetterLuck()
        {
            Console.WriteLine("\t\t\t\tBetter luck next time!\n\n");
        }

        public static void YouMadeItToList()
        {
            Console.WriteLine("\t\t\t\tCongratulations, you made it to the list!");
        }
    }
}
