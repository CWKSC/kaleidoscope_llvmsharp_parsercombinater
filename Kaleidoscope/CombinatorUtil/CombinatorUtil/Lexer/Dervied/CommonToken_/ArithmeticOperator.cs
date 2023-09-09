using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class ArithmeticOperator : LexerCombinator
{
    public static ArithmeticOperator New() => new();

    public override ASTNode? Parsing(ParsingContext context) =>
         Or.New(
             ExpectChars.New("+"),
             ExpectChars.New("-"),
             ExpectChars.New("*"),
             ExpectChars.New("/")
        ).Parsing(context);

}
