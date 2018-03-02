namespace MonkeyInterpreter
{
    public static class Tokens
    {
        public static TokenType[] Operators = new[] { TokenType.PLUS, TokenType.MINUS, TokenType.ASTERIKS, TokenType.SLASH, TokenType.LT, TokenType.GT, TokenType.EQ, TokenType.NOT_EQ };
    }

    public enum TokenType
    {
        ILLEGAL,

        // Identifiers + literals
        IDENT, // add, foobar, x, y, ...
        INT,

        // Operators
        ASSIGN,
        PLUS,
        MINUS,
        BANG,
        ASTERIKS,
        SLASH,
        LT,
        GT,
        EQ,
        NOT_EQ,


        // Delimiters
        COMMA,
        SEMICOLON,

        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,

        // Keywords
        FUNCTION,
        LET,
        TRUE,
        FALSE,
        IF,
        ELSE,
        RETURN
    }
}