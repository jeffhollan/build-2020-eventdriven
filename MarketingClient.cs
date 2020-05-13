using System.Threading.Tasks;

namespace Hollan.Function
{
    public interface IMarketingClient 
    {
        Task<string> AddNewLeadAsync(string body);
    }

    public class MarketingClient : IMarketingClient
    {
        public async Task<string> AddNewLeadAsync(string body)
        {
            return body;
        }
    }
}