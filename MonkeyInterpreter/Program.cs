using System;
using System.Linq;

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

                var tokens = new Lexer(line).GetTokens().Select(t => t.ToString());
                
                Console.WriteLine(
                    string.Join(",\n", tokens));
            }
        }
    }
}