using System;
using MonkeyInterpreter.Parsers.Structure;

namespace MonkeyInterpreter.Parsers.PartialParsers
{
    public interface IPartialParser
    {
        TokenType Key { get; }
        IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error);
    } 
}
