using WebApplication1.Model.Interface;

namespace WebApplication1.Model
{
    public class FactCats : IJsonModel
    {
        public string fact { get; set; }
        public int length { get; set; }

        public string Flag()
        {
            return "FactCats";
        }

        public override string ToString()
        {
            return $"Fact: {fact}\n Length{length}";
        }
    }
}
