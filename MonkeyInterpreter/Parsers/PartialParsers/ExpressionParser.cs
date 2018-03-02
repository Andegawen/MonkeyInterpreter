
using System;
using MonkeyInterpreter.Parsers.Structure;

namespace MonkeyInterpreter.Parsers.PartialParsers
{
    public static class ExpressionParser
    {
        public static IExpression ParseExpression(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
        {
            error = null;
            switch (consideredTokens.Current.Type)
            {
                case TokenType.INT:
                    {
                        if (consideredTokens.Next.Type == TokenType.SEMICOLON)
                        {
                            var expression = new IntegerLiteralExpression(consideredTokens.Current);
                            tweakTokens();
                            tweakTokens();
                            return expression;
                        }

                        if (consideredTokens.Next.Type == TokenType.PLUS)
                        {
                            return ParseOperatorExpression(consideredTokens, tweakTokens, out error);
                        }
                    }
                    break;
                default: throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }

        private static IExpression ParseOperatorExpression(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
        {
            throw new NotImplementedException();
        }
    }
}