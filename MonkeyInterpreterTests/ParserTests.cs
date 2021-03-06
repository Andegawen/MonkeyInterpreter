using System;
using NUnit.Framework;
using FluentAssertions;
using MonkeyInterpreter.Parsers;
using MonkeyInterpreter;
using System.Collections.Generic;
using System.Linq;
using MonkeyInterpreter.Parsers.PartialParsers;
using MonkeyInterpreter.Parsers.Structure;

namespace MonkeyInterpreterTests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void ShouldFailOnNotRecognizableCode()
        {
            var parser = new Parser(new Lexer(), new PartialParsersRegistry());

            parser.Parse("somethingNotParsable", out var errors);

            errors.Should().NotBeEmpty();
        }


        [Test]
        public void ForProperScriptThereIsNoParseErrors()
        {
            var parser = new Parser(new Lexer(), new PartialParsersRegistry());

            var statements = parser.Parse("let x = 3;", out var errors);

            errors.Should().BeEmpty();
        }

        [TestCase("let x = 3;")]
        public void ShouldParseLetStatement(string input)
        {
            var parser = new Parser(new Lexer(), new PartialParsersRegistry());

            var statements = parser.Parse(input, out var errors);

            statements.Should().BeEquivalentTo(new List<IStatement>(){
                new LetStatement(
                    new Token(TokenType.LET, "let"),
                    new Identifier(new Token(TokenType.IDENT, "x")),
                    new IntegerLiteralExpression(new Token(TokenType.INT, "3")))
                    }, options => options.RespectingRuntimeTypes());
            statements.Select(s=>s.ToString()).Should().BeEquivalentTo(new []{"LET x = 3;"});
        }

        [Test]
        public void ShouldParseMultipleLetStatementWhenOnlyLiteralExpressionsUsed()
        {
            var input =
@"let x = 3;
let y= 10;
let foobar =838383;";
            var parser = new Parser(new Lexer(), new PartialParsersRegistry());

            var statements = parser.Parse(input, out var errors);

            statements.Should().HaveCount(3, "because there are 3 statements");
            var identifierNames = statements.Cast<LetStatement>().Select(ls => ls.Identifier.Name);
            identifierNames.Should().BeEquivalentTo(new[] { "x", "y", "foobar" });
        }

        [Test]
        public void WrongTokenForStatementEndsUpWithError()
        {
            var input = @"let x == 3;";
            var parser = new Parser(new Lexer(), new PartialParsersRegistry());

            var statements = parser.Parse(input, out var errors);

            statements.Should().BeEmpty();
            errors.Should().BeEquivalentTo(new[]{
                new ParseError(StatementType.Let, TokenType.ASSIGN, TokenType.EQ),
                new ParseError(TokenType.INT),
                new ParseError(TokenType.SEMICOLON),
                });
        }

        [TestCase("return 5;")]
        //[TestCase("return 10;")]
        //[TestCase("return add(15);")]
        public void ShouldParseSimpleReturnStatement(string input)
        {
            var parser = new Parser(new Lexer(), new PartialParsersRegistry());

            var statements = parser.Parse(input, out var errors);

            statements.Should().BeEquivalentTo(new List<IStatement>(){
                new ReturnStatement(
                    new Token(TokenType.RETURN, "return"),
                    new IntegerLiteralExpression(new Token(TokenType.INT, "5")))
                    }, options => options.RespectingRuntimeTypes());
        }
    }
}