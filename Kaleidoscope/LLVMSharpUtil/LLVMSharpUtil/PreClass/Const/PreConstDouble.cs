using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Const;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type;
using PrinterUtil;

namespace LLVMSharpUtil_.Class.Constant;

public class PreConstDouble : PreValue
{

    public double value;
    public PreConstDouble(double value) : base(new PreDoubleTy())
    {
        this.value = value;
    }

    public override unsafe BuiltConstDouble BuildValue(BuildContext context)
    {
        var llvmValue = LLVM.ConstReal(LLVM.DoubleType(), value);
        var llvmType = type.Build(context).llvmType;
        return new BuiltConstDouble(this, llvmValue, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += $"ConstDouble {{ {value} }}".ToStr(printer);
        return result;
    }
}
