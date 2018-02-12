namespace MonkeyInterpreter.Parsers
{
    public class Identifier : INode
    {
        public Identifier(Token token)
        {
            Token = token;
        }
        public string Name => Token.Literal;
        public Token Token { get; private set; }
    }
}