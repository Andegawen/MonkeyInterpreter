using System;
using NUnit.Framework;
using FluentAssertions;
using  MonkeyInterpreter.Parsers;
using  MonkeyInterpreter;

namespace MonkeyInterpreterTests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void ShouldFailOnNotRecognizableCode()
        {
            var parser = new Parser(new Lexer(), new PartialParsers());

            parser.Parse("somethingNotParsable", out var errors);

            errors.Should().NotBeEmpty();
        }

        
        [Test]
        public void ForProperScriptThereIsNoParseErrors()
        {
            var parser = new Parser(new Lexer(), new PartialParsers());

            var statements = parser.Parse("let x = 3;", out var errors);

            errors.Should().BeEmpty();
        }

        [TestCase("let x = 3;")]
        public void ShouldParseLetStatement(string intput)
        {
            var parser = new Parser(new Lexer(), new PartialParsers());

            var statements = parser.Parse(intput, out var errors);

            statements.Should().BeEquivalentTo(new []{
                new LetStatement(
                    new Token(TokenType.LET, "let"),
                    new Identifier(new Token(TokenType.IDENT, "x")),
                    new IntegerLiteralExpression(new Token(TokenType.INT, ";"))) //it should fail because it is `;`
                    }, options=>options.RespectingRuntimeTypes());
        }
    }
}