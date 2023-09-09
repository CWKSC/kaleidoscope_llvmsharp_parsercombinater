using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Var.GlobVar;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type;
using LLVMSharpUtil_.PreClass.Type.Int;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Var.GlobVar;

public class PreGlobalConstString : PreGlobalVar
{

    public string value;

    public PreGlobalConstString(string name = "", string value = "") : base(name, new PrePointerTy(new PreInt8Ty()))
    {
        this.value = value;
    }

    public override unsafe BuiltGlobalConstString BuildGlobalVar(BuildContext context)
    {
        if (context.module.globalVarDict.TryGetValue(this, out var globalVar))
        {
            return (BuiltGlobalConstString)globalVar;
        }
        var llvmModule = context.module.llvmModule;
        var globVarTy = LLVM.ArrayType(LLVM.Int8Type(), (uint)(value.Length + 1));
        var globVar = LLVM.AddGlobal(llvmModule, globVarTy, "".ToSbytePointer());
        var initializerValue = LLVM.ConstString(value.ToSbytePointer(), (uint)value.Length, 0);
        LLVM.SetInitializer(globVar, initializerValue);
        var constantIndices = new[] { LLVMSharpUtil.constInt0, LLVMSharpUtil.constInt0 }.ToLLVMOpaqueValuePointerPointer();
        var gep = LLVM.ConstGEP2(globVarTy, globVar, constantIndices, 2);

        //var builder = context.basicBlockBuilder!.llvmBuilder;
        //var llvmValue = LLVM.BuildGlobalStringPtr(builder, value.ToSbytePointer(), name.ToSbytePointer());
        //var llvmType = type.Build(context).llvmType;
        return new(this, gep, globVarTy);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += $"GlobalConstString {{ {value} }}".ToStr(printer);
        return result;
    }

}
