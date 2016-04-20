using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using SimpleIrcBot.Commands;
using SimpleIrcBot.Modules;

namespace SimpleIrcBot
{
   public class BotClient
   {
       private TcpClient tcp;
       private StreamReader reader;
       private StreamWriter writer;

       private RespectPremiumUsersModule modulePremiumUsers;
       private RespectFriendUsersModule moduleFriendsUsers;
       private OutputConsoleModule consoleModule;

 #region значения
       private const string host = "irc.twitch.tv";
       private const UInt16 port = 6667;
       private const string username = "Bot_IronKnights";
       private const string password = "oauth:aggfmq7gp19hw3o64bn688f5xv0mis";
#endregion

       public BotClient()
       {
           modulePremiumUsers = new RespectPremiumUsersModule();
           moduleFriendsUsers = new RespectFriendUsersModule();
           consoleModule = new OutputConsoleModule();

           tcp = new TcpClient(host,port);
           var stream = tcp.GetStream();
           reader = new StreamReader(stream);
           writer  = new StreamWriter(stream);

           writer.WriteLine("PASS " + password);
           writer.WriteLine("NICK " + username.ToLower());
           writer.WriteLine("USER " + username.ToLower() + " 8 * :" + username.ToLower());
           writer.Flush();
       }

       public void JoinChannel(string channel)
       {
           writer.WriteLine("JOIN #" + channel.ToLower());
           writer.Flush();
       }

       public void SendMessage(string channel, string message)
       {
            //writer.WriteLine("PRIVMSG #" + channel.ToLower() + ":" + message);
            writer.WriteLine(":" + username + "!" + username + "@" + username + ".tmi.twitch.tv PRIVMSG #" + channel +
                " :" + message);
            writer.Flush();
       }

       public void LeaveChannel(string channel)
       {
           writer.WriteLine("PART #" + channel.ToLower());
           writer.Flush();
       }

       public string ReadMessage()
       {
           return reader.ReadLine();
       }
       

       public void  StartMonitoring(List<string> channels)
       {
           consoleModule.HiglightMessage(ConsoleColor.Green, "!!!!!!!!!!Стартую наблюдение!!!!!!!!!!!!");

           foreach (var cha in channels)
           {
                JoinChannel(cha);
           }
            
           while (true)
           {
                var inputMessage = ReadMessage();

                string nickname = CommandProccesor.GetNickName(inputMessage);
                Console.WriteLine(string.Format("Пользователь {0} сказал: {1}", nickname, CommandProccesor.GetMessage(inputMessage)));

                HelloToJoined(inputMessage, channels[0], nickname);

                CommandProccesor.PingPong(inputMessage,writer);

                CommandProccesor.CatchKey(nickname, inputMessage);

                GreetingsFirstMessage(nickname, channels[0]);

                RespondCommandHello(channels[0], inputMessage, nickname);
            }
        }

       private void GreetingsFirstMessage(string nickname, string channel)
       {
           if (modulePremiumUsers.IsGreetings(nickname))
           {
               SendMessage(channel, modulePremiumUsers.GreetingMessage(nickname));
               consoleModule.HiglightMessage(ConsoleColor.Green, "Я приветствовал донатера.");
               return;
           }
           if (moduleFriendsUsers.IsGreetings(nickname))
           {
               SendMessage(channel, moduleFriendsUsers.GreetingMessage(nickname));
               consoleModule.HiglightMessage(ConsoleColor.Green, "Я приветствовал друга.");
           }
       }

       public void HelloToJoined(string inputMessage, string channel, string nickname)
        {
            if (inputMessage.Contains("JOIN #" + channel) && nickname != "bot_ironknights")
            {
                SendMessage(channel, "Рад тебя видеть на своем канале " + nickname);
                Console.WriteLine("Joined someone " + nickname);
            }
        }

 

       private void RespondCommandHello(string channel, string inputMessage, string nickname)
       {
           if (inputMessage.Contains("!Здорово"))
           {
               if (nickname == "IronKnight1".ToLower())
               {
                   SendMessage(channel, "Рад тебя видеть, Создатель");
               }
               else
               {
                   SendMessage(channel, "И тебе не болеть " + nickname);
               }
               Console.WriteLine("Со мной поздоровались.");
           }
       }
   }

}
