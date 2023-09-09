using LLVMSharpUtil_.BuiltClass.Var;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Var;

public class PreFuncVar : PreVar
{

    public PreFuncVar(string name, PreType type) : base(name, type)
    {

    }

    public override unsafe BuiltFuncVar BuildValue(BuildContext context)
    {
        var func = context.func!;
        var funcArgVar = func.funcArgDict[name];

        var llvmValue = funcArgVar.llvmValue;
        var llvmType = funcArgVar.llvmType;
        return new BuiltFuncVar(this, llvmValue, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "PreFuncVar {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";

        result += "type: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += type.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }


}
