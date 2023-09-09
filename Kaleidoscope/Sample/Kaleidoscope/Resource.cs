using CombinatorUtil;
using CombinatorUtil.Dervied;
using Kaleidoscope.Parsing.Expr_;
using LLVMSharpUtil_.Class.General;

namespace Kaleidoscope;

public static class Resource
{

    public static PreContext context = new();
    public static PreModule module = new();

    public static List<(Combinator, Associativity)> commonOperatorRule = new() {
        (ConstInt.New(), Associativity.Left),
        (ConstFloat.New(), Associativity.Left),
        (FunctionCallee.New(), Associativity.Left),
        (VariableExpr.New(), Associativity.Left),
        (MultiplyExpr.New(), Associativity.Left),
        (AddExpr.New(), Associativity.Left),
        (SubExpr.New(), Associativity.Left),
        (LessThanExpr.New(), Associativity.Left),
        (GreaterThanExpr.New(), Associativity.Left),
    };

    public static List<(Combinator, Associativity)> GetCommonOperatorRules()
    {
        return new(commonOperatorRule);
    }

    public static unsafe void Init(string fileName)
    {
        module.name = fileName;
        context.AddModule(module);
    }

}
