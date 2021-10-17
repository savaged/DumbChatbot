using System;
using System.Collections.Generic;
using System.Linq;

namespace DumbChatbotLib
{
    public class Bot : IBot
    {
        private readonly IMemory _memory;
        private readonly IResponseFactory _responseFactory;

        public Bot(
                IMemory memory,
                IResponseFactory responseFactory)
        {
            _memory = memory ??
                throw new ArgumentNullException(nameof(memory));
            _responseFactory = responseFactory ??
                throw new ArgumentNullException(nameof(responseFactory));
        }

        public string Chat(string heard = "")
        {
            var responses = _responseFactory.GetFor(heard);
            var say = PickRandom(responses);
            say = ApplyMemory(heard, say, responses);
            _memory.Add(heard, say);
            return say;
        }

        private string PickRandom(IList<string> responses)
        {
            if (responses?.Count < 1)
            {
                return "I got nothing";
            }
            var rand = new Random();
            return responses[rand.Next(0, responses.Count)];
        }

        private string ApplyMemory(
                string heard, string say, IList<string> responses)
        {
            IList<string> said = _memory.SaidWhen(heard);
            if (said?.Count > 0)
            {
                // TODO add more logic here
                say = $"Like I said, {say}";
            }
            return say;
        }

    }
}
