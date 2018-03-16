namespace MonkeyInterpreter.Parsers.Structure
{
    public class IntegerLiteralExpression : IExpression
    {
        public IntegerLiteralExpression(Token token)
        {
            Token = token;
        }
        public Token Token { get; private set; }

        public Token FirstTokenInExpression => Token;

        public override string ToString()
        {
            return Token.Literal;
        }
    }
}