using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Arithmetic;

namespace LLVMSharpUtil_.BuiltClass.Inst.Binary;

public class BuiltAddInst : BuiltInst
{

    public PreAddInst preAddInst;

    public unsafe BuiltAddInst(
        PreAddInst preAddInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preAddInst, llvmValue, llvmType)
    {
        this.preAddInst = preAddInst;
    }

}
