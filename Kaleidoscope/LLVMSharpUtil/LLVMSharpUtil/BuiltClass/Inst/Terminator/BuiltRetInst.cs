using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Terminator;

namespace LLVMSharpUtil_.BuiltClass.Inst.Terminator;

public class BuiltRetInst : BuiltInst
{

    public PreRetInst preRetInst;

    public unsafe BuiltRetInst(
        PreRetInst preRetInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preRetInst, llvmValue, llvmType)
    {
        this.preRetInst = preRetInst;
    }

}
