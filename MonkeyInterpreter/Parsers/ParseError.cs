namespace MonkeyInterpreter.Parsers
{
    public class ParseError
    {
        public string Title { get; private set; }
        public string Reason { get; private set; }

        public ParseError(TokenType token)
        {
            this.Title = "Wrong token";
            this.Reason = $"Not recognizable token: {token}";
        }

        public ParseError(StatementType statementType, TokenType expectedToken, TokenType tokenFound)
        {
            this.Title = $"Unexpected token in {statementType}";
            this.Reason = $"Expected {expectedToken} token, but not found {tokenFound}";
        }

        public static ParseError None { get; internal set; }
    }
    public enum StatementType
    {
        Let
    }
}