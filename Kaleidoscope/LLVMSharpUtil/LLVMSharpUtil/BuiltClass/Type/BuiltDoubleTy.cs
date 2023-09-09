using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Type;

namespace LLVMSharpUtil_.BuiltClass.Type;

public class BuiltDoubleTy : BuiltType
{

    public PreDoubleTy preDoubleTy;

    public unsafe BuiltDoubleTy(PreDoubleTy preDoubleTy, LLVMOpaqueType* llvmType) : base(preDoubleTy, llvmType)
    {
        this.preDoubleTy = preDoubleTy;
    }

}
