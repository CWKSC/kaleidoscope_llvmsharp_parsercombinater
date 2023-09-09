using LLVMSharpUtil_.BuiltClass.Var;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Var;

public class PreLocalVar : PreVar
{

    public PreLocalVar(string name, PreType type) : base(name, type)
    {

    }

    public override unsafe BuiltLocalVar BuildValue(BuildContext context)
    {
        var func = context.func!;
        var preLoadInst = func.preLoadInstDict[name];
        type = preLoadInst.type;
        var builtLoadInst = preLoadInst.Build(context);
        var llvmValue = builtLoadInst.llvmValue;
        var llvmType = builtLoadInst.llvmType;
        return new BuiltLocalVar(this, llvmValue, llvmType);
    }


    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "PreLocalVar {".ToStr(printer) + "\n";
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
