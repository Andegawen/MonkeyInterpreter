using System;

namespace MonkeyInterpreter.Parsers
{
    public class LetStatementParser : IPartialParser
    {
        public TokenType Key => TokenType.LET;

        public IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
        {
            var letToken = consideredTokens.Current;
            tweakTokens();


            if (consideredTokens.Current.Type != TokenType.IDENT)
            {
                error = new ParseError(StatementType.Let, TokenType.IDENT, consideredTokens.Current.Type);
                tweakTokens();
                return null;
            }
            var identifer = new Identifier(consideredTokens.Current);
            tweakTokens();


            if (consideredTokens.Current.Type != TokenType.ASSIGN)
            {
                error = new ParseError(StatementType.Let, TokenType.ASSIGN, consideredTokens.Current.Type);
                tweakTokens();
                return null;
            }
            tweakTokens();
            var value = ExpressionParser.ParseExpression(consideredTokens, tweakTokens, out var errorExpression);
            error = value == null
                ? errorExpression
                : ParseError.None;

            return new LetStatement(letToken, identifer, value);
        }


    }
}