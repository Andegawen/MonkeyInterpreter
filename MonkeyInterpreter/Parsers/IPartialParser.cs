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

            
            if(consideredTokens.Current.Type != TokenType.IDENT)
            {
                error = new ParseError(StatementType.Let, TokenType.IDENT, consideredTokens.Current.Type);
                tweakTokens();
                return null;
            }
            var identifer = new Identifier(consideredTokens.Current);
            tweakTokens();
            
            
            if(consideredTokens.Current.Type != TokenType.ASSIGN)
            {
                error = new ParseError(StatementType.Let, TokenType.ASSIGN, consideredTokens.Current.Type);
                tweakTokens();
                return null;
            }
            tweakTokens();
            var value = ExpressionParser.ParseExpression(consideredTokens, tweakTokens,  out var errorExpression);
            error = value==null 
                ? errorExpression 
                : ParseError.None;
            
            return new LetStatement(letToken, identifer, value);
        }

        
    }


    public class ReturnStatementParser : IPartialParser
    {
        public TokenType Key => TokenType.RETURN;

        public IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error){
            var returnToken = consideredTokens.Current;
            tweakTokens();

            
            var value = ExpressionParser.ParseExpression(consideredTokens, tweakTokens,  out var errorExpression);
            error = value==null 
                ? errorExpression 
                : ParseError.None;
            return new ReturnStatement(returnToken, value);
        }
    }

    public static class ExpressionParser
    {
        public static IExpression ParseExpression(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
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

        private static IExpression ParseOperatorExpression(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error)
        {
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
