namespace MonkeyInterpreter.Parsers
{
    public class LetStatement : IStatement
    {
        public LetStatement(Token token, Identifier name, IExpression value)
        {
            Token = token;
            Name = name;
            Value = value;
        }

        public Token Token {get;private set;}
        public Identifier Name {get;private set;}
        public IExpression Value {get; private set;}
    }
}