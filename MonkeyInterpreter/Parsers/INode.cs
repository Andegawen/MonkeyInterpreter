namespace MonkeyInterpreter.Parsers
{
    public interface INode {
        Token Token { get; }
    }

    public interface IStatement : INode {}
    public interface IExpression {}

    public class OperatorExpression : IExpression
    {
        public OperatorExpression(IntegerLiteralExpression left, IExpression right, Token operatorToken)
        {
            Left = left;
            Right = right;
            Operator = operatorToken;
        }
        public Token Operator {get;private set;}
        public IntegerLiteralExpression Left {get;private set;}
        public IExpression Right {get; private set;}
    }

    public class IntegerLiteralExpression : IExpression
    {
        public IntegerLiteralExpression(Token token)
        {
            Token = token;
        }
        public Token Token {get; private set;}

        public override string ToString()
        {
            return Token.Literal;
        }
    }
}