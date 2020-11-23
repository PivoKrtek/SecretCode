using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GuessTheCode
{
    class Highscore 
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Seconds { get; set; }

        public static List<Highscore> HighscoreList { get; set; }
        public Highscore(string name, int points, int seconds)
        {
            Name = name;
            Points = points;
            Seconds = seconds;
        }
        public static void OpenHighscores()
        {
            if (!File.Exists("secretcodehighscore.txt"))
            {
                StreamWriter sw = File.CreateText("secretcodehighscore.txt");
                for (int i = 0; i < 20; i++)
                {
                    sw.WriteLine("---;0;0");
                }
                sw.Close();
            }
            string[] lines = File.ReadAllLines("secretcodehighscore.txt");
            List<Highscore> highscoreList = new List<Highscore>();

            foreach (string line in lines)
            {
                string[] nameAndPoints = line.Split(';');
                int points = int.Parse(nameAndPoints[1]);
                int seconds = int.Parse(nameAndPoints[2]);
                highscoreList.Add(new Highscore(nameAndPoints[0], points, seconds));

            }
            HighscoreList = highscoreList;
        }
        public static void PrintOutHighscores()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~HIGHSCORE SECRET CODE~~~~*~~~~*~");
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~*~~~~*~~~~*~~~~*~~~~*~~~~*~~~~*~");
            Console.WriteLine("\t\t\t\t-------------------------------------------");
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~ Secret Code 3 ~~~~*~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{counter}. {HighscoreList[i].Name}, {HighscoreList[i].Points} guesses, {HighscoreList[i].Seconds} seconds.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~ Secret Code 4 ~~~~*~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            counter = 1;
            for (int i = 5; i < 10; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{counter}. {HighscoreList[i].Name}, {HighscoreList[i].Points} guesses, {HighscoreList[i].Seconds} seconds.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~ Secret Code 5 ~~~~*~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            counter = 1;
            for (int i = 10; i < 15; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{counter}. {HighscoreList[i].Name}, {HighscoreList[i].Points} guesses, {HighscoreList[i].Seconds} seconds.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~ Secret Code 6 ~~~~*~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            counter = 1;
            for (int i = 15; i < 20; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{counter}. {HighscoreList[i].Name}, {HighscoreList[i].Points} guesses, {HighscoreList[i].Seconds} seconds.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t-------------------------------------------");
        }

        public static int SeeIfHighscore(int point, int seconds, int level)
        {
            int counter = 0;
            for (int i = 0+5*level; i < 5+5*level; i++)
            {
                if (HighscoreList[i].Points > point || HighscoreList[i].Points == 0)
                { return counter; }
                else if (HighscoreList[i].Points == point)
                {
                    if (HighscoreList[i].Seconds > seconds)
                    { return counter; }
                }
                counter++;
            }
            
            return 100;
        }

        public static string GetName()
        {
            Console.Write("\t\t\t\tWrite your name: ");
            string name = Console.ReadLine();
            return name;
        }
        public static void PutHighScoreInFile()
        {
            int counter = 0;
            StreamWriter sw = File.CreateText("secretcodehighscore.txt");
            foreach (var line in HighscoreList)
            {


                sw.WriteLine($"{line.Name};{line.Points};{line.Seconds}");
                counter++;
                if (counter == 20)
                { break; }
            }
            sw.Close();
        }
        public static void OpenAndPrintHighscore()
        {
            
            Highscore.OpenHighscores();
            Highscore.PrintOutHighscores();
            Console.WriteLine();
        }
        public static void PutHighScoreInList(int place, int lap)
        {
            Highscore highscore = new Highscore(Highscore.GetName(), lap, Program.Seconds);

            Highscore.HighscoreList.Insert(place, highscore);
            if (place < 5)
            {
                Highscore.HighscoreList.RemoveAt(5);
            }
            else if (place > 4 && place < 10)
            {
                Highscore.HighscoreList.RemoveAt(10);
            }
            else if (place > 9 && place < 15)
            {
                Highscore.HighscoreList.RemoveAt(15);
            }

        }
    }
}
