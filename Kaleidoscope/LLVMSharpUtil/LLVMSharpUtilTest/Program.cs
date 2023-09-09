using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.Class.General;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.PreClass.Constant;
using LLVMSharpUtil_.PreClass.Func;
using LLVMSharpUtil_.PreClass.Inst.Arithmetic;
using LLVMSharpUtil_.PreClass.Inst.Memory;
using LLVMSharpUtil_.PreClass.Inst.Other;
using LLVMSharpUtil_.PreClass.Inst.Terminator;
using LLVMSharpUtil_.PreClass.Type;
using LLVMSharpUtil_.PreClass.Type.Int;

// Context and Module
var context = new PreContext();
var module = new PreModule("Hello World");
context.AddModule(module);

// Declare puts()
var putsReturnTy = new PreVoidTy();
var putsArgTy = new List<PreType>() { new PrePointerTy(new PreInt8Ty()) };
var putsFuncTy = new PreFuncTy(putsReturnTy, putsArgTy);
var putsFunc = new PreExternFunc("puts", putsFuncTy, new() { "value" });
module.AddFunc(putsFunc);

// Declare putchar()
var putcharReturnTy = new PreInt32Ty();
var putcharArgTy = new List<PreType>() { new PreInt32Ty() };
var putcharFuncTy = new PreFuncTy(putcharReturnTy, putcharArgTy);
var putcharFunc = new PreExternFunc("putchar", putcharFuncTy, new() { "value" });
module.AddFunc(putcharFunc);

// Declare main()
var returnTy = new PreInt32Ty();
var argTys = new List<PreType>() { };
var funTy = new PreFuncTy(returnTy, argTys);
var func = new PreFunc("main", funTy, new List<string>() { });
module.AddFunc(func);

// Entry basic block
var entryBasicBlock = new PreBasicBlock("entry");
func.AddBasicBlock(entryBasicBlock);

// Alloc
var allocInst = new PreAllocInst("x", new PreInt32Ty());
var loadInst = allocInst.GetLoadInst();
entryBasicBlock.AddInst(allocInst);

// Store 1 into x
var storeInst1 = new PreStoreInst(allocInst, new PreConstSignInt32(108));
entryBasicBlock.AddInst(storeInst1);

// Call putchar
var funcCallInst1 = new PreFuncCallInst(putcharFunc, new() { loadInst });
entryBasicBlock.AddInst(funcCallInst1);

// Add
var addInst = new PreAddInst(loadInst, new PreConstSignInt32(1));
entryBasicBlock.AddInst(addInst);

// Store
var storeInst2 = new PreStoreInst(allocInst, addInst);
entryBasicBlock.AddInst(storeInst2);

// Call putchar
var funcCallInst2 = new PreFuncCallInst(putcharFunc, new() { loadInst });
entryBasicBlock.AddInst(funcCallInst2);


// Return 0 
var constInt0 = new PreConstSignInt32(0);
var retInt0Inst = new PreRetInst(constInt0);
entryBasicBlock.AddInst(retInt0Inst);


Console.WriteLine(module.ToStr(new()));

var builtContext = context.Build();
Console.WriteLine(builtContext.ToStr());



//var thenBasicBlock = new PreBasicBlock("then");
//var elseBasicBlock = new PreBasicBlock("else");
//var mergeBasicBlock = new PreBasicBlock("after_if_else");
//func.AddBasicBlock(thenBasicBlock);
//func.AddBasicBlock(elseBasicBlock);
//func.AddBasicBlock(mergeBasicBlock);

//var constInt1 = new PreConstSignInt32(1);
//var constInt2 = new PreConstSignInt32(2);
//var constInt3 = new PreConstSignInt32(3);
//var signedLessThanInst = new PreSignedLessThanInst(constInt1, constInt2);
//var condBrInst = new PreCondBrInst(signedLessThanInst, thenBasicBlock, elseBasicBlock);
//entryBasicBlock.AddInst(condBrInst);

//var brMergeInst = new PreBrInst(mergeBasicBlock);

//var retInt1Inst = new PreRetInst(constInt1);
//thenBasicBlock.AddInst(retInt1Inst);
//thenBasicBlock.AddInst(brMergeInst);

//var retInt2Inst = new PreRetInst(constInt2);
//elseBasicBlock.AddInst(retInt2Inst);
//elseBasicBlock.AddInst(brMergeInst);

//var retInt3Inst = new PreRetInst(constInt3);
//mergeBasicBlock.AddInst(retInt3Inst);


