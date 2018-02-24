namespace MonkeyInterpreter.Parsers
{
    public class LetStatement : IStatement
    {
        public LetStatement(Token token, Identifier identifier, IExpression value)
        {
            Token = token;
            Identifier = identifier;
            Value = value;
        }

        public Token Token {get;private set;}
        public Identifier Identifier {get;private set;}
        public IExpression Value {get; private set;}

        public override string ToString()
        {
            return $"Statement {Token.Type} with Identifier `{Identifier.Name}` {Value}";
        }
    }
}