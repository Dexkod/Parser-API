using WebApplication1.Interface.Realization;
using WebApplication1.Model.Interface;

namespace WebApplication1.Model
{
    public class Bitcoin : IJsonModel
    {
        public Dictionary<string, string> Time { get; set; }
        public string Disclaimer { get; set; }
        public string ChartName { get; set; }
        public Dictionary<string, Bpi> bpi { get; set; }

        public string Flag()
        {
            return "Bitcoin";
        }
    }
}
