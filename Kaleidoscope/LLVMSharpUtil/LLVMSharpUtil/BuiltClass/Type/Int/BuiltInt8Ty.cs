using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Type.Int;

namespace LLVMSharpUtil_.BuiltClass.Type.Int;

public class BuiltInt8Ty : BuiltType
{

    public PreInt8Ty preInt8Ty;

    public unsafe BuiltInt8Ty(PreInt8Ty preInt8Ty, LLVMOpaqueType* llvmType) : base(preInt8Ty, llvmType)
    {
        this.preInt8Ty = preInt8Ty;
    }

}
