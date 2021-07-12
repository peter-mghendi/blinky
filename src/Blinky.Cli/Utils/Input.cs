using System;

namespace Blinky.Cli.Utils
{
    public class Input
    {
        private const string _errorPrompt = "ERROR! Invalid input. Try again.\n> ";

        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            Console.Write(prompt);
            return (!int.TryParse(Console.ReadLine(), out int output) || output < min || output > max)
                ? ReadInt(_errorPrompt, min, max)
                : output;
        }
    }
}