using LLVMSharp.Interop;
using LLVMSharpUtil_.Class.Base;

namespace LLVMSharpUtil_.BuiltClass.Base;

public class BuiltValue : BuiltEle
{

    public PreValue preValue;
    public unsafe LLVMOpaqueValue* llvmValue;
    public unsafe LLVMOpaqueType* llvmType;

    public unsafe BuiltValue(PreValue preValue, LLVMOpaqueValue* llvmValue, LLVMOpaqueType* llvmType) : base(preValue)
    {
        this.preValue = preValue;
        this.llvmValue = llvmValue;
        this.llvmType = llvmType;
    }

}
