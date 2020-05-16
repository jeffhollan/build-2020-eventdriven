using System.Threading.Tasks;

namespace Hollan.Function
{
    public interface IEventClient 
    {
        Task<string> ProcessEvent(string body);
    }

    public class EventClient : IEventClient
    {
        public async Task<string> ProcessEvent(string body)
        {
            return body;
        }
    }
}