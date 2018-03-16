namespace MonkeyInterpreter.Parsers.Structure
{
    public class ReturnStatement : IStatement
    {
        public ReturnStatement(Token statementToken, IExpression value)
        {
            StatementToken = statementToken;
            Value = value;
        }

        public Token StatementToken { get; private set; }
        public IExpression Value { get; private set; }

        public override string ToString()
        {
            var valueString = Value!=null ? Value.ToString() : "";
            return $"{StatementToken.Type} {valueString};";
        }
    }
}