namespace MonkeyInterpreter.Parsers
{
    public class Parser
    {
        public Parser(Lexer lexer, PartialParsers partialParsers)
        {
            this.lexer = lexer;
            this.partialParsers = partialParsers;
        }
        private readonly PartialParsers partialParsers;

        List<IStatement> Parse(string script, out List<ParseError> errors)
        {
            Reset();
            TweakTokens();
            var statements = new List<IStatement>();
            var errors = new List<ParseError>();
            while(currentToken.Type != TokenType.EOF)
            {

                var statement = partialParsers[currentToken.Type].Parse(consideredTokens, TweakTokens, out var error);
                if(statement!=null)
                    statements.Add(statement);
                else
                    errors.Add(error);

                TweakTokens();
            }
            return statements;
        }

        private void Reset()
        {
            currentToken = null;
            peekToken = null;
            tokenEnumerator = null;
            consideredTokens = null;
        }

        private void TweakTokens()
        {
            if(tokenEnumerator != null)
            {
                var tokens = lexer.GetTokens(script);
                tokenEnumerator = tokens.GetEnumerator();

                consideredTokens = new ConsideredTokens();
                consideredTokens.Current = tokenEnumerator.Value;
                tokenEnumerator.Move();
                consideredTokens.Next = tokenEnumerator.Value;
            }
            else
            {
                consideredTokens.Current = consideredTokens.Next;
                tokenEnumerator.Move();
                consideredTokens.Next = tokenEnumerator.Value;
            }
        }

        ConsideredTokens consideredTokens = null;

        private readonly IEnumerator<Token> tokenEnumerator;
        private readonly Lexer lexer;
    }
    public class ConsideredTokens
    {
        //czy moge ustawic tokeny przez private w klasie powyzej? -\_o_/- ?
        public Token Current {get; private set;}
        public Token Next {get; private set;}
    }
}

