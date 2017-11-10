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
            }, options => options.WithStrictOrdering().ComparingEnumsByName());
        }

        [Test]
        public void DiscoverMoreThanOneSignTokens()
        {
            var input = @"let h5 = 5;
let ten_x = 10;

let add = fn(x,y){
x+y;
}

let result = add(h5, ten_x);";
            var lexer = new Lexer(input);

            var tokens = lexer.GetTokens();

            tokens.ShouldBeEquivalentTo(new[]
            {
                new Token(TokenType.LET, "let"),
                new Token(TokenType.IDENT, "h5"),
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.INT, "5"),
                new Token(TokenType.SEMICOLON, ";"),

                new Token(TokenType.LET, "let"),
                new Token(TokenType.IDENT, "ten_x"),
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
                new Token(TokenType.IDENT,"h5"),
                new Token(TokenType.COMMA,","),
                new Token(TokenType.IDENT,"ten_x"),
                new Token(TokenType.RPAREN,")"),
                new Token(TokenType.SEMICOLON,";"),

                new Token(TokenType.EOF, "")
            }, options => options.WithStrictOrdering().ComparingEnumsByName());
        }
    }
}