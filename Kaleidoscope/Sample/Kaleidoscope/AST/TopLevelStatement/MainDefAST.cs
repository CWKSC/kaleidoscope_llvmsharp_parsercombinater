using Kaleidoscope.AST.Statement;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.Class.General;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.PreClass.Type.Int;
using PrinterUtil;

namespace Kaleidoscope.AST.TopLevelStatement;

public class MainDefAST : TopLevelStatementAST
{

    public StatementsAST statements;

    public MainDefAST(StatementsAST statements)
    {
        this.statements = statements;
    }


    public PreFunc Codegen(PreModule module)
    {
        var mainReturnTy = new PreInt32Ty();
        var mainArgTy = new List<PreType>() { };
        var mainFuncTy = new PreFuncTy(mainReturnTy, mainArgTy);
        var mainFunc = new PreFunc("main", mainFuncTy, new());

        module.AddFunc(mainFunc);
        var basicBlock = new PreBasicBlock("entry");
        statements.Codegen(mainFunc, ref basicBlock);

        return mainFunc;
    }


    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "MainDef {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "statements: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var statement in statements)
        {
            result += statement.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
