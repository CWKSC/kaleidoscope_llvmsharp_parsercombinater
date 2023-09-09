using Kaleidoscope.AST.Statement;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.Class.General;
using PrinterUtil;

namespace Kaleidoscope.AST.TopLevelStatement;


public class FuncDefAST : TopLevelStatementAST
{

    public PrototypeAST prototype;
    public StatementsAST statements;

    public FuncDefAST(PrototypeAST prototype, StatementsAST statements)
    {
        this.prototype = prototype;
        this.statements = statements;
    }

    public PreFunc Codegen(PreModule module)
    {
        var name = prototype.name;
        var argNames = prototype.argNames;
        var funcTy = prototype.Codegen();

        var func = new PreFunc(name, funcTy, argNames);
        module.AddFunc(func);

        var basicBlock = new PreBasicBlock("entry");
        statements.Codegen(func, ref basicBlock);

        return func;
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "FuncDef {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "prototype: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += prototype.ToStr(printer) + "\n";
        printer.DecreaseIndent();

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
