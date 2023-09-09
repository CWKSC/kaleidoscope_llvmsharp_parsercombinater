using LLVMSharp.Interop;
using LLVMSharpUtil_.Class.Type;

namespace LLVMSharpUtil_.BuiltClass.Type;

public class BuiltFuncTy : BuiltType
{

    public PreFuncTy preFuncTy;

    public unsafe BuiltFuncTy(PreFuncTy preFuncTy, LLVMOpaqueType* type) : base(preFuncTy, type)
    {
        this.preFuncTy = preFuncTy;
    }

}
