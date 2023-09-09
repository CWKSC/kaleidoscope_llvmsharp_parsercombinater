using CombinatorUtil.Expect_;
using CombinatorUtil.Quantifier;
using ListTreeUtil;
using PrinterUtil;
using System.Text.RegularExpressions;

namespace CombinatorUtil.Lexer.Expect_;

public class RegexExpectChars : LexerCombinator
{

    string regexString;
    public RegexExpectChars(string regexString) => this.regexString = regexString;
    public static RegexExpectChars New(string regexString) => new(regexString);


    public override Node<string>? Parsing(ParsingContext context)
    {
        var list = context.list;
        if (list.Count == 0) return null;

        string text = "";
        foreach (var ele in list)
        {
            text += ele.ToString();
        }

        var result = new Regex(regexString).Match(text);
        if (!(result.Success && result.Index == 0))
        {
            $"RegexExpectChars [{regexString}] fail".Print(new() { foregroundColor = ConsoleColor.Yellow });
            return null;
        }
        var value = result.Value;
        $"RegexExpectChars [{regexString}] match, value: {value}".Print(new() { foregroundColor = ConsoleColor.Green });
        _ = Exactly.New(ExpectAny.New(), value.Length).Parsing(context);
        return Node.New(value);
    }

}

