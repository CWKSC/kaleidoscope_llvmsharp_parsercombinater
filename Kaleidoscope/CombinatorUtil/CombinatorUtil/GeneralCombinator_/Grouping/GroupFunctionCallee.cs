using CombinatorUtil.Expect_;
using CombinatorUtil.GeneralCombinator_.Node_;
using CombinatorUtil.Parser.Dervied.CommonToken;
using ListTreeUtil;

namespace CombinatorUtil.GeneralCombinator_.Grouping;

public class GroupFunctionCallee : Combinator
{

    public static GroupFunctionCallee New() => new();

    public override ASTNode? Parsing(ParsingContext context)
    {
        var identifier = Identifier.New().Parsing(context);
        if (identifier == null) return null;

        var bracketAST = ExpectWithType.New<BracketAST>().Parsing(context);
        if (bracketAST == null) return null;

        var functionCallee = new FunctionCalleeAST();
        functionCallee.name = identifier.value;
        foreach (Node<string> ele in bracketAST.list.Cast<Node<string>>())
        {
            functionCallee.args.Add(ele.value);
        }

        return functionCallee;
    }

}
