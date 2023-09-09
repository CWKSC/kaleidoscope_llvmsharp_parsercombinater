using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST;
using Kaleidoscope.AST.TopLevelStatement;

namespace Kaleidoscope.Parsing.TopLevelStatement_;

public class Extern : Combinator
{

    public static Extern New() => new();

    public override ExternAST? Parsing(ParsingContext context)
    {
        var tagger = new Tagger();
        var result = And.New(
            ExpectString.New("extern"),
            Tag.New(tagger, Prototype.New(), "prototpye")
        ).Parsing(context);
        if (result == null) return null;

        var prototpyeAST = (PrototypeAST)tagger.GetTag("prototpye");
        return new(prototpyeAST);
    }


}