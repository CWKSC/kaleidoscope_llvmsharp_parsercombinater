using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.PreClass.Type;
using LLVMSharpUtil_.PreClass.Type.Int;

namespace LLVMSharpUtil_;

public static partial class LLVMSharpUtil
{


    public static unsafe PreType GetPreType(string name)
    {
        return name switch
        {
            "int1" => new PreInt1Ty(),
            "int8" => new PreInt8Ty(),
            "int32" => new PreInt32Ty(),
            "char" => new PreInt8Ty(),
            "double" => new PreDoubleTy(),
            "void" => new PreVoidTy(),
            _ => throw new NotImplementedException(),
        };
    }


}
