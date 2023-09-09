using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Binary;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type.Int;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Arithmetic;

public class PreAddInst : PreInst
{

    public PreValue lhs;
    public PreValue rhs;

    public bool isBuilt = false;
    public BuiltAddInst? builtAddInst = null;

    public PreAddInst(PreValue lhs, PreValue rhs) : base(lhs.type)
    {
        this.lhs = lhs;
        this.rhs = rhs;
    }

    public override unsafe BuiltAddInst BuildValue(BuildContext context)
    {
        if (isBuilt) return builtAddInst!;

        var builder = context.basicBlockBuilder!;
        var lhsValue = lhs.Build(context);
        var rhsValue = rhs.Build(context);
        var llvmLhsType = lhsValue.llvmType;

        var lhsType = lhs.type;
        LLVMOpaqueValue* llvmAddInst = null;
        if (lhsType is PreIntTy)
        {
            llvmAddInst = LLVMSharpUtil.BuildAdd(lhsValue, rhsValue, builder);
        }
        else
        {
            llvmAddInst = LLVMSharpUtil.BuildFAdd(lhsValue, rhsValue, builder);
        }
        builtAddInst = new(this, llvmAddInst, llvmLhsType);
        isBuilt = true;
        return builtAddInst;
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "AddInst {".ToStr(printer) + "\n";
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
