using System.Text;
using WebApplication1.Model;
using static System.Net.WebRequestMethods;

namespace WebApplication1.Interface.Realization
{
    public class ParseCatFacts : IParsing
    {
        public async Task Parse(HttpRequest request)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("https://catfact.ninja/fact");

                if (response != null)
                {
                    var factCats = await response.Content.ReadFromJsonAsync<FactCats>();
                    await CreateHtmlFile.CreateFile<FactCats>(factCats);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

 
}