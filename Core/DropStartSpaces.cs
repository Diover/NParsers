namespace Core
{
    public class DropStartSpaces : DropStartSymbol
    {
        public DropStartSpaces(IParser<char, char> p)
            : base(p, ' ')
        {
        }
    }
}