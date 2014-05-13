namespace Core.Parsers
{
    public class DropStartSpaces : DropStartSymbol
    {
        public DropStartSpaces(IParser<char, char> p)
            : base(p, ' ')
        {
        }
    }
}