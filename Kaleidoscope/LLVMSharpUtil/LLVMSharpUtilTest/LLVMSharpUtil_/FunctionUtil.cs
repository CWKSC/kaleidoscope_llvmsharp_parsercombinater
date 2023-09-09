using LLVMSharpUtil_.Class.General;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.PreClass.Func;
using LLVMSharpUtil_.PreClass.Type;

namespace LLVMSharpUtilTest.LLVMSharpUtil_;


[TestClass()]
public class FunctionUtil
{


    [TestMethod()]
    public unsafe void CreateAnonVoidFuncTest()
    {
        var context = new PreContext();
        var module = new PreModule();
        context.AddModule(module);

        var returnTy = new PreVoidTy();
        var argTy = new List<PreType>() { };
        var funcTy = new PreFuncTy(returnTy, argTy);
        var anonFunc = new PreAnonFunc(funcTy);
        module.AddFunc(anonFunc);

        var LLVMIR = module.ToStr(new());
        var builtContext = context.Build();
        var builtModule = builtContext.builtModuleList[0];
        var actual = builtModule.ToString();
        Console.WriteLine(actual);
        string expect = "\ndeclare void @0()\n";
        Assert.AreEqual(expect, actual);
    }



}