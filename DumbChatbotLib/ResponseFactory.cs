using System.Collections.Generic;
using System.Linq;

namespace DumbChatbotLib
{
    public class ResponseFactory : IResponseFactory
    {
        private readonly IDictionary<string, IList<string>> _map;

        public ResponseFactory()
        {
            _map = new Dictionary<string, IList<string>>
            {
                { "hi", new List<string> { "Hi", "Hello", "Good day" } },
                { "quit", new List<string> { "Bye", "TTFN", "Next time" } }
            };
        }

        public IList<string> GetFor(string heard)
        {
            IList<string> response = new List<string> { "erm" };
            if (_map.ContainsKey(heard))
            {
                response = _map[heard];
            }
            return response;
        }

    }
}
