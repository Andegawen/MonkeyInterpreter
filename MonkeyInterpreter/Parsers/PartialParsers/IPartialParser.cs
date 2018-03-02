using System;

namespace MonkeyInterpreter.Parsers
{
    public interface IPartialParser
    {
        TokenType Key { get; }
        IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error);
    }

    


    

   
    
}
