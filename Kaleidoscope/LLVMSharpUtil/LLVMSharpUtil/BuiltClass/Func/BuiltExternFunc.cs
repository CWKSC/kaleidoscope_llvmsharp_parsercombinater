using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.PreClass.Func;

namespace LLVMSharpUtil_.BuiltClass.Func;

public class BuiltExternFunc : BuiltFunc
{

    public PreExternFunc preExternFunc;

    public unsafe BuiltExternFunc(
        PreExternFunc preExternFunc,
        string name,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType,
        List<BuiltValue> paramList,
        Dictionary<string, BuiltValue> paramDict
    ) : base(preExternFunc, name, llvmValue, llvmType, paramList, paramDict)
    {
        this.preExternFunc = preExternFunc;
    }


}