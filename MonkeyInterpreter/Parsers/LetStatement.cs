namespace MonkeyInterpreter.Parsers
{
    public class LetStatement : IStatement
    {
        public LetStatement(Token statmentToken, Identifier identifier, IExpression value)
        {
            StatementToken = statmentToken;
            Identifier = identifier;
            Value = value;
        }

        public Token StatementToken { get; private set; }
        public Identifier Identifier { get; private set; }
        public IExpression Value { get; private set; }

        public override string ToString()
        {
            return $"Statement {StatementToken.Type} with Identifier `{Identifier.Name}` {Value}";
        }
    }
}