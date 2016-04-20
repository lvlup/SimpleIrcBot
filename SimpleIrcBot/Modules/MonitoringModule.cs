using System;
using System.Collections.Generic;
using System.IO;
using SimpleIrcBot.Models;

namespace SimpleIrcBot.Modules
{
   public class MonitoringModule
   {
       private BotModule botModule;
       private CommandModule commandModule;
       private ParserModule parserModule;

       public MonitoringModule(BotModule botModule, CommandModule commandModule, ParserModule parserModule)
       {
           this.botModule = botModule;
           this.commandModule = commandModule;
           this.parserModule = parserModule;
       }

       public void StartListenChannel(string channel)
       {
            botModule.JoinChannel(channel);

           while (true)
           {
                var inputMessage = botModule.ReadMessage();

                string nickname = parserModule.GetNickName(inputMessage);
                Console.WriteLine(string.Format("Пользователь {0} сказал: {1}", nickname, parserModule.GetMessage(inputMessage)));

                commandModule.HelloToJoined(inputMessage, channel, nickname);

                botModule.PingPong(inputMessage);

                commandModule.GreetingsFirstMessage(nickname, channel);
                commandModule.RespondCommandHello(channel, inputMessage, nickname);
            }
       }

       public void StartListenChannels(List<string> channels, HunterModule hunterModule)
       {
           foreach (var ch in channels)
           {
                botModule.JoinChannel(ch);
           }

            while (true)
            {
                var inputMessage = botModule.ReadMessage();
               
                string nickname = parserModule.GetNickName(inputMessage);
                hunterModule.CatchKey(nickname,inputMessage);

               Console.WriteLine(string.Format("Пользователь {0} сказал: {1}", nickname, parserModule.GetMessage(inputMessage)));

               botModule.PingPong(inputMessage);
            }
        }


      

    }
}
