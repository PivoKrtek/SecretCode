using System;
using System.Collections.Generic;

namespace GuessTheCode
{
    class Program
    {
        public static int LengthOfCode { get; set; }
        public static DateTime StartTime { get; set; }
        public static DateTime EndTime { get; set; }
        public static int Seconds { get; set; }
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 45);
            bool playAgain = true;

            while (playAgain)
            {
                playAgain = false;
                Code.CodeRevealed = false;
                Screen.Welcome();
                Code.SecretCode = new Code(LengthOfCode);
                Code.ListOfCodes = new List<Code>();
                Console.ReadLine();
                StartTime = DateTime.Now;
                int LapCounter = 0;

                while (!Code.CodeRevealed)
                {
                    Console.Clear();
                    for (int j = 0; j < Code.SecretCode.CodeList.Count; j++)
                    {
                        Console.Write($"{Code.SecretCode.CodeList[j].Number}");
                    }
                    Screen.GameName();
                    Screen.Choices();
                    Screen.HiddenSecretCode();
                    Code.PlayField(Code.ListOfCodes);
                    Screen.ChooseYourGuess();
                    Code.CompareCodeWithSecretCode(LapCounter);
                    LapCounter++;
                }
                Console.Clear();
                Screen.GameName();
                Screen.Choices();
                Screen.Result(LapCounter);
                Code.PrintCode(Code.SecretCode);
                Console.ReadLine();

                Console.Clear();
                Screen.GameName();
                Highscore.OpenAndPrintHighscore();
                Screen.Result(LapCounter);
                Console.ForegroundColor = ConsoleColor.Red;
                int maybeHighscore = Highscore.SeeIfHighscore(LapCounter, Seconds, LengthOfCode-3);
                if (maybeHighscore < 5)
                {
                    Screen.YouMadeItToList();
                    Highscore.PutHighScoreInList(maybeHighscore+(LengthOfCode-3)*5, LapCounter);
                    Highscore.PutHighScoreInFile();
                    Console.Clear();
                    Screen.GameName();
                    Highscore.OpenAndPrintHighscore();
                }
                else
                {
                    Screen.BetterLuck();
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Screen.PlayAgain();
                int choice = Screen.InputNumber(0, 1);
                if (choice == 1)
                { playAgain = true; }
                Console.Clear();
            }

        }
        public static void ReturnSeconds()
        {
            Seconds = (int)Math.Round((EndTime - StartTime).TotalSeconds, 0);
        }
    }
}
