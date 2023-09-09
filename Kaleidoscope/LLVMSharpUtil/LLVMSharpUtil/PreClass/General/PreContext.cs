using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.General;
using PrinterUtil;

namespace LLVMSharpUtil_.Class.General;

public class PreContext : IToStr
{

    public List<PreModule> moduleList = new();
    public Dictionary<string, PreModule> moduleDict = new();

    public unsafe BuiltContext Build()
    {
        var llvmContext = LLVM.ContextCreate();
        var builtContext = new BuiltContext(this, llvmContext);
        foreach (var module in moduleList)
        {
            var builtModule = module.Build(builtContext);
            builtContext.AddModule(builtModule);
        }
        return builtContext;
    }

    public void AddModule(PreModule module)
    {
        moduleList.Add(module);
        moduleDict[module.name] = module;
    }


    public string ToStr(Printer printer)
    {
        throw new NotImplementedException();
    }

    //public PreModule CreateModule(string name) => new(this, name);
    //public PreBasicBlock CreateBasicBlock(string name) => new(this, name);
    //public (PreBasicBlock, PreBuilder) CreateBasicBlockWithBuilder(string name)
    //{
    //    var basicBlock = CreateBasicBlock(name);
    //    var builder = basicBlock.CreateBuilder();
    //    return (basicBlock, builder);
    //}

}
