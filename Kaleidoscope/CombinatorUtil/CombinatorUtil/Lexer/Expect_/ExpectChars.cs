using ListTreeUtil;

namespace CombinatorUtil.Lexer.Expect_;

public class ExpectChars : LexerCombinator
{

    string expect;
    public ExpectChars(string expect) => this.expect = expect;
    public static ExpectChars New(string expect) => new(expect);


    public override Node<string>? Parsing(ParsingContext context)
    {
        var combinators = expect.Select(c => (Combinator)Expect.New(Node.New(c))).ToList();
        var result = And.New(combinators).Parsing(context);
        return result == null ? null : Node.New(expect);
    }

}