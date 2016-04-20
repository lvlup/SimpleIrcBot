using System;
using System.IO;

namespace SimpleIrcBot.Modules
{
    public class CommandModule
    {
        private BotModule botModule;
        private OutputConsoleModule consoleModule;
        private RespectPremiumUsersModule respectPremiumUsersModule;
        private RespectFriendUsersModule respectFriendUsersModule;

        public CommandModule(BotModule botModule,OutputConsoleModule consoleModule, RespectPremiumUsersModule premiumUsersModule, RespectFriendUsersModule respectFriendUsersModule)
        {
            this.botModule = botModule;
            this.consoleModule = consoleModule;
            this.respectPremiumUsersModule = premiumUsersModule;
            this.respectFriendUsersModule = respectFriendUsersModule;
        }

        public void GreetingsFirstMessage(string nickname, string channel)
        {
            if (respectPremiumUsersModule.IsGreetings(nickname))
            {
                botModule.SendMessage(channel, respectPremiumUsersModule.GreetingMessage(nickname));
                consoleModule.HiglightMessage(ConsoleColor.Green, "Я приветствовал донатера.");
                return;
            }
            if (respectFriendUsersModule.IsGreetings(nickname))
            {
                botModule.SendMessage(channel, respectFriendUsersModule.GreetingMessage(nickname));
                consoleModule.HiglightMessage(ConsoleColor.Green, "Я приветствовал друга.");
            }
        }

        public void HelloToJoined(string inputMessage, string channel, string nickname)
        {
            if (inputMessage.Contains("JOIN #" + channel) && nickname != "bot_ironknights")
            {
                botModule.SendMessage(channel, "Рад тебя видеть на своем канале " + nickname);
                consoleModule.HiglightMessage(ConsoleColor.Green, "Joined someone " + nickname);
            }
        }


        public void RespondCommandHello(string channel, string inputMessage, string nickname)
        {
            if (inputMessage.Contains("!Здорово"))
            {
                if (nickname == "IronKnight1".ToLower())
                {
                    botModule.SendMessage(channel, "Рад тебя видеть, Создатель");
                }
                else
                {
                    botModule.SendMessage(channel, "И тебе не болеть " + nickname);
                }
                Console.WriteLine("Со мной поздоровались.");
            }
        }
    }
}
