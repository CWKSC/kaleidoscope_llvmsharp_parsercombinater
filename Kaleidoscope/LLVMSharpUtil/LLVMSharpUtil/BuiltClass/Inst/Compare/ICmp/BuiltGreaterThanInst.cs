using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Compare.ICmp;

namespace LLVMSharpUtil_.BuiltClass.Inst.Compare.ICmp;

public class BuiltGreaterThanInst : BuiltInst
{

    public PreGreaterThanInst preSignedLessThanInst;

    public unsafe BuiltGreaterThanInst(
        PreGreaterThanInst preSignedGreaterThanInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preSignedGreaterThanInst, llvmValue, llvmType)
    {
        this.preSignedLessThanInst = preSignedGreaterThanInst;
    }

}
