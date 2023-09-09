using ListTreeUtil;

namespace CombinatorUtil.Parser.Expect_;

public class ExpectString : ParserCombinator
{
    string expect;
    public ExpectString(string expect) => this.expect = expect;
    public static ExpectString New(string expect) => new(expect);

    public override Node<string>? Parsing(ParsingContext context) =>
        Expect.New(Node.New(expect)).Parsing(context);

}