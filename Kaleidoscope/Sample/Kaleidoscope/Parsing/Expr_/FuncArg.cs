using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Expr;
using ListTreeUtil;

namespace Kaleidoscope.Parsing.Expr_;

public class FuncArg : Combinator
{

    public Dictionary<string, string> funcArgNames;
    public FuncArg(Dictionary<string, string> funcArgNames) => this.funcArgNames = funcArgNames;
    public static FuncArg New(Dictionary<string, string> funcArgNames) => new(funcArgNames);

    public override FuncArgAST? Parsing(ParsingContext context)
    {
        var or = Or.New<Node<string>>();
        foreach (var funcArgName in funcArgNames)
        {
            or.Add(ExpectString.New(funcArgName.Key));
        }
        var argAST = or.Parsing(context);
        if (argAST == null) return null;
        var argName = argAST.value;
        var type = funcArgNames[argName];

        return new(argName, type);
    }

}