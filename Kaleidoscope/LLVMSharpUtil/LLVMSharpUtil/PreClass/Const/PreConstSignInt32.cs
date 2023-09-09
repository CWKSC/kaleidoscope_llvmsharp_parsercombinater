using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Const;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type.Int;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Constant;

public class PreConstSignInt32 : PreValue
{

    public int value;
    public PreConstSignInt32(int value) : base(new PreInt32Ty()) => this.value = value;

    public override unsafe BuiltConstSignInt32 BuildValue(BuildContext context)
    {
        var llvmValue = LLVM.ConstInt(LLVM.Int32Type(), (ulong)value, 1);
        var llvmType = type.Build(context).llvmType;
        return new BuiltConstSignInt32(this, llvmValue, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += $"ConstSignInt32 {{ {value} }}".ToStr(printer);
        return result;
    }

}
