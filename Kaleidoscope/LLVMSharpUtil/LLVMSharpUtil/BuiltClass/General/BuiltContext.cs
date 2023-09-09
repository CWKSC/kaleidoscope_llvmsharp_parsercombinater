using LLVMSharp.Interop;
using LLVMSharpUtil_.Class.General;

namespace LLVMSharpUtil_.BuiltClass.General;

public class BuiltContext
{

    public PreContext preContext;
    public unsafe LLVMOpaqueContext* llvmContext;
    public List<BuiltModule> builtModuleList = new();
    public Dictionary<string, BuiltModule> builtModuleDict = new();

    public unsafe BuiltContext(PreContext preContext, LLVMOpaqueContext* llvmContext)
    {
        this.preContext = preContext;
        this.llvmContext = llvmContext;
    }

    public void AddModule(BuiltModule module)
    {
        builtModuleList.Add(module);
        builtModuleDict[module.name] = module;
    }

    public void PrintModules()
    {
        foreach (var module in builtModuleList)
        {
            module.Print();
        }
    }

    public string ToStr()
    {
        var result = "";
        foreach (var module in builtModuleList)
        {
            result += module.ToString();
        }
        return result;
    }



}
