using PrinterUtil;

Printer printer = new()
{
    prefix = "(prefix) ",
    suffix = " (suffix)",
    foregroundColor = ConsoleColor.Green,
};
printer.WriteLine("it is green");

printer.foregroundColor = ConsoleColor.Red;
printer.WriteLine("it is red");

printer = new();
printer.WriteLine("escape character will be unescape by default: \' \" \\ \n \t \r \0");
printer.isUnescape = false;
printer.WriteLine("and we can close it by isUnescape = false: \' \" \\ \n \t \r \0");


/*
(prefix) it is green (suffix)
(prefix) it is red (suffix)
escape character will be unescape by default: ' " \\ \n \t \r \0
and we can close it by isUnescape = false: ' " \
*/

