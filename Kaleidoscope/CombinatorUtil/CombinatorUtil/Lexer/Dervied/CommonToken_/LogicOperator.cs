using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class LogicOperator : Combinator
{

    public static LogicOperator New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
         (Node<string>?)Or.New(
             ExpectChars.New("<"),
             ExpectChars.New("<="),
             ExpectChars.New(">"),
             ExpectChars.New(">="),
             ExpectChars.New("&&"),
             ExpectChars.New("!")
        ).Parsing(context);

}