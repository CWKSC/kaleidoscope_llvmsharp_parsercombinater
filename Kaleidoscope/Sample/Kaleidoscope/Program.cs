using CombinatorUtil;
using CombinatorUtil.Lexer.Dervied;
using Kaleidoscope;
using Kaleidoscope.Demo;
using Kaleidoscope.Parsing;

// https://llvm.org/docs/tutorial/MyFirstLanguageFrontend/LangImpl02.html
// https://llvm.org/docs/tutorial/MyFirstLanguageFrontend/LangImpl05.html


// var program = PrintStarDemo.GetProgram();
var program = MandelDemo.GetProgram();

var lexer = CommonLexer.New();
var lexerContext = ParsingContext.New(program);
var lexerResult = lexer.Parsing(lexerContext);
Console.WriteLine(lexerResult!.ToStr(new()));

var parser = Parser.New();
var parserContext = ParsingContext.New(lexerResult.list);
var parsingResult = parser.Parsing(parserContext);
Console.WriteLine("\n\nAST: ");
Console.WriteLine(parsingResult!.ToStr(new()));

unsafe
{
    Resource.Init("file");
    parsingResult.Codegen();

    Console.WriteLine("\n\nPre LLVM structure: ");
    Console.WriteLine(Resource.module.ToStr(new()));
    var builtContext = Resource.context.Build();

    Console.WriteLine("\n\nLLVM IR: ");
    builtContext.PrintModules();

    Console.WriteLine("Output: ");
    builtContext.builtModuleList[0].Run();
}


