using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class Bracket : LexerCombinator
{
    public static Bracket New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        (Node<string>?)Or.New(
            ExpectChars.New("("),
            ExpectChars.New(")"),
            ExpectChars.New("["),
            ExpectChars.New("]"),
            ExpectChars.New("{"),
            ExpectChars.New("}")
        ).Parsing(context);

}

