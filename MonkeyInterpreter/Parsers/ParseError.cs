namespace MonkeyInterpreter.Parsers
{
    public class ParseError
    {
        private string statementName;
        private string reason;

        public ParseError(string statementName, string reason)
        {
            this.statementName = statementName;
            this.reason = reason;
        }

        public static ParseError None { get; internal set; }
    }
}