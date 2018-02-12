using System.Collections.Generic;
using System.Linq;

namespace MonkeyInterpreter.Parsers
{
    ///<remarks>Currently it is too generic. But maybe we can somehow generalize more.
    ///It should be names StatementParsers</remarks>
    public class PartialParsers
    {
        public PartialParsers()//IEnumerable<IPartialParser> parsers)
        {
            var parsers = new IPartialParser[]{ new LetStatementParser(), new ReturnStatementParser(), new IfStatementParser()};
            parsers.ToDictionary(p=>p.Key, p=>p);
        }

        public IPartialParser this[TokenType tt]{
            get { return tokenTypeToParserMap[tt]; }
            set { tokenTypeToParserMap[tt]=value; }
        }

        private readonly Dictionary<TokenType, IPartialParser> tokenTypeToParserMap;
    }
}