using LLVMSharpUtil_.PreClass.Func;
using PrinterUtil;

namespace Kaleidoscope.AST.TopLevelStatement;

public class ExternAST : TopLevelStatementAST
{

    public PrototypeAST prototype;
    public ExternAST(PrototypeAST prototype) => this.prototype = prototype;

    public void Codegen()
    {
        var name = prototype.name;
        var argNames = prototype.argNames;
        var funcTy = prototype.Codegen();
        var func = new PreExternFunc(name, funcTy, argNames);
        Resource.module.AddFunc(func);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "Extern {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "prototype: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += prototype.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}

