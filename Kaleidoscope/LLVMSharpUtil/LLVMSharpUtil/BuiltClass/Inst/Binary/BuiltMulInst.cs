using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Arithmetic;

namespace LLVMSharpUtil_.BuiltClass.Inst.Binary;

public class BuiltMulInst : BuiltInst
{

    public PreMulInst preMulInst;

    public unsafe BuiltMulInst(
        PreMulInst preMulInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preMulInst, llvmValue, llvmType)
    {
        this.preMulInst = preMulInst;
    }

}
