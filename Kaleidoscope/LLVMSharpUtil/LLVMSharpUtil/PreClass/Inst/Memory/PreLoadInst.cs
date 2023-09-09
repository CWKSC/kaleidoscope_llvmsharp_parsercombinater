using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Memory;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Memory;

public class PreLoadInst : PreInst
{

    public PreAllocInst preAllocInst;

    public bool isBuilt = false;
    public BuiltLoadInst? builtLoadInst = null;

    public PreLoadInst(PreAllocInst preAllocInst, PreType type) : base(type)
    {
        this.preAllocInst = preAllocInst;
    }

    public override unsafe BuiltLoadInst BuildValue(BuildContext context)
    {
        // if (isBuilt) return builtLoadInst!;

        var llvmBuilder = context.basicBlockBuilder!.llvmBuilder;
        var llvmType = type.Build(context).llvmType;
        var llvmPtrValue = preAllocInst.Build(context).llvmValue;
        var name = preAllocInst.name;

        var llvmLoadInst = LLVM.BuildLoad2(llvmBuilder, llvmType, llvmPtrValue, name.ToSbytePointer());

        builtLoadInst = new BuiltLoadInst(this, llvmLoadInst, llvmType);
        // isBuilt = true;
        return builtLoadInst;
    }


    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "LoadInst {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "allocInst: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += preAllocInst.ToStr(printer) + "\n";
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
