using ListTreeUtil;
using PrinterUtil;
using System.Text.RegularExpressions;

namespace CombinatorUtil.Parser.Expect_;

public class RegexExpectString : ParserCombinator
{

    string regexString;
    public RegexExpectString(string regexString) => this.regexString = regexString;
    public static RegexExpectString New(string regexString) => new(regexString);

    public override Node<string>? Parsing(ParsingContext context)
    {
        var list = context.list;
        if (list.Count == 0) return null;

        if (context.current == null) return null;
        if (context.current.Value is not Node<string> node) return null;
        var text = node.value;
        if (text == null) return null;

        var result = new Regex(regexString).Match(text);
        if (!(result.Success && result.Index == 0))
        {
            $"RegexExpectString [{regexString}] fail".Print(new() { foregroundColor = ConsoleColor.Yellow });
            return null;
        }
        var value = result.Value;
        $"RegexExpectString [{regexString}] match, value: {value}".Print(new() { foregroundColor = ConsoleColor.Green });
        _ = Expect.New(Node.New(value)).Parsing(context);
        return Node.New(value);
    }

}