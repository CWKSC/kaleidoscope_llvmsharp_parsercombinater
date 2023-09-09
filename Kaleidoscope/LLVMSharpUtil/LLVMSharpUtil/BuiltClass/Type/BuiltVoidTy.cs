using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Type;

namespace LLVMSharpUtil_.BuiltClass.Type;

public class BuiltVoidTy : BuiltType
{

    public PreVoidTy preVoidTy;

    public unsafe BuiltVoidTy(PreVoidTy preVoidTy, LLVMOpaqueType* llvmType) : base(preVoidTy, llvmType)
    {
        this.preVoidTy = preVoidTy;
    }

}
