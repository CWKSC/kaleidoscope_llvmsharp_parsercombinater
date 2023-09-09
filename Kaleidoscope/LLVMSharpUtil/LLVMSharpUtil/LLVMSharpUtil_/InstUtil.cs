using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.BuiltClass.Builder;

namespace LLVMSharpUtil_;

public static partial class LLVMSharpUtil
{

    public static unsafe LLVMOpaqueValue* BuildAdd(BuiltValue lhs, BuiltValue rhs, BuiltBasicBlockBuilder builtBasicBlockBuilder)
    {
        var llvmLhsValue = lhs.llvmValue;
        var llvmRhsValue = rhs.llvmValue;
        var llvmBuilder = builtBasicBlockBuilder.llvmBuilder;
        return LLVM.BuildAdd(llvmBuilder, llvmLhsValue, llvmRhsValue, "add_temp".ToSbytePointer());
    }

    public static unsafe LLVMOpaqueValue* BuildFAdd(BuiltValue lhs, BuiltValue rhs, BuiltBasicBlockBuilder builtBasicBlockBuilder)
    {
        var llvmLhsValue = lhs.llvmValue;
        var llvmRhsValue = rhs.llvmValue;
        var llvmBuilder = builtBasicBlockBuilder.llvmBuilder;
        return LLVM.BuildFAdd(llvmBuilder, llvmLhsValue, llvmRhsValue, "fadd_temp".ToSbytePointer());
    }



    public static unsafe LLVMOpaqueValue* BuildSub(BuiltValue lhs, BuiltValue rhs, BuiltBasicBlockBuilder builtBasicBlockBuilder)
    {
        var llvmLhsValue = lhs.llvmValue;
        var llvmRhsValue = rhs.llvmValue;
        var llvmBuilder = builtBasicBlockBuilder.llvmBuilder;
        return LLVM.BuildSub(llvmBuilder, llvmLhsValue, llvmRhsValue, "sub_temp".ToSbytePointer());
    }

    public static unsafe LLVMOpaqueValue* BuildFSub(BuiltValue lhs, BuiltValue rhs, BuiltBasicBlockBuilder builtBasicBlockBuilder)
    {
        var llvmLhsValue = lhs.llvmValue;
        var llvmRhsValue = rhs.llvmValue;
        var llvmBuilder = builtBasicBlockBuilder.llvmBuilder;
        return LLVM.BuildFSub(llvmBuilder, llvmLhsValue, llvmRhsValue, "fsub_temp".ToSbytePointer());
    }

}
