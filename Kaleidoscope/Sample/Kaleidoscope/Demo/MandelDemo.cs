using ListTreeUtil;
using ListTreeUtil.Extension;

namespace Kaleidoscope.Demo;

public class MandelDemo
{

    public static LinkedList<ASTNode> GetProgram() => @"
extern putchar(int32 x): int32

def printdensity(double d): void {
    if d > 8.0 {
        call putchar(32); // ' '
        return;
    }
    if d > 4.0 {
        call putchar(46); // '.'
        return;
    }
    if d > 2.0 {
        call putchar(43); // '+'
    } else {
        call putchar(42); // '*'
    }
    return;
}

def mandelconverger(
    double real, 
    double imag,
    double iters, 
    double creal,
    double cimag
): double {
    if iters > 255.0 {
        return iters;
    }
    if real * real + imag * imag > 4.0 {
        return iters;
    }
    return mandelconverger(
        real * real - imag * imag + creal,
        2.0 * real * imag + cimag,
        iters + 1.0, creal, cimag
    );
}

def mandelconverge(double real, double imag): double {
    return mandelconverger(real, imag, 0.0, real, imag);
}

def mandelhelp(
    double xmin, 
    double xmax, 
    double xstep, 
    double ymin, 
    double ymax, 
    double ystep
): void {
    var y: double = ymin;
    while y < ymax {
        var x: double = xmin;
        while x < xmax {
            call printdensity(mandelconverge(x, y)));
            x = x + xstep;
        }
        call putchar(10);
        y = y + ystep;
    }
    return;
}

def mandel(
    double realstart,
    double imagstart,
    double realmag,
    double imagmag
): void {
    call mandelhelp(
        realstart, 
        realstart + realmag * 78.0, 
        realmag,
        imagstart, 
        imagstart + imagmag * 40.0, 
        imagmag
    );
    return;
}

main {
    call mandel(-2.3, -1.3, 0.05, 0.07);
    call putchar(10);

    call mandel(0.1, -1.0, 0.03, 0.05);
    call putchar(10);

    call mandel(-0.9, -1.4, 0.02, 0.03);
    call putchar(10);

    call mandel(-0.0, -0.0, 0.02, 0.03);
    call putchar(10);

    return 0;
}
"
.ToNodeOrList();


}
