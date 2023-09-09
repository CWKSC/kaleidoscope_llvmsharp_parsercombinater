using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.Class.Type;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Func;

public class PreAnonFunc : PreFunc
{

    public PreAnonFunc(PreFuncTy funcTy) : base("", funcTy, new())
    {

    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "AnonFunc {".ToStr(printer) + "\n";

        printer.IncreaseIndent();
        result += "insts: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var block in basicBlockList)
        {
            result += block.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
