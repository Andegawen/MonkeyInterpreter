using System;

namespace MonkeyInterpreter.Parsers
{
    public class ReturnStatementParser : IPartialParser
    {
        public TokenType Key => TokenType.RETURN;

        public IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
        {
            var returnToken = consideredTokens.Current;
            tweakTokens();


            var value = ExpressionParser.ParseExpression(consideredTokens, tweakTokens, out var errorExpression);
            error = value == null
                ? errorExpression
                : ParseError.None;
            return new ReturnStatement(returnToken, value);
        }
    }
}