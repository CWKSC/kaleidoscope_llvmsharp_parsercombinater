using CombinatorUtil;
using CombinatorUtil.Dervied;
using CombinatorUtil.Expect_;
using CombinatorUtil.GeneralCombinator_.Node_;
using CombinatorUtil.Misc;
using CombinatorUtil.Node_;
using CombinatorUtil.Parser.Dervied.CommonToken;
using CombinatorUtil.Parser.Expect_;

namespace Kaleidoscope.Parsing.Expr_;

public class FunctionCallee : Combinator
{
    public static FunctionCallee New() => new();

    public override AST.Expr.FuncCalleeAST? Parsing(ParsingContext context)
    {
        var identifer = Identifier.New().Parsing(context);
        if (identifer == null) return null;

        var bracketAST = ExpectWithType.New<BracketAST>().Parsing(context);
        if (bracketAST == null) return null;

        var list = bracketAST.list;
        var ccontext = ParsingContext.New(context, list);
        var seperatedList = SeparatedList.New(
            AsNewContext.New(
                SpiltUntil.New(ExpectString.New(",")),
                ExpectAny.New()
            ),
            ExpectString.New(",")
        ).Parsing(ccontext);

        Console.WriteLine(seperatedList!.ToStr(new()));
        var name = identifer.value;
        var args = new List<CodegenLLVMSharpEleNode>();
        foreach (CodegenLLVMSharpEleNode ele in seperatedList.Cast<CodegenLLVMSharpEleNode>())
        {
            args.Add(ele);
        }

        return new(name, args);
    }

}