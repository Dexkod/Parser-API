using System.Collections.Generic;
using WebApplication1.Model;
using static System.Net.WebRequestMethods;

namespace WebApplication1.Interface.Realization
{
    public class ParseCoinDesk : IParsing
    {
        public async Task Parse(HttpRequest request)
        {
            HttpClient client = new HttpClient();
            
            try
            {
                var response = await client.GetAsync("https://api.coindesk.com/v1/bpi/currentprice.json");

                if(response != null)
                {
                    var bitcoin = await response.Content.ReadFromJsonAsync<Bitcoin>();
                    await CreateHtmlFile.CreateFile<Bitcoin>(bitcoin);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }



}
