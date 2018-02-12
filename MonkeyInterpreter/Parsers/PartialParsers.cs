///<remarks>Currently it is too generic. But maybe we can somehow generalize more.
///It should be names StatementParsers</remarks>
public class PartialParsers()
{
    public PartialParsers()//IEnumerable<IPartialParser> parsers)
    {
        var parsers = new { new LetStatementParser(), new ReturnStatementParser(), new IfStatementParser()};
        parsers.ToDictionary(p=>p.TokenType, p=>p)
    }

    public [](TokenType tt){
        tokenTypeToParserMap[tt];
    }

    private readonly Dictionary<TokenType, IPartialParser> tokenTypeToParserMap;
}

public interface IPartialParser
{
    TokenType Key {get;}
    IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens, out ParseError error);
}
public class LetStatementParser : IPartialParser
{
    TokenType Key => TokenType.LET;
    public IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens)
    {
        var letToken = consideredTokens.Current;
        tweakTokens();
        var identifer = new Identifer(consideredTokens.Current);
        
        tweakTokens();
        if(consideredTokens.Current != TokenType.EQUAL)
        {
            error = new ParseError("LetStatement", "Expected EQUAL token, but not found")
            return null;
        }

        tweakTokens();
        var value = ParseExpression();

        return new LetStatement(letToken, identifer, value);
    }

    private identifer ParseIdentifier()
    {

    }
}

public class ReturnStatementParser : IPartialParser
{
    TokenType Key => TokenType.RETURN;
    IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens){}
}

public class IfStatementParser : IPartialParser
{
    TokenType Key => TokenType.IF;
    IStatement Parse(ConsideredTokens consideredTokens, Action tweakTokens){}
}