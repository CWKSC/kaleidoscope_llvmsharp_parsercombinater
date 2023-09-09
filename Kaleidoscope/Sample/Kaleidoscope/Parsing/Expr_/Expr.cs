using CombinatorUtil;
using CombinatorUtil.Dervied;
using CombinatorUtil.Misc;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Expr;

namespace Kaleidoscope.Parsing.Expr_;

public class Expr : Combinator
{

    public string terminator = ";";
    public Expr(string terminator) => this.terminator = terminator;
    public static Expr New(string terminator) => new(terminator);


    public override ExprAST? Parsing(ParsingContext context)
    {
        var operatorRules = Resource.GetCommonOperatorRules();

        var parsingFunc = context.parsingFunc!;
        var funcArgsNameToType = parsingFunc.funcArgsNameToType;
        if (funcArgsNameToType != null)
        {
            operatorRules.Insert(0, (FuncArg.New(funcArgsNameToType), Associativity.Left));
        }

        var spiltUntil = SpiltUntil.New(ExpectString.New(terminator));
        var expr = AsNewContext.New(
            spiltUntil,
            OperatorAssociate.New(operatorRules)
        ).Parsing(context);
        if (expr == null) return null;

        // Console.WriteLine(expr.ToStr(new()));
        return (ExprAST)expr;
    }

}