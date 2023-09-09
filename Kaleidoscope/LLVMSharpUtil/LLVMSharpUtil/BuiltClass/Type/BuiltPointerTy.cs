using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Type;

namespace LLVMSharpUtil_.BuiltClass.Type;

public class BuiltPointerTy : BuiltType
{

    public PrePointerTy prePointerTy;

    public unsafe BuiltPointerTy(PrePointerTy prePointerTy, LLVMOpaqueType* llvmType) : base(prePointerTy, llvmType)
    {
        this.prePointerTy = prePointerTy;
    }

}
