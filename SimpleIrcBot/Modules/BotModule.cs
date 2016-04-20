using System;
using System.IO;
using SimpleIrcBot.Models;

namespace SimpleIrcBot.Modules
{
   public class BotModule
   {
       private readonly Bot botModel;

       public BotModule(Bot bot)
       {
           botModel = bot;
       }

        public void JoinChannel(string channel)
        {
            botModel.Writer.WriteLine("JOIN #" + channel.ToLower());
            botModel.Writer.Flush();
        }

        public void SendMessage(string channel, string message)
        {
            //writer.WriteLine("PRIVMSG #" + channel.ToLower() + ":" + message);
            botModel.Writer.WriteLine(":" + botModel.UserName + "!" + botModel.UserName + "@" + botModel.UserName + ".tmi.twitch.tv PRIVMSG #" + channel +
                " :" + message);
            botModel.Writer.Flush();
        }

        public void LeaveChannel(string channel)
        {
            botModel.Writer.WriteLine("PART #" + channel.ToLower());
            botModel.Writer.Flush();
        }

        public string ReadMessage()
        {
            return botModel.Reader.ReadLine();
        }

        public void PingPong(string inputMessage)
        {
            if (inputMessage.Contains("PING :tmi.twitch.tv"))
            {
                botModel.Writer.WriteLine("PONG :tmi.twitch.tv");
                botModel.Writer.Flush();
                Console.WriteLine("Ping? Pong");
            }
        }
    }
}
