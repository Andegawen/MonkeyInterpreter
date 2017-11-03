using System.Collections.Generic;

namespace MonkeyInterpreter
{
    public class Lexer
    {
        private string scriptToAnalyse;

        public Lexer(string line)
        {
            scriptToAnalyse = line;
        }

        public IEnumerable<Token> GetTokens()
        {
            for (int i = 0; i < scriptToAnalyse.Length; i++)
            {
                var character = scriptToAnalyse[i];
                switch (character)
                {
                    case '=':
                        yield return new Token(TokenType.ASSIGN, new string(new[]{character}));
                        break;
                    case '+':
                        yield return new Token(TokenType.PLUS, new string(new[]{character}));
                        break;
                    case ';':
                        yield return new Token(TokenType.SEMICOLON, new string(new[]{character}));
                        break;
                    case ',':
                        yield return new Token(TokenType.COMMA, new string(new[]{character}));
                        break;
                    case '(':
                        yield return new Token(TokenType.LPAREN, new string(new[]{character}));
                        break;
                    case ')':
                        yield return new Token(TokenType.RPAREN, new string(new[]{character}));
                        break;
                    case '{':
                        yield return new Token(TokenType.LBRACE, new string(new[]{character}));
                        break;
                    case '}':
                        yield return new Token(TokenType.RBRACE, new string(new[]{character}));
                        break;
                    default:
                        new Token(TokenType.ILLEGAL, new string(new[]{character}));
                        break;
                }
            }
            yield return new Token(TokenType.EOF, "");
        }
    }
}