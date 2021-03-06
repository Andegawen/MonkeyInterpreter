namespace MonkeyInterpreter.Parsers.Structure
{
    public class Identifier
    {
        public Identifier(Token identifierToken)
        {
            IdentifierToken = identifierToken;
        }
        public string Name => IdentifierToken.Literal;
        public Token IdentifierToken { get; private set; }
    }
}