﻿using CombinatorUtil.Node_;
using ListTreeUtil;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.PreClass.Inst.Compare.ICmp;
using PrinterUtil;

namespace Kaleidoscope.AST.Expr;

public class GreaterThanExprAST : BooleanExprAST
{

    public CodegenLLVMSharpEleNode LHS;
    public CodegenLLVMSharpEleNode RHS;

    public GreaterThanExprAST(CodegenLLVMSharpEleNode LHS, CodegenLLVMSharpEleNode RHS)
    {
        this.LHS = LHS;
        this.RHS = RHS;
    }

    public override unsafe PreGreaterThanInst Codegen()
    {
        var lhsEle = LHS.Codegen();
        if (lhsEle is not PreValue lhsValue) throw new Exception("lhs is not PreValue");

        var rhsEle = RHS.Codegen();
        if (rhsEle is not PreValue rhsValue) throw new Exception("rhs is not PreValue");

        return new(lhsValue, rhsValue);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "GreaterThanExprAST {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += $"LHS: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        if (LHS is Node lhsNode)
        {
            result += lhsNode.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();

        result += $"RHS: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        if (RHS is Node rhsNode)
        {
            result += rhsNode.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
