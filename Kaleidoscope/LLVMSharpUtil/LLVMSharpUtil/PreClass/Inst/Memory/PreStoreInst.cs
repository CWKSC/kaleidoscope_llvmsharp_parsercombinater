using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Memory;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Memory;

public class PreStoreInst : PreInst
{

    public PreAllocInst preAllocInst;
    public PreValue value;

    public PreStoreInst(PreAllocInst preAllocInst, PreValue value) : base(value.type)
    {
        this.preAllocInst = preAllocInst;
        this.value = value;
    }

    public override unsafe BuiltStoreInst BuildValue(BuildContext context)
    {
        var llvmBuilder = context.basicBlockBuilder!.llvmBuilder;
        var builtAllocInst = preAllocInst.Build(context);
        var llvmType = builtAllocInst.llvmType;
        var llvmPtrValue = builtAllocInst.llvmValue;
        var llvmValue = value.Build(context).llvmValue;

        var llvmStoreInst = LLVM.BuildStore(llvmBuilder, llvmValue, llvmPtrValue);
        return new(this, llvmStoreInst, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "StoreInst {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "allocInst: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += preAllocInst.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "value: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += value.ToStr(printer) + "\n";
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

