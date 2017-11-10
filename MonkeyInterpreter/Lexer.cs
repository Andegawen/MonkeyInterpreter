using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyInterpreter
{
    public class Lexer
    {
        private readonly string scriptToAnalyse;

        private readonly Dictionary<string, TokenType> oneSignTokens = new Dictionary<string, TokenType>
        {
            {"=", TokenType.ASSIGN},
            {"+", TokenType.PLUS},
            {"-", TokenType.MINUS},
            {"*", TokenType.ASTERIKS},
            
            {";", TokenType.SEMICOLON},
            {",", TokenType.COMMA},
            {"(", TokenType.LPAREN},
            {")", TokenType.RPAREN},
            {"{", TokenType.LBRACE},
            {"}", TokenType.RBRACE},

            {"<", TokenType.LT},
            {">", TokenType.GT},

            {"!", TokenType.BANG},
            {@"/", TokenType.SLASH},
        };
        

        private readonly Dictionary<string,TokenType> keywords = new Dictionary<string, TokenType>
        {
            { "let",TokenType.LET},
            { "fn",TokenType.FUNCTION},
        };

        private readonly HashSet<string> identities = new HashSet<string>();

        public Lexer(string line)
        {
            scriptToAnalyse = line;
        }

        public IEnumerable<Token> GetTokens()
        {
            return GetTokenStrings().Select(ts =>
            {
                if (oneSignTokens.ContainsKey(ts))
                {
                    return new Token(oneSignTokens[ts], ts);
                }
                var lits = ts.ToLowerInvariant();
                if (keywords.ContainsKey(lits))
                {
                    return new Token(keywords[lits], ts);
                }
                if (ts.All(char.IsDigit))
                {
                    return new Token(TokenType.INT, ts);
                }

                if (string.IsNullOrEmpty(ts))
                {
                    return new Token(TokenType.ILLEGAL, ts);
                }
                if (!identities.Contains(lits))
                {
                    identities.Add(lits);
                }
                return new Token(TokenType.IDENT, ts);
            }).Concat(new[] {new Token(TokenType.EOF, "")});
        }

        private IEnumerable<string> GetTokenStrings()
        {
            var sb = new StringBuilder();
            foreach (var character in scriptToAnalyse)
            {
                if (char.IsLetter(character) || char.IsDigit(character) || character=='_')
                {
                    sb.Append(character);
                }
                else
                {
                    if (char.IsWhiteSpace(character))
                    {
                        if (sb.Length == 0) continue;
                        var t = sb.ToString();
                        sb.Clear();
                        yield return t;
                    }
                    else
                    {
                        if (sb.Length > 0)
                        {
                            var t = sb.ToString();
                            sb.Clear();
                            yield return t;
                        }
                        yield return new string(new[] { character });
                    }
                }
            }
            if (sb.Length > 0)
                yield return sb.ToString();
        }
    }
}