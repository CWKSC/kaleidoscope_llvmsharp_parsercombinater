using LLVMSharp.Interop;
using LLVMSharpUtil_;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.Class.General;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.PreClass.Constant;
using LLVMSharpUtil_.PreClass.Func;
using LLVMSharpUtil_.PreClass.Inst.Other;
using LLVMSharpUtil_.PreClass.Inst.Terminator;
using LLVMSharpUtil_.PreClass.Type;
using LLVMSharpUtil_.PreClass.Type.Int;
using LLVMSharpUtil_.PreClass.Var.GlobVar;

unsafe void PureMethod()
{
    // Context and Module
    var context = LLVM.ContextCreate();
    var module = LLVM.ModuleCreateWithNameInContext("Hello World".ToSbytePointer(), context);

    // Declare puts()
    var putsReturnTy = LLVM.VoidType();
    var putsArgTy = new[] { LLVM.PointerType(LLVM.Int8Type(), 0) }.ToLLVMOpaqueTypePointerPointer();
    var putsFuncTy = LLVM.FunctionType(putsReturnTy, putsArgTy, 1, 0);
    var putsFunc = LLVM.AddFunction(module, "puts".ToSbytePointer(), putsFuncTy);
    LLVM.SetLinkage(putsFunc, LLVMLinkage.LLVMExternalLinkage);

    // Declare main()
    var mainReturnTy = LLVM.Int32Type();
    var mainArgTy = new LLVMOpaqueType*[] { }.ToLLVMOpaqueTypePointerPointer();
    var mainFuncTy = LLVM.FunctionType(mainReturnTy, mainArgTy, 0, 0);
    var mainFunc = LLVM.AddFunction(module, "main".ToSbytePointer(), mainFuncTy);

    // Entry basic block
    var entryBasicBlock = LLVM.CreateBasicBlockInContext(context, "entry".ToSbytePointer());
    var builder = LLVM.CreateBuilder();
    LLVM.PositionBuilderAtEnd(builder, entryBasicBlock);

    // Global const string
    var globVarTy = LLVM.ArrayType(LLVM.Int8Type(), (uint)("Hello World!".Length + 1));
    var globVar = LLVM.AddGlobal(module, globVarTy, "".ToSbytePointer());
    var initializerValue = LLVM.ConstString("Hello World!".ToSbytePointer(), (uint)"Hello World!".Length, 0);
    LLVM.SetInitializer(globVar, initializerValue);
    var constantIndices = new[] { LLVM.ConstInt(LLVM.Int32Type(), 0, 1), LLVM.ConstInt(LLVM.Int32Type(), 0, 1) }.ToLLVMOpaqueValuePointerPointer();
    var gep = LLVM.ConstGEP2(globVarTy, globVar, constantIndices, 2);

    // Call inst
    var llvmCallInst = LLVM.BuildCall2(
        builder,
        putsFuncTy,
        putsFunc,
        new[] { gep }.ToLLVMOpaqueValuePointerPointer(),
        1,
        "call_temp".ToSbytePointer()
    );

    // Ret inst
    var constInt0 = LLVM.ConstInt(LLVM.Int32Type(), (ulong)0, 1);
    var retInst = LLVM.BuildRet(builder, constInt0);
    LLVM.AppendExistingBasicBlock(mainFunc, entryBasicBlock);

    LLVM.DumpModule(module);
}

void WrapMethod()
{
    // Context and Module //
    var context = new PreContext();
    var module = new PreModule("Hello World");
    context.AddModule(module);

    // Declare puts()
    var putsReturnTy = new PreVoidTy();
    var putsArgTy = new List<PreType>() { new PrePointerTy(new PreInt8Ty()) };
    var putsFuncTy = new PreFuncTy(putsReturnTy, putsArgTy);
    var putsFunc = new PreExternFunc("puts", putsFuncTy, new() { "value" });
    module.AddFunc(putsFunc);

    // Declare main()
    var mainReturnTy = new PreInt32Ty();
    var mainArgTy = new List<PreType>() { };
    var mainFuncTy = new PreFuncTy(mainReturnTy, mainArgTy);
    var mainFunc = new PreFunc("main", mainFuncTy, new());
    module.AddFunc(mainFunc);

    // Entry basic block
    var entryBasicBlock = new PreBasicBlock("entry");
    mainFunc.AddBasicBlock(entryBasicBlock);

    // Global const string
    var constStr = new PreGlobalConstString("", "Hello World!");
    module.AddGlobalVar(constStr);

    // Call inst
    var callInst = new PreFuncCallInst(putsFunc, new() { constStr });
    entryBasicBlock.AddInst(callInst);

    // Ret inst
    var constInt0 = new PreConstSignInt32(0);
    var retInst = new PreRetInst(constInt0);
    entryBasicBlock.AddInst(retInst);

    Console.WriteLine(module.ToStr(new()));

    var builtContext = context.Build();
    Console.WriteLine(builtContext.ToStr());

}

WrapMethod();

