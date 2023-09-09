using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Terminator;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Terminator;

public class PreRetInst : PreInst
{

    public PreValue? value;
    public PreRetInst(PreValue? value) : base(value == null ? new PreVoidTy() : value.type)
    {
        this.value = value;
    }

    public override unsafe BuiltRetInst BuildValue(BuildContext context)
    {
        var builder = context.basicBlockBuilder!.llvmBuilder;

        if (value == null)
        {
            var llvmReturnTy = type.Build(context).llvmType;
            var llvmRetVoidInst = LLVM.BuildRetVoid(builder);
            return new(this, llvmRetVoidInst, llvmReturnTy);
        }
        else
        {
            var llvmValue = value.Build(context).llvmValue;
            var llvmReturnTy = value.type.Build(context).llvmType;
            var llvmRetInst = LLVM.BuildRet(builder, llvmValue);
            return new(this, llvmRetInst, llvmReturnTy);
        }

    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "RetInst {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        if (value != null)
        {
            result += "value: ".ToStr(printer) + "\n";
            printer.IncreaseIndent();
            result += value.ToStr(printer) + "\n";
            printer.DecreaseIndent();
        }

        result += "type: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += type.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
