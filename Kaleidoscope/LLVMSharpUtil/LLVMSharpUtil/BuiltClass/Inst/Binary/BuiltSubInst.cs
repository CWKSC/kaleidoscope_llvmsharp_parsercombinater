using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Arithmetic;

namespace LLVMSharpUtil_.BuiltClass.Inst.Binary;

public class BuiltSubInst : BuiltInst
{

    public PreSubInst preSubInst;

    public unsafe BuiltSubInst(
        PreSubInst preSubInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preSubInst, llvmValue, llvmType)
    {
        this.preSubInst = preSubInst;
    }

}
