using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kodai
{
    class MyConsole
    {

        public static void StatusWriteLine(string text, bool status)
        {
            if (status)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void StatusWrite(string text, bool status)
        {
            if (status)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(text);
            Console.ResetColor();

            Console.Write(" : ");
        }


        public static void ColoredWriteLine(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        public static void ColoredWrite(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(line);
            Console.ResetColor();
        }

    }
}
