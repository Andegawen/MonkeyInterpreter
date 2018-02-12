using System;

namespace MonkeyInterpreter.Parsers
{
    public interface IPartialParser
    {
        TokenType Key {get;}
        IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error);
    }
    
    public class LetStatementParser : IPartialParser
    {
        public TokenType Key => TokenType.LET;

        public IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
        {
            var letToken = consideredTokens.Current;
            tweakTokens();
            var identifer = new Identifier(consideredTokens.Current);
            
            tweakTokens();
            if(consideredTokens.Current.Type != TokenType.EQ)
            {
                error = new ParseError("LetStatement", "Expected EQUAL token, but not found");
                return null;
            }

            tweakTokens();
            var value = ParseExpression();

            error = ParseError.None;
            return new LetStatement(letToken, identifer, value);
        }

        private IExpression ParseExpression()
        {
            throw new NotImplementedException();
        }
    }

    public class ReturnStatementParser : IPartialParser
    {
        public TokenType Key => TokenType.RETURN;

        public IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error){
            throw new NotImplementedException();
        }
    }

    public class IfStatementParser : IPartialParser
    {
        public TokenType Key => TokenType.IF;
        public IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error){
            throw new NotImplementedException();
        }
    }
}
