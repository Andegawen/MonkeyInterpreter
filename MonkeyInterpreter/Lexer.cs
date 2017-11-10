using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyInterpreter
{
    public class Lexer
    {
        private readonly string scriptToAnalyse;

        private readonly Dictionary<string, TokenType> specialStrings = new Dictionary<string, TokenType>
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

            {"==", TokenType.EQ},
            {"!=", TokenType.NOT_EQ},
        };
        

        private readonly Dictionary<string,TokenType> keywords = new Dictionary<string, TokenType>
        {
            { "let",TokenType.LET},
            { "fn",TokenType.FUNCTION},
            { "true",TokenType.TRUE},
            { "false",TokenType.FALSE},
            { "if",TokenType.IF},
            { "else",TokenType.ELSE},
            { "return",TokenType.RETURN},
        };

        private readonly HashSet<string> identities = new HashSet<string>();

        public Lexer(string line)
        {
            scriptToAnalyse = line;
        }

        public IEnumerable<Token> GetTokens()
        {
            var t = GetTokenStrings().ToArray();
            return GetTokenStrings().Select(ts =>
            {
                if (specialStrings.ContainsKey(ts))
                {
                    return new Token(specialStrings[ts], ts);
                }
                if (keywords.ContainsKey(ts))
                {
                    return new Token(keywords[ts], ts);
                }
                if (ts.All(char.IsDigit))
                {
                    return new Token(TokenType.INT, ts);
                }

                if (string.IsNullOrEmpty(ts))
                {
                    return new Token(TokenType.ILLEGAL, ts);
                }
                var lits = ts.ToLowerInvariant();
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
            for (var index = 0; index < scriptToAnalyse.Length; index++)
            {
                var character = scriptToAnalyse[index];
                if ((character == '=' || character == '!') && index < scriptToAnalyse.Length)
                {
                    if (scriptToAnalyse[index + 1] == '=')
                    {
                        var t = sb.ReturnTokenIfPossible();
                        if (t != null)
                            yield return t;
                        yield return new string(new []{character, scriptToAnalyse[index + 1] });
                        index++;
                        continue;
                    }
                }
                if (char.IsLetter(character) || char.IsDigit(character) || character == '_')
                {
                    sb.Append(character);
                }
                else
                {
                    if (char.IsWhiteSpace(character))
                    {
                        var t = sb.ReturnTokenIfPossible();
                        if (t != null)
                            yield return t;
                    }
                    else
                    {
                        var t = sb.ReturnTokenIfPossible();
                        if (t != null)
                            yield return t;
                        yield return new string(new[] {character});
                    }
                }
            }
            if (sb.Length > 0)
                yield return sb.ToString();
        }
    }
    static class StringBuilderExtensions
    {
        public static string ReturnTokenIfPossible(this StringBuilder sb)
        {
            if (sb.Length <= 0) return null;
            var t = sb.ToString();
            sb.Clear();
            return t;
        }
    }
}