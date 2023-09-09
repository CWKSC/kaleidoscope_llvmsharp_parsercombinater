using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Type;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Var;

public abstract class PreVar : PreValue
{

    public string name;

    public PreVar(string name, PreType type) : base(type)
    {
        this.name = name;
    }

    //public override unsafe BuiltValue BuildValue(BuildContext context)
    //{
    //    //var func = context.func!;
    //    //var isFuncParam = func.paramDict.ContainsKey(name);
    //    //if (isFuncParam)
    //    //{
    //    //    var paramVar = func.paramDict[name];
    //    //    var llvmValue = paramVar.llvmValue;
    //    //    var llvmType = paramVar.llvmType;
    //    //    return new BuiltFuncVar(this, llvmValue, llvmType);
    //    //}

    //    throw new NotImplementedException();
    //}

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "Var {".ToStr(printer) + "\n";
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
