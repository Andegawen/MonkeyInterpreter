using System;
using System.Linq;
using MonkeyInterpreter.Parsers;

namespace MonkeyInterpreter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var parser = new Parser()
            while (true)
            {
                Console.Write(">> ");
                var line = Console.ReadLine();
                if(line == "exit")
                    break;

                var statements = parser.Parse(line);

                foreach (var statement in statements)
                {
                    Console.WriteLine(statement.GetLiteral());
                }
            }
        }
    }
}