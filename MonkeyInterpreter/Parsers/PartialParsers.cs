using System.Collections.Generic;
using System.Linq;

namespace MonkeyInterpreter.Parsers
{
    ///<remarks>Currently it is too generic. But maybe we can somehow generalize more.
    ///It should be names StatementParsers</remarks>
    public class PartialParsers
    {
        public PartialParsers()
        {
            var parsers = new IPartialParser[] { new LetStatementParser(), new ReturnStatementParser(), new IfStatementParser() };
            tokenTypeToParserMap = parsers.ToDictionary(p => p.Key, p => p);
        }

        public bool TryGetParser(TokenType tokenType, out IPartialParser partialParser)
        {
            return tokenTypeToParserMap.TryGetValue(tokenType, out partialParser);
        }

        private readonly Dictionary<TokenType, IPartialParser> tokenTypeToParserMap;
    }
}