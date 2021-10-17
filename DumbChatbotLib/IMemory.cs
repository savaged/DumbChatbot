using System.Collections.Generic;

namespace DumbChatbotLib
{
    public interface IMemory
    {
        void Add(string heard, string said);
        IList<string> SaidWhen(string heard);
    }
}
