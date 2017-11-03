using System;

namespace MonkeyInterpreter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">> ");
                var line = Console.ReadLine();
                if(line == "exit")
                    break;

                var lexer = new Lexer(line);
                var tokens = lexer.GetTokens();
            }
        }
    }
}