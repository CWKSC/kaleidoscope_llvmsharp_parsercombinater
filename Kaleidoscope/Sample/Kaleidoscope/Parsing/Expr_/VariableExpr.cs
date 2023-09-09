using CombinatorUtil;
using CombinatorUtil.Parser.Dervied.CommonToken;
using Kaleidoscope.AST.Expr.Var;

namespace Kaleidoscope.Parsing.Expr_;

public class VariableExpr : Combinator
{

    public static VariableExpr New() => new();

    public override VarExprAST? Parsing(ParsingContext context)
    {
        var identifier = Identifier.New().Parsing(context);
        if (identifier == null) return null;

        var name = identifier.value;

        var parsingFunc = context.parsingFunc!;
        if (parsingFunc.funcArgsNameToType.ContainsKey(name))
        {
            return new FuncVarExprAST(name);
        }
        else if (parsingFunc.localVarNameToType.ContainsKey(name))
        {
            return new LocalVarExprAST(name);
        }
        else
        {
            throw new Exception("Undefined var");
        }
    }

}