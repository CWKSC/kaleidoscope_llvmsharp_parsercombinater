using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Terminator;

namespace LLVMSharpUtil_.BuiltClass.Inst.Terminator;

public class BuiltBrInst : BuiltInst
{

    public PreBrInst preBrInst;

    public unsafe BuiltBrInst(
        PreBrInst preBrInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preBrInst, llvmValue, llvmType)
    {
        this.preBrInst = preBrInst;
    }

}
