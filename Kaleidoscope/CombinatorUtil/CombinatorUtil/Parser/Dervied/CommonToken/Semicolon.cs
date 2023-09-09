using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken;

public class Semicolon : ParserCombinator
{

    public static Semicolon New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        ExpectString.New(";").Parsing(context);

}