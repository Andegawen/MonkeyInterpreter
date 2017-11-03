namespace MonkeyInterpreter
{
    public enum TokenType
    {
        ILLEGAL,
        EOF,

        // Identifiers + literals
        IDENT, // add, foobar, x, y, ...
        INT,

        // Operators
        ASSIGN,
        PLUS,
        

        // Delimiters
        COMMA,
        SEMICOLON,

        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,

        // Keywords
        FUNCTION,
        LET
    }
}