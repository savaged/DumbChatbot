using System;

namespace DumbChatbotLib
{
    public class BotBuilder
    {
        public static IBot Build()
        {
            return new Bot(new Memory(), new ResponseFactory());
        }

    }
}
