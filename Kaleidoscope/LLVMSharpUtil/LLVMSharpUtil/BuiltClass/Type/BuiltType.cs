using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.Class.Type;

namespace LLVMSharpUtil_.BuiltClass.Type;

public class BuiltType : BuiltEle
{

    public PreType preType;
    public unsafe LLVMOpaqueType* llvmType;

    public unsafe BuiltType(PreType preType, LLVMOpaqueType* llvmType) : base(preType)
    {
        this.preType = preType;
        this.llvmType = llvmType;
    }

}
