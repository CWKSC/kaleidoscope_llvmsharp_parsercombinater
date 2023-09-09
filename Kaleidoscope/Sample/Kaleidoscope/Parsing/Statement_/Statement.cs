using CombinatorUtil;
using Kaleidoscope.AST.Statement;

namespace Kaleidoscope.Parsing.Statement_;

public class Statement : Combinator
{
    public static Statement New() => new();

    public override StatementAST? Parsing(ParsingContext context)
    {
        var result = Or.New(
            DefineLocalVarStatement.New(),
            AssignStatement.New(),
            CallFuncStatement.New(),
            IfStatement.New(),
            WhileStatement.New(),
            ReturnStatement.New()
        ).Parsing(context);
        if (result == null) return null;
        if (result is not StatementAST statementAST) return null;

        return statementAST;
    }

}