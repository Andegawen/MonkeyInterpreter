using FluentAssertions;
using MonkeyInterpreter;
using NUnit.Framework;

namespace MonkeyInterpreterTests
{
    [TestFixture]
    public class LexerTests
    {
        [Test]
        public void DiscoverOneSignTokens()
        {
            var input = "=+(){},;";
            var lexer = new Lexer(input);

            var tokens = lexer.GetTokens();

            tokens.ShouldBeEquivalentTo(new[]
            {
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.PLUS, "+"),
                new Token(TokenType.LPAREN, "("),
                new Token(TokenType.RPAREN, ")"),
                new Token(TokenType.LBRACE, "{"),
                new Token(TokenType.RBRACE, "}"),
                new Token(TokenType.COMMA, ","),
                new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.EOF, "")
            });
        }

        [Test]
        public void DiscoverMoreThanOneSignTokens()
        {
            var input = @"let five = 5;
let ten = 10;

let add = fn(x,y){
x+y;
}

let result = add(five, ten);";
            var lexer = new Lexer(input);

            var tokens = lexer.GetTokens();

            tokens.ShouldBeEquivalentTo(new[]
            {
                new Token(TokenType.LET, "let"),
                new Token(TokenType.IDENT, "five"),
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.INT, "5"),
                new Token(TokenType.SEMICOLON, ";"),

                new Token(TokenType.LET, "let"),
                new Token(TokenType.IDENT, "ten"),
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.INT, "10"),
                new Token(TokenType.SEMICOLON, ";"),

                new Token(TokenType.LET, "let"),
                new Token(TokenType.IDENT, "add"),
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.FUNCTION, "fn"),
                new Token(TokenType.LPAREN, "("),
                new Token(TokenType.IDENT, "x"),
                new Token(TokenType.COMMA, ","),
                new Token(TokenType.IDENT, "y"),
                new Token(TokenType.RPAREN, ")"),
                new Token(TokenType.LBRACE, "{"),
                    new Token(TokenType.IDENT,"x"),
                    new Token(TokenType.PLUS,"+"),
                    new Token(TokenType.IDENT,"y"),
                    new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.RBRACE,"}"),

                new Token(TokenType.LET,"let"),
                new Token(TokenType.IDENT,"result"),
                new Token(TokenType.ASSIGN,"="),
                new Token(TokenType.IDENT,"add"),
                new Token(TokenType.LPAREN,"("),
                new Token(TokenType.IDENT,"five"),
                new Token(TokenType.COMMA,","),
                new Token(TokenType.IDENT,"ten"),
                new Token(TokenType.RPAREN,")"),
                new Token(TokenType.SEMICOLON,";"),

                new Token(TokenType.EOF, "")
            });
        }
    }
}