using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Binary;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type.Int;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Arithmetic;

public class PreSubInst : PreInst
{

    public PreValue lhs;
    public PreValue rhs;

    public bool isBuilt = false;
    public BuiltSubInst? builtSubInst = null;

    public PreSubInst(PreValue lhs, PreValue rhs) : base(lhs.type)
    {
        this.lhs = lhs;
        this.rhs = rhs;
    }

    public override unsafe BuiltSubInst BuildValue(BuildContext context)
    {
        if (isBuilt) return builtSubInst!;

        var builder = context.basicBlockBuilder!;
        var lhsValue = lhs.Build(context);
        var rhsValue = rhs.Build(context);
        var llvmLhsType = lhsValue.llvmType;

        var lhsType = lhs.type;
        LLVMOpaqueValue* llvmSubInst = null;
        if (lhsType is PreIntTy)
        {
            llvmSubInst = LLVMSharpUtil.BuildSub(lhsValue, rhsValue, builder);
        }
        else
        {
            llvmSubInst = LLVMSharpUtil.BuildFSub(lhsValue, rhsValue, builder);
        }

        builtSubInst = new(this, llvmSubInst, llvmLhsType);
        isBuilt = true;
        return builtSubInst;
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "SubInst {".ToStr(printer) + "\n";
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
