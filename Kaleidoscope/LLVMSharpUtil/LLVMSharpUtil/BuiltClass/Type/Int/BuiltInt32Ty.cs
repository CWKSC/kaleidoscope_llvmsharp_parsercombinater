using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Type.Int;

namespace LLVMSharpUtil_.BuiltClass.Type.Int;

public class BuiltInt32Ty : BuiltType
{

    public PreInt32Ty preInt32Ty;

    public unsafe BuiltInt32Ty(PreInt32Ty preInt32Ty, LLVMOpaqueType* llvmType) : base(preInt32Ty, llvmType)
    {
        this.preInt32Ty = preInt32Ty;
    }

}
