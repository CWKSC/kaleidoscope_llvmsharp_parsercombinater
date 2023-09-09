using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Compare.ICmp;

namespace LLVMSharpUtil_.BuiltClass.Inst.Compare.ICmp;

public class BuiltSignedLessThanInst : BuiltInst
{

    public PreLessThanInst preSignedLessThanInst;

    public unsafe BuiltSignedLessThanInst(
        PreLessThanInst preSignedLessThanInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preSignedLessThanInst, llvmValue, llvmType)
    {
        this.preSignedLessThanInst = preSignedLessThanInst;
    }

}
