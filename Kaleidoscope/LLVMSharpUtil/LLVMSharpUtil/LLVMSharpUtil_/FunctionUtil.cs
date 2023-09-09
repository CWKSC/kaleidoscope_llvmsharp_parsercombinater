using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.General;
using LLVMSharpUtil_.BuiltClass.Type;

namespace LLVMSharpUtil_;

public static partial class LLVMSharpUtil
{

    public static unsafe LLVMOpaqueValue* AddFunction(BuiltModule module, string name, BuiltFuncTy funcTy)
    {
        return LLVM.AddFunction(module.llvmModule, name.ToSbytePointer(), funcTy.llvmType);
    }

    //// Create extern function //
    //public static unsafe void CreateExtern(
    //    out LLVMValueRef func,
    //    out LLVMOpaqueType* funcTy,

    //    LLVMOpaqueModule* module,
    //    string name,
    //    LLVMOpaqueType* returnType,
    //    LLVMOpaqueType*[] parameters,
    //    int isVarArg = 0
    //)
    //{
    //    var paramCount = (uint)parameters.Length;
    //    var paramTypes = parameters.ToLLVMOpaqueTypePointerPointer();
    //    funcTy = LLVM.FunctionType(returnType, paramTypes, paramCount, isVarArg);
    //    func = LLVM.AddFunction(module, name.ToSbytePointer(), funcTy);
    //    LLVM.SetLinkage(func, LLVMLinkage.LLVMExternalLinkage);
    //    if (name != "")
    //    {
    //        funcDict[name] = new PreFunc(func, funcTy);
    //    }
    //}


    //// Create function with entry basic block //
    //// return function and builder of entry basic block
    //public static unsafe (
    //    PreFunc,
    //    PreType,
    //    LLVMSharpBasicBlockBuilder
    //) CreateFunction(
    //    PreModule module,
    //    string name,
    //    PreFuncTy funcTy
    //)
    //{
    //    var llvmModule = module.Eval();
    //    var llvmFuncTy = funcTy.Eval();

    //    var func = LLVM.AddFunction(llvmModule, name.ToSbytePointer(), llvmFuncTy);
    //    var entry = LLVM.AppendBasicBlock(func, "entry".ToSbytePointer());
    //    var builder = LLVM.CreateBuilder();
    //    LLVM.PositionBuilderAtEnd(builder, entry);
    //    if (name != "")
    //    {
    //        funcDict[name] = new PreFunc(name, funcTy);
    //    }
    //    return
    //}

    //public static unsafe void CreateAnonFunc(
    //    out LLVMOpaqueValue* func,
    //    out LLVMOpaqueType* funcTy,
    //    out LLVMOpaqueBuilder* builder,

    //    LLVMOpaqueModule* module,
    //    LLVMOpaqueType* returnType,
    //    LLVMOpaqueType*[] parameters,
    //    int isVarArgs = 0
    //)
    //{
    //    CreateFunction(
    //        out func, out funcTy, out builder,
    //        module, "", returnType, parameters, isVarArgs
    //    );
    //    //var paramCount = (uint)parameters.Length;
    //    //var paramTypes = parameters.ToLLVMOpaqueTypePointerPointer();
    //    //var funcTy = LLVM.FunctionType(LLVM.VoidType(), paramTypes, paramCount, isVarArgs);
    //    //func = LLVM.AddFunction(module, "".ToSbytePointer(), funcTy);
    //    //var entry = LLVM.AppendBasicBlock(func, "entry".ToSbytePointer());
    //    //builder = LLVM.CreateBuilder();
    //    //LLVM.PositionBuilderAtEnd(builder, entry);
    //}

    //public static unsafe void CreateAnonVoidFunc(
    //    out LLVMOpaqueValue* func,
    //    out LLVMOpaqueType* funcTy,
    //    out LLVMOpaqueBuilder* builder,

    //    LLVMOpaqueModule* module
    //)
    //{
    //    int isVarArgs = 0;
    //    var returnType = LLVM.VoidType();
    //    var parameters = new LLVMOpaqueType*[] { };
    //    CreateFunction(
    //        out func, out funcTy, out builder,
    //        module, "", returnType, parameters, isVarArgs
    //    );
    //}

}
