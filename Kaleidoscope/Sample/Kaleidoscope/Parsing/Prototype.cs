using CombinatorUtil;
using CombinatorUtil.AST;
using CombinatorUtil.Dervied;
using CombinatorUtil.Logic;
using CombinatorUtil.Misc;
using CombinatorUtil.Parser.Dervied.CommonToken;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST;
using ListTreeUtil;
using ListTreeUtil.Base;

namespace Kaleidoscope.Parsing;

public class Prototype : Combinator
{
    public static Prototype New() => new();

    public override PrototypeAST? Parsing(ParsingContext context)
    {
        var identifierAST = Identifier.New().Parsing(context);
        if (identifierAST == null) return null;
        var name = identifierAST.value;

        if (ExpectString.New("(").Parsing(context) == null) return null;

        // var tagger = new Tagger();
        var spiltUntil = SpiltUntil.New(ExpectString.New(")"));
        var separatedList = AsNewContext.New<LList<ASTNode>>(
            spiltUntil,
            SeparatedList.New(
                AndPair.New<IdentifierAST>(
                    Identifier.New(),
                    Identifier.New()
                ),
                ExpectString.New(",")
            )
        ).Parsing(context);
        if (separatedList == null) return null;

        var temp2 = And.New(
            ExpectString.New(")"),
            ExpectString.New(":")
        ).Parsing(context);
        if (temp2 == null) return null;

        var identifierAST2 = Identifier.New().Parsing(context);
        if (identifierAST2 == null) return null;
        var returnType = identifierAST2.value;

        var type_name = separatedList.Cast<PairNode<IdentifierAST, IdentifierAST>>().ToList(); //tagger.GetTagRepeat<PairNode<Node<string>, Node<string>>>("type_name");

        var args = new List<string>();
        var argTys = new List<string>();
        foreach (var (argTy, argName) in type_name)
        {
            args.Add(argName.value);
            argTys.Add(argTy.value);
        }

        return new PrototypeAST(name, args, argTys, returnType, 0);
    }

}