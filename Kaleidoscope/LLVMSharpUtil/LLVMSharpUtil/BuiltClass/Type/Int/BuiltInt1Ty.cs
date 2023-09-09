using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Type.Int;

namespace LLVMSharpUtil_.BuiltClass.Type.Int;

public class BuiltInt1Ty : BuiltType
{

    public PreInt1Ty preInt1Ty;

    public unsafe BuiltInt1Ty(PreInt1Ty preInt1Ty, LLVMOpaqueType* llvmType) : base(preInt1Ty, llvmType)
    {
        this.preInt1Ty = preInt1Ty;
    }

}
