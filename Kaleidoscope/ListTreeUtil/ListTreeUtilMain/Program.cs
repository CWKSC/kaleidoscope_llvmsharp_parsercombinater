using ListTreeUtil;

var meow = new Node<string>("meow \'");
var owo = new Node<string>("owo \"");
var ouo = new Node<string>("ouo \\");
var dvd = new Node<string>("dvd \n");
var qwq = new Node<string>("qwq \r");
var uwu = new Node<string>("uwu \t");
var oao = new Node<string>("oao \b");
var lol = new Node<string>("lol \0");

var list = new GeneralNotNullLList() {
    meow,
    owo,
    new GeneralLList() {
        ouo,
        null,
        dvd,
        new GeneralLList() {
            qwq,
            uwu,
            null
        },
        oao
    },
    lol
};
Console.WriteLine(list.ToStr(new()));

/*
↘
meow '
owo "
    ↘
    ouo \\
    (null)
    dvd \n
        ↘
        qwq \r
        uwu \t
        (null)
        ↙
    oao \b
    ↙
lol \0
↙
*/
