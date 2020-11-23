using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheCode
{
    class Dot
    {
        public int Number { get; set; }
        public string DotSize { get; set; }
        public ConsoleColor Color { get; set; }
        
        public Dot(int number, int position)
        {
            Number = number;
            DotSize = "\u2588\u2588";
            Color = ReturnColor(number);
           
        }
        public static List<Dot> CreateDotCode(int numberOfCodeDots)
        {
            List<Dot> list = new List<Dot>();
            for (int i = 0; i < numberOfCodeDots; i++)
            {
                Random random = new Random();
                list.Add(new Dot(random.Next(1, 9), i+1));
            }
            return list;
        }

        public ConsoleColor ReturnColor(int number)
        {
            switch (number)
            {
                case 1:
                    return ConsoleColor.DarkGray;
                case 2:
                    return ConsoleColor.White;
                case 3:
                    return ConsoleColor.Yellow;
                case 4:
                    return ConsoleColor.Red;
                case 5:
                    return ConsoleColor.Magenta;
                case 6:
                    return ConsoleColor.Blue;
                case 7:
                    return ConsoleColor.Cyan;
                case 8:
                    return ConsoleColor.Green;
            }
            return ConsoleColor.Black;
        }
    }
}
