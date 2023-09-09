using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.BuiltClass.BasicBlock;
using LLVMSharpUtil_.BuiltClass.Inst.Memory;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.PreClass.Inst.Memory;

namespace LLVMSharpUtil_.BuiltClass.Func;

public class BuiltFunc : BuiltValue
{

    public PreFunc preFunc;

    public string name;
    //public List<BuiltBasicBlock> basicBlockList = new();
    //public Dictionary<string, BuiltBasicBlock> basicBlockDict = new();

    public List<PreBasicBlock> basicBlockList = new();
    public Dictionary<PreBasicBlock, BuiltBasicBlock> basicBlockDict = new();


    // Function args
    public List<BuiltValue> funcArgList = new();
    public Dictionary<string, BuiltValue> funcArgDict = new();
    public Dictionary<string, PreValue> funcArgPreValueDict = new();

    // Built Alloc Inst
    public List<BuiltAllocInst> builtAllocInstList = new();
    public Dictionary<string, BuiltAllocInst> builtAllocInstDict = new();

    // Pre Alloc Inst
    public List<PreAllocInst> preAllocInstList = new();
    public Dictionary<string, PreAllocInst> preAllocInstDict = new();

    // Pre Load Inst
    public List<PreLoadInst> preLoadInstList = new();
    public Dictionary<string, PreLoadInst> preLoadInstDict = new();


    public unsafe BuiltFunc(
        PreFunc preFunc,
        string name,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType,
        List<BuiltValue> funcArgList,
        Dictionary<string, BuiltValue> funcArgDict
    ) : base(preFunc, llvmValue, llvmType)
    {
        this.preFunc = preFunc;
        this.name = name;
        this.funcArgList = funcArgList;
        this.funcArgDict = funcArgDict;
    }


    public unsafe void AppendExistingBasicBlock(PreBasicBlock preBasicBlock, BuiltBasicBlock builtBasicBlock)
    {
        var llvmFunc = llvmValue;
        var llvmBasicBlock = builtBasicBlock.llvmBasicBlock;
        LLVM.AppendExistingBasicBlock(llvmFunc, llvmBasicBlock);
        basicBlockList.Add(preBasicBlock);
        basicBlockDict[preBasicBlock] = builtBasicBlock;

    }

    public void AddPreAllocInst(PreAllocInst preAllocInst)
    {
        preAllocInstList.Add(preAllocInst);
        preAllocInstDict[preAllocInst.name] = preAllocInst;
        var preLoadInst = preAllocInst.GetLoadInst();
        preLoadInstList.Add(preLoadInst);
        preLoadInstDict[preAllocInst.name] = preLoadInst;
    }

    public void AddBuiltAllocInst(BuiltAllocInst builtAllocInst)
    {
        var preAllocInst = builtAllocInst.preAllocInst;
        builtAllocInstList.Add(builtAllocInst);
        builtAllocInstDict[preAllocInst.name] = builtAllocInst;
    }

}
