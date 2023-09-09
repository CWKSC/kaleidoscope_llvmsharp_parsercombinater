namespace ListTreeUtil.Base;

public class PairNode<T1, T2> : Node
{

    public T1 t1;
    public T2 t2;

    public PairNode(T1 t1, T2 t2)
    {
        this.t1 = t1;
        this.t2 = t2;
    }

    public void Deconstruct(out T1 t1, out T2 t2)
    {
        t1 = this.t1;
        t2 = this.t2;
    }

}
