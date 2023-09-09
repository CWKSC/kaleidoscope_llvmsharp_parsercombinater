using CombinatorUtil;
using CombinatorUtil.Parser.Dervied.CommonToken;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Statement;
using Kaleidoscope.Parsing.Expr_;

namespace Kaleidoscope.Parsing.Statement_;

public class DefineLocalVarStatement : Combinator
{
    public static DefineLocalVarStatement New() => new();

    public override DefineLocalVarStatementAST? Parsing(ParsingContext context)
    {
        var varKeyword = ExpectString.New("var").Parsing(context);
        if (varKeyword == null) return null;

        var identifierAST1 = Identifier.New().Parsing(context);
        if (identifierAST1 == null) return null;
        var name = identifierAST1.value;

        var temp2 = ExpectString.New(":").Parsing(context);
        if (temp2 == null) return null;

        var identifierAST2 = Identifier.New().Parsing(context);
        if (identifierAST2 == null) return null;
        var type = identifierAST2.value;

        // Init 
        var temp3 = ExpectString.New("=").Parsing(context);
        if (temp3 == null)
        {
            context.parsingFunc!.localVarNameToType[name] = type;
            return new(name, type);
        }

        var exprAST = Expr.New(";").Parsing(context);
        if (exprAST == null) return null;

        var temp4 = ExpectString.New(";").Parsing(context);
        if (temp4 == null) return null;

        context.parsingFunc!.localVarNameToType[name] = type;
        return new(name, type, exprAST);
    }

}
