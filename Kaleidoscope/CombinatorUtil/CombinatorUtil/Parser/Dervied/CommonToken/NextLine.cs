using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken;

public class NextLine : ParserCombinator
{
    public static NextLine New() => new();

    public override ASTNode? Parsing(ParsingContext context) =>
         Or.New(
             ExpectString.New("\r\n"),
             ExpectString.New("\n")
         ).Parsing(context);

}
