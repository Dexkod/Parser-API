using WebApplication1.Interface;

namespace WebApplication1.Service
{
    public class ParsingService
    {
        public IParsing _parsing { get; }

        public ParsingService(IParsing parsing)
        {
            _parsing = parsing;
        }


    }
}
