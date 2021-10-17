using System.Collections.Generic;

namespace DumbChatbotLib
{
    public interface IResponseFactory
    {
        IList<string> GetFor(string heard);
    }
}
