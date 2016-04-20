using System;
using System.Collections.Generic;
using SimpleIrcBot.Models;
using SimpleIrcBot.Modules;

namespace SimpleIrcBot
{
    class Program
    {
       static  void Main(string[] args)
        {
            List<string> channels = new List<string>()
            {
            "ZeratoR",
            "TehBeardedGamer",
            "Tatshukoo",
            "mirymirv7",
            "FizZoR",
            "A5StarDiningExperience",
            "Areliann",
            "Aero514",
            "Seansstream",
            "LIZERDBITS",
            "Frogsama",
            "Stormless",
            "Telecast3r",
             "demonsgalore_",
             "StarfishprimeX0",
             "DreggmanWhite"
            };

            var twitchinfo = new TwitchInfo("irc.twitch.tv", 6667);
            var bot = new Bot(twitchinfo, "your_bot_login", "your_bot_oauth");
            var botModule = new BotModule(bot);
            var consoleModule = new OutputConsoleModule();
            var respectPremUsers = new RespectPremiumUsersModule();
            var respectFriendUsers = new RespectFriendUsersModule();
            var parserModule = new ParserModule();
            var hunterModule = new HunterModule("OfficialParagonBot", "",consoleModule);

            var commandModule = new CommandModule(botModule, consoleModule, respectPremUsers, respectFriendUsers);
            var monitormodule = new MonitoringModule(botModule, commandModule, parserModule);

            consoleModule.HiglightMessage(ConsoleColor.Green, "!!!!!!!!!!Стартую наблюдение!!!!!!!!!!!!");
            //monitormodule.StartListenChannel("your_channel");
            monitormodule.StartListenChannels(channels, hunterModule);
        }
    }
}
