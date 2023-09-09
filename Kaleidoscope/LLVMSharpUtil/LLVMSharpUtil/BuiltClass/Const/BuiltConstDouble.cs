using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.Class.Constant;

namespace LLVMSharpUtil_.BuiltClass.Const;

public class BuiltConstDouble : BuiltValue
{

    public PreConstDouble preConstDouble;

    public unsafe BuiltConstDouble(
        PreConstDouble preConstDouble,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType) : base(preConstDouble, llvmValue, llvmType)
    {
        this.preConstDouble = preConstDouble;
    }

}
