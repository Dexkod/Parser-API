using System.Data;
using System.Text;
using WebApplication1.Interface.Realization;
using WebApplication1.Model;
using WebApplication1.Model.Interface;

namespace WebApplication1
{
    public static class CreateHtmlFile
    {
        public static async Task CreateFile<T>(T obj)
            where T : class, IJsonModel
        {
            string sb = "";
            switch (obj.Flag())
            {
                case "FactCats":
                    sb = CreateTable(obj as FactCats).ToString();
                    break;
                case "Bitcoin":
                    sb = CreateTable(obj as Bitcoin).ToString();
                    break;
            }
            using (var file = new FileStream("C:\\Users\\Михаил\\source\\repos\\WebApplication1\\WebApplication1\\html\\Parsing.html", FileMode.Create))
            {
                byte[] messageByte = Encoding.UTF8.GetBytes(sb);
                await file.WriteAsync(messageByte);
            }

        }

        public static StringBuilder CreateTable(FactCats factCats)
        {
            StringBuilder htmlResponse = new StringBuilder();
            htmlResponse.AppendLine(
                        "<table>\n" +
                            "<tr>" +
                                "<td>" +
                                    "Факты" +
                                "</td>" +
                                "<td>" +
                                    "Длина" +
                                "</td>" + 
                            "<tr>" +
                                "<td>" +
                                    $"{factCats.fact}" +
                                "</td>" +
                                "<td>" +
                                    $"{factCats.length}" +
                                "</td>" +
                            "</tr>" + 
                        "</table>");
            return htmlResponse;
        }

        public static StringBuilder CreateTable(Bitcoin bitcoin)
        {
            StringBuilder dates = new();
            foreach (var keyTime  in bitcoin.Time.Keys) {
                dates.AppendLine("<ul>");
                dates.AppendLine($"{keyTime}: {bitcoin.Time[keyTime]}");
                dates.AppendLine("</ul>");
            }

            StringBuilder bip = new StringBuilder("<table>\n" +
                            "<tr>" +
                                "<td>" +
                                    "Заголовки" +
                                "</td>" +
                                "<td>" +
                                    "Значения" +
                                "</td>" +
                            "</tr>");

            foreach(var keyBpi in bitcoin.bpi.Keys)
            {
                bip.AppendLine($"<tr><td>Code</td><td>{bitcoin.bpi[keyBpi].Code}</td></tr>");
                bip.AppendLine($"<tr><td>Symbol</td><td>{bitcoin.bpi[keyBpi].Symbol}</td></tr>");
                bip.AppendLine($"<tr><td>Rate</td><td>{bitcoin.bpi[keyBpi].Rate}</td></tr>");
                bip.AppendLine($"<tr><td>Description</td><td>{bitcoin.bpi[keyBpi].Description}</td></tr>");
                bip.AppendLine($"<tr><td>Rate_float</td><td>{bitcoin.bpi[keyBpi].Rate_float}</td></tr>");
            }
            bip.AppendLine("</table>");
            StringBuilder htmlResponse = new StringBuilder();
            htmlResponse.AppendLine(
                        "<h2>Время</h2>" +
                        "<p>" + dates.ToString() + "</p>" +
                        "<h2> Общие данные</h2>" +
                        $"<p>{bitcoin.Disclaimer}</p>" +
                        "<h2>Название криптовалюты</h2>" +
                        $"<p>{bitcoin.ChartName}</h2>" +
                         bip.ToString());
            return htmlResponse;
        }
    }
}
