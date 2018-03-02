using System;
using System.Linq;
using MonkeyInterpreter.Parsers;
using MonkeyInterpreter;
using MonkeyInterpreter.Parsers.PartialParsers;

namespace Repl
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var parser = new Parser(new Lexer(), new PartialParsersRegistry());
            Console.WriteLine("// Monkey REPL");
            Console.WriteLine("// write `exit` to end");
            while (true)
            {
                Console.Write(">> ");
                var line = Console.ReadLine();
                if (line == "exit")
                    break;

                var statements = parser.Parse(line, out var errors);

                foreach (var statement in statements)
                {
                    Console.WriteLine(statement);
                }
            }
        }
    }
}