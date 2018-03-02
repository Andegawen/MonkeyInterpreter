using System;

namespace MonkeyInterpreter.Parsers
{
    public class IfStatementParser : IPartialParser
    {
        public TokenType Key => TokenType.IF;
        public IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
        {
            throw new NotImplementedException();
        }
    }
}