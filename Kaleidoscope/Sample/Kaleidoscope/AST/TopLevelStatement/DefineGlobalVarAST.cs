using PrinterUtil;

namespace Kaleidoscope.AST.TopLevelStatement;

public class DefineGlobalVarAST : TopLevelStatementAST
{

    public string name;
    public string type;

    public DefineGlobalVarAST(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "DefineGlobalVarAST {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";
        result += $"type: {type}".ToStr(printer) + "\n";
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
