using System;
using DumbChatbotLib;

namespace DumbChatbotCLI
{
    class App
    {
        private const string EXIT_WORD = "quit";
        private readonly IBot _bot;

        public App()
        {
            _bot = BotBuilder.Build();
        }

        public void Start()
        {
            Console.WriteLine($"Listening... (type {EXIT_WORD} to exit)");

            string heard = "";
            while (true)
            {
                heard = Console.ReadLine().ToLower();

                Present(_bot.Chat(heard));

                if (heard == EXIT_WORD)
                {
                    break;
                }
                Present(_bot.Chat(heard));
            }
        }

        private void Present(string output)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(output);
            Console.ResetColor();
        }

    }
}
