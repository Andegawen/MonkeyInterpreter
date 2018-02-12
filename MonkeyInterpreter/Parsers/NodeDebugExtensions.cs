public static class NodeExtensions
{
    public static string GetLiteral(this INode node)
    {
        return node.Token.ToString();
    } 
}