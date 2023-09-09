using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.BuiltClass.Inst.Memory;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Memory;

public class PreAllocInst : PreInst
{

    public string name;

    public bool isBuilt = false;
    public BuiltAllocInst? builtAllocInst = null;

    public PreAllocInst(string name, PreType type) : base(type)
    {
        this.name = name;
    }

    public PreLoadInst GetLoadInst() => new(this, type);

    public override unsafe BuiltValue BuildValue(BuildContext context)
    {
        if (isBuilt) return builtAllocInst!;
        var builtFunc = context.func!;

        var llvmBuilder = context.basicBlockBuilder!.llvmBuilder;
        var llvmType = type.Build(context).llvmType;

        var llvmAllocValue = LLVM.BuildAlloca(llvmBuilder, llvmType, name.ToSbytePointer());
        builtAllocInst = new BuiltAllocInst(this, llvmAllocValue, llvmType);

        builtFunc.AddPreAllocInst(this);
        builtFunc.AddBuiltAllocInst(builtAllocInst);
        isBuilt = true;
        return builtAllocInst;
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "AllocInst {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "name: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += name.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "type: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += type.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }


}
