using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.PreClass.Constant;

namespace LLVMSharpUtil_.BuiltClass.Const;

public class BuiltConstSignInt32 : BuiltValue
{

    public PreConstSignInt32 preConstSignInt32;

    public unsafe BuiltConstSignInt32(
        PreConstSignInt32 preConstSignInt32,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preConstSignInt32, llvmValue, llvmType)
    {
        this.preConstSignInt32 = preConstSignInt32;
    }

}
