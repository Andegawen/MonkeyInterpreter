using FluentAssertions;
using MonkeyInterpreter;
using NUnit.Framework;

namespace MonkeyInterpreterTests
{
    [TestFixture]
    public class LexerTests
    {
        [Test]
        public void DiscoverEqualityOperatorWithIdentOrInt()
        {
            var input = @"5!=5
5 != 5
x==y";
            var lexer = new Lexer(input);

            var tokens = lexer.GetTokens();

            tokens.ShouldBeEquivalentTo(new[]
            {
                new Token(TokenType.INT, "5"),
                new Token(TokenType.NOT_EQ, "!="),
                new Token(TokenType.INT, "5"),

                new Token(TokenType.INT, "5"),
                new Token(TokenType.NOT_EQ, "!="),
                new Token(TokenType.INT, "5"),

                new Token(TokenType.IDENT, "x"),
                new Token(TokenType.EQ, "=="),
                new Token(TokenType.IDENT, "y"),

                new Token(TokenType.EOF, "")
            }, options => options.WithStrictOrdering().ComparingEnumsByName());
        }
        [Test]
        public void DiscoverOneSignTokens()
        {
            var input = "=+(){},;!-/*";
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

                new Token(TokenType.BANG, "!"),
                new Token(TokenType.MINUS, "-"),
                new Token(TokenType.SLASH, "/"),
                new Token(TokenType.ASTERIKS, "*"),

                new Token(TokenType.EOF, "")
            }, options => options.WithStrictOrdering().ComparingEnumsByName());
        }

        [Test]
        public void DiscoverEquality()
        {
            var input = "= == ! !=";
            var lexer = new Lexer(input);

            var tokens = lexer.GetTokens();

            tokens.ShouldBeEquivalentTo(new[]
            {
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.EQ, "=="),
                new Token(TokenType.BANG, "!"),
                new Token(TokenType.NOT_EQ, "!="),

                new Token(TokenType.EOF, "")
            }, options => options.WithStrictOrdering().ComparingEnumsByName());
        }


        [Test]
        public void DiscoverCondition()
        {
            var input = @"if(5<10){ return true;
} else{
return false;
}
";
            var lexer = new Lexer(input);

            var tokens = lexer.GetTokens();

            tokens.ShouldBeEquivalentTo(new[]
            {
                new Token(TokenType.IF, "if"),
                new Token(TokenType.LPAREN, "("),
                    new Token(TokenType.INT, "5"),
                    new Token(TokenType.LT, "<"),
                    new Token(TokenType.INT, "10"),
                new Token(TokenType.RPAREN, ")"),

                new Token(TokenType.LBRACE, "{"),
                    new Token(TokenType.RETURN, "return"),
                    new Token(TokenType.TRUE, "true"),
                    new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.RBRACE, "}"),

                new Token(TokenType.ELSE, "else"),

                new Token(TokenType.LBRACE, "{"),
                    new Token(TokenType.RETURN, "return"),
                    new Token(TokenType.FALSE, "false"),
                    new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.RBRACE, "}"),

                new Token(TokenType.EOF, "")
            }, options => options.WithStrictOrdering().ComparingEnumsByName());
        }

        [Test]
        public void DiscoverOperatorLTandGT()
        {
            var input = "5 < 10 > 5;";
            var lexer = new Lexer(input);

            var tokens = lexer.GetTokens();

            tokens.ShouldBeEquivalentTo(new[]
            {
                new Token(TokenType.INT, "5"),
                new Token(TokenType.LT, "<"),
                new Token(TokenType.INT, "10"),
                new Token(TokenType.GT, ">"),
                new Token(TokenType.INT, "5"),

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