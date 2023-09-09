using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Compare.ICmp;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type.Int;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Compare.ICmp;

// https://llvm.org/docs/LangRef.html#icmp-instruction

public class PreLessThanInst : PreInst
{

    public PreValue lhs;
    public PreValue rhs;

    public PreLessThanInst(PreValue lhs, PreValue rhs) : base(new PreInt1Ty())
    {
        this.lhs = lhs;
        this.rhs = rhs;
    }

    public override unsafe BuiltSignedLessThanInst BuildValue(BuildContext context)
    {
        var lhsValue = lhs.Build(context);
        var llvmLhsValue = lhsValue.llvmValue;
        var llvmLhsType = lhsValue.llvmType;
        var llvmRhsValue = rhs.Build(context).llvmValue;
        var llvmBuilder = context.basicBlockBuilder!.llvmBuilder;

        LLVMOpaqueValue* llvmCmpLessThanInst = null;
        var lhsType = lhs.type;
        if (lhsType is PreIntTy)
        {
            llvmCmpLessThanInst = LLVM.BuildICmp(
                llvmBuilder,
                LLVMIntPredicate.LLVMIntSLT,
                llvmLhsValue,
                llvmRhsValue,
                "int_signed_less_than_temp".ToSbytePointer()
            );
        }
        else
        {
            llvmCmpLessThanInst = LLVM.BuildFCmp(
                llvmBuilder,
                LLVMRealPredicate.LLVMRealOLT,
                llvmLhsValue,
                llvmRhsValue,
                "real_ordered_less_than_temp".ToSbytePointer()
            );
        }

        return new(this, llvmCmpLessThanInst, llvmLhsType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "SignedLessThanInst {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "lhs: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += lhs.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "rhs: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += rhs.ToStr(printer) + "\n";
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
