using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Memory;

namespace LLVMSharpUtil_.BuiltClass.Inst.Memory;

public class BuiltStoreInst : BuiltInst
{

    public PreStoreInst preStoreInst;

    public unsafe BuiltStoreInst(PreStoreInst preStoreInst, LLVMOpaqueValue* llvmValue, LLVMOpaqueType* llvmType) : base(preStoreInst, llvmValue, llvmType)
    {
        this.preStoreInst = preStoreInst;
    }

}
