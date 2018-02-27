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
            if(consideredTokens.Current.Type != TokenType.ASSIGN)
            {
                error = new ParseError("LetStatement", "Expected ASSIGN token, but not found");
                return null;
            }

            tweakTokens();
            var value = ParseExpression(consideredTokens, tweakTokens,  out var errorExpression);
            if(value==null)
            {
                error = errorExpression;
            }
            else
            {
                error = ParseError.None;
            }
            return new LetStatement(letToken, identifer, value);
        }

        private IExpression ParseExpression(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
        {
            error = null;
            switch(consideredTokens.Current.Type)
            {
                case TokenType.INT:
                    {
                        if(consideredTokens.Next.Type == TokenType.SEMICOLON)
                        {   
                            var expression =  new IntegerLiteralExpression(consideredTokens.Current);
                            tweakTokens();
                            tweakTokens();
                            return expression;
                        }

                        if(consideredTokens.Next.Type == TokenType.PLUS)
                        {
                            return ParseOperatorExpression(consideredTokens, tweakTokens, out error);
                        }
                    }
                    break;
                default: throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }

        private IExpression ParseOperatorExpression(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
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
