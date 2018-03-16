namespace MonkeyInterpreter.Parsers.Structure
{

    public class OperatorExpression : IExpression
    {
        public OperatorExpression(IntegerLiteralExpression left, IExpression right, Token operatorToken)
        {
            Left = left;
            Right = right;
            Operator = operatorToken;
        }
        public Token Operator { get; private set; }
        public IntegerLiteralExpression Left { get; private set; }
        public IExpression Right { get; private set; }

        public Token FirstTokenInExpression => Left.FirstTokenInExpression;
    }
}