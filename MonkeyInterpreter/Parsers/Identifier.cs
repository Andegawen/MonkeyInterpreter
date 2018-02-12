namespace MonkeyInterpreter.Parsers
{
    public class Identifier : INode
    {
        public Identifier(string name, Token token)
        {
            Name = name;
            Token = token;
        }
        public string Name => Token.Literal;
        public Token Token { get; private set; }
    }
}