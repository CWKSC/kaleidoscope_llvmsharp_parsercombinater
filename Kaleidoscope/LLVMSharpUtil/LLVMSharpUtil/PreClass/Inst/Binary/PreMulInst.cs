using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Binary;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type.Int;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Arithmetic;

public class PreMulInst : PreInst
{

    public PreValue lhs;
    public PreValue rhs;

    public PreMulInst(PreValue lhs, PreValue rhs) : base(lhs.type)
    {
        this.lhs = lhs;
        this.rhs = rhs;
    }

    public override unsafe BuiltMulInst BuildValue(BuildContext context)
    {
        var lhsValue = lhs.Build(context);
        var llvmLhsValue = lhsValue.llvmValue;
        var llvmLhsTy = lhsValue.llvmType;

        var rhsValue = rhs.Build(context);
        var llvmRhsValue = rhsValue.llvmValue;

        var llvmBuilder = context.basicBlockBuilder!.llvmBuilder;

        var lhsType = lhs.type;
        LLVMOpaqueValue* llvmMulInst = null;
        if (lhsType is PreIntTy)
        {
            llvmMulInst = LLVM.BuildMul(llvmBuilder, llvmLhsValue, llvmRhsValue, "mul_temp".ToSbytePointer());
        }
        else
        {
            llvmMulInst = LLVM.BuildFMul(llvmBuilder, llvmLhsValue, llvmRhsValue, "fmul_temp".ToSbytePointer());
        }
        return new(this, llvmMulInst, llvmLhsTy);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "MulInst {".ToStr(printer) + "\n";
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
