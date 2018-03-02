using System.Collections.Generic;

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

        public List<IStatement> Parse(string script, out List<ParseError> errors)
        {
            Reset();
            var tokens = lexer.GetTokens(script);
            tokenEnumerator = tokens.GetEnumerator();

            TweakTokens();
            var statements = new List<IStatement>();
            errors = new List<ParseError>();
            while (consideredTokens.Current != null)
            {
                if (partialParsers.TryGetParser(consideredTokens.Current.Type, out var partialParser))
                {
                    var statement = partialParser.Parse(consideredTokens, TweakTokens, out var error);
                    if (statement != null)
                        statements.Add(statement);
                    else
                        errors.Add(error);
                }
                else
                {
                    errors.Add(new ParseError(consideredTokens.Current.Type));
                    TweakTokens();
                }
            }
            return statements;
        }

        private void Reset()
        {
            consideredTokens = null;
            tokenEnumerator = null;
            consideredTokens = null;
        }

        private void TweakTokens()
        {
            if (consideredTokens == null)
            {
                tokenEnumerator.MoveNext(); // start enumeration
                consideredTokens = new ConsideredTokens();
                consideredTokens.Current = tokenEnumerator.Current;
                tokenEnumerator.MoveNext();
                consideredTokens.Next = tokenEnumerator.Current;
            }
            else
            {
                consideredTokens.Current = consideredTokens.Next;
                tokenEnumerator.MoveNext();
                consideredTokens.Next = tokenEnumerator.Current;
            }
        }

        private void FindFirstNotSkipWhiteCharacters()
        {
            //tokenEnumerator.MoveNext();            
        }

        ConsideredTokens consideredTokens = null;
        private IEnumerator<Token> tokenEnumerator;
        private readonly Lexer lexer;
    }
    public class ConsideredTokens
    {
        //czy moge ustawic tokeny przez private w klasie powyzej? -\_o_/- ?
        public Token Current { get; internal set; }
        public Token Next { get; internal set; }
    }
}

