namespace Core
{
    public class Branch : ITree
    {
        private readonly ITree _left;
        private readonly ITree _right;

        public Branch(ITree left, ITree right)
        {
            _left = left;
            _right = right;
        }

        public string Eval()
        {
            return string.Format("({0}, {1})", _left.Eval(), _right.Eval());
        }
    }
}