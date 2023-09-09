namespace ListTreeUtil.Base;

public class TripleNode<T1, T2, T3> : Node
{

    public T1 t1;
    public T2 t2;
    public T3 t3;

    public TripleNode(T1 t1, T2 t2, T3 t3)
    {
        this.t1 = t1;
        this.t2 = t2;
        this.t3 = t3;
    }

    public void Deconstruct(out T1 t1, out T2 t2, out T3 t3)
    {
        t1 = this.t1;
        t2 = this.t2;
        t3 = this.t3;
    }

}
