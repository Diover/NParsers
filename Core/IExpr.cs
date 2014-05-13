namespace Core
{
    public interface IExpr<out T>
    {
        T Eval();
    }
}