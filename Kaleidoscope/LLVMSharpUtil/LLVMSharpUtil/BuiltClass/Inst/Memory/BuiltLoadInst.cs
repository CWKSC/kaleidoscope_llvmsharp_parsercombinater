using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Memory;

namespace LLVMSharpUtil_.BuiltClass.Inst.Memory;

public class BuiltLoadInst : BuiltInst
{

    public PreLoadInst preLoadInst;

    public unsafe BuiltLoadInst(
        PreLoadInst preLoadInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preLoadInst, llvmValue, llvmType)
    {
        this.preLoadInst = preLoadInst;
    }



}
