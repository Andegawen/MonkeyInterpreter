using System;
using System.Linq;
using MonkeyInterpreter;
using NUnit.Framework;

namespace MonkeyInterpreterTests
{
    [TestFixture]
    public class LexerTests
    {
        [Test]
        public void Le()
        {
            var input = "=+(){},;";
            var lexer = new Lexer(input);

            var tokens = lexer.GetTokens().Select(t=>t.Type).ToArray();
            
            CollectionAssert.AreEqual(new[]
            {
               TokenType.ASSIGN,
               TokenType.PLUS,
               TokenType.LPAREN,
               TokenType.RPAREN,
               TokenType.LBRACE,
               TokenType.RBRACE,
               TokenType.COMMA,
               TokenType.SEMICOLON,
               TokenType.EOF
            }, tokens);
        }
    }
}