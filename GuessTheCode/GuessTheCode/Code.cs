using System;
using System.Collections.Generic;

namespace GuessTheCode
{
    class Code
    {
        public List<Dot> CodeList { get; set; }
        public int[] GuessedCodeResult { get; set; }

        public static int[] Guessed = new int[2] { 0, 0 };
        public static Code SecretCode { get; set; }
        public static List<Code> ListOfCodes { get; set; }
        public static bool CodeRevealed = false;

        public Code(int numberOfLenght)
        {
            CodeList = Dot.CreateDotCode(numberOfLenght);

        }
        public Code(List<Dot> list)
        {
            CodeList = list;
            GuessedCodeResult = new int[2];
        }

        public static void PlayField(List<Code> listOfCodes)
        {
            for (int i = 0; i < listOfCodes.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n\t\t\t\tGUESS {i + 1}:  ");
                for (int j = 0; j < listOfCodes[i].CodeList.Count; j++)
                {
                    Console.Write("   ");
                    Console.ForegroundColor = listOfCodes[i].CodeList[j].Color;
                    Console.Write(listOfCodes[i].CodeList[j].DotSize);

                }
                listOfCodes[i].PrintSmallDots();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t\t\t-----------------------------------------------------------");

        }
        public static void PrintCode(Code code)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t\t\t-----------------------------------------------------------");
            Console.WriteLine("\t\t\t\t    ----------------------------------");
            Console.Write($"\t\t\t\tSECRET CODE: ");
            for (int i = 0; i < code.CodeList.Count; i++)
            {
                Console.Write("   ");
                Console.ForegroundColor = code.CodeList[i].Color;
                Console.Write(code.CodeList[i].DotSize);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t\t\t\t    ----------------------------------");
            Console.WriteLine("\t\t\t-----------------------------------------------------------");
        }

        private void PrintSmallDots()
        {
            Console.Write("\t\t");
            for (int i = 0; i < GuessedCodeResult[0]; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\u2584 ");
            }
            for (int i = 0; i < GuessedCodeResult[1]; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\u2584 ");
            }
        }
        public static void CompareCodeWithSecretCode(int whichToCompare)
        {

            int rightPosition = 0;
            int rightColorWrongPosition = 0;

            int[] copySecretCode = new int[Program.LengthOfCode];
            for (int i = 0; i < SecretCode.CodeList.Count; i++)
            {
                copySecretCode[i] = SecretCode.CodeList[i].Number;
            }
            int[] copyGuess = new int[Program.LengthOfCode];
            for (int i = 0; i < ListOfCodes[whichToCompare].CodeList.Count; i++)
            {
                copyGuess[i] = ListOfCodes[whichToCompare].CodeList[i].Number;
            }

            for (int i = 0; i < copyGuess.Length; i++)
            {
                if (copyGuess[i] == copySecretCode[i])
                { rightPosition++;
                    copySecretCode[i] = 0;
                    copyGuess[i] = 100;
                }

            }
            for (int i = 0; i < copyGuess.Length; i++)
            {
                for (int j = 0; j < copySecretCode.Length; j++)
                {
                    if (copyGuess[i] == copySecretCode[j])
                    {
                        rightColorWrongPosition++;
                        copySecretCode[j] = 0;
                        copyGuess[i] = 100;
                        continue;
                    }
                }
            }
        
            ListOfCodes[whichToCompare].GuessedCodeResult[0] = rightPosition;
            ListOfCodes[whichToCompare].GuessedCodeResult[1] = rightColorWrongPosition;

            IsGameFinished(rightPosition);
        }

        public static void IsGameFinished(int numberOfRightGuessed)
        {
            CodeRevealed = numberOfRightGuessed == Program.LengthOfCode;
            if (CodeRevealed)
            { Program.EndTime = DateTime.Now; }
        }
        

       
    }
}
