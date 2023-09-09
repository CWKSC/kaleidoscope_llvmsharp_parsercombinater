using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Terminator;

namespace LLVMSharpUtil_.BuiltClass.Inst.Terminator;

public class BuiltCondBrInst : BuiltInst
{

    public PreCondBrInst preCondBrInst;

    public unsafe BuiltCondBrInst(
        PreCondBrInst preCondBrInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preCondBrInst, llvmValue, llvmType)
    {
        this.preCondBrInst = preCondBrInst;
    }

}
