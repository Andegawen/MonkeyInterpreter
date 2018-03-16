namespace MonkeyInterpreter.Parsers.Structure
{
    ///<summary>
    ///It's an wrapper around expression
    ///</summary> 
    public class ExpressionStatement : IStatement
    {
        public ExpressionStatement(IExpression value)
        {
            Value = value;
        }

        public Token StatementToken { get{return Value.FirstTokenInExpression;} }
        public IExpression Value { get; private set; }

        public override string ToString()
        {
            return Value!=null ? Value.ToString() : "";
        }
    }
}