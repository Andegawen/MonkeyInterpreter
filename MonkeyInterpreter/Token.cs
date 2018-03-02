namespace MonkeyInterpreter
{
    public class Token
    {
        public Token(TokenType type, string literal)
        {
            Type = type;
            Literal = literal;
        }
        public TokenType Type { get; }
        public string Literal { get; }

        public override string ToString()
        {
            return $"t:`{Type}` : l:`{Literal}`";
        }
    }
}