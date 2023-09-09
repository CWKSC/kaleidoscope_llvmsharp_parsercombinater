using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Memory;

namespace LLVMSharpUtil_.BuiltClass.Inst.Memory;

public class BuiltAllocInst : BuiltInst
{

    public PreAllocInst preAllocInst;

    public unsafe BuiltAllocInst(
        PreAllocInst preAllocInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preAllocInst, llvmValue, llvmType)
    {
        this.preAllocInst = preAllocInst;
    }


}
