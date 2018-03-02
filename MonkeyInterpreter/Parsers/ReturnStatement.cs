namespace MonkeyInterpreter.Parsers
{
    public class ReturnStatement : IStatement
    {
        public ReturnStatement(Token statementToken, IExpression value)
        {
            StatementToken = statementToken;
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