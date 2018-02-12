namespace MonkeyInterpreter.Parsers
{
    public interface INode {
        Token Token { get; }
    }

    public interface IStatement : INode {}
    public interface IExpression : INode {}
}