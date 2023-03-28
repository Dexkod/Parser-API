using System.Text;

namespace WebApplication1.Interface
{
    public interface IParsing
    {
        Task Parse(HttpRequest request);
    }
}
