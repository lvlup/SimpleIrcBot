using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIrcBot.Commands
{
   public static class CommandProccesor
    {
       private const string huntedNickname = "OfficialParagonBot";

       public static void PingPong(string inputMessage, StreamWriter writer)
       {
            if (inputMessage.Contains("PING :tmi.twitch.tv"))
            {
                writer.WriteLine("PONG :tmi.twitch.tv");
                writer.Flush();
                Console.WriteLine("Ping? Pong");
            }
        }

       public static void HereMyYoutubeChannel(string message, StreamWriter writer)
       {
           if (message.Contains("!youtube"))
           {
               writer.WriteLine(string.Format("Подписывайтесь на мой ютуб канал! {0}","url"));
               writer.Flush();
               Console.WriteLine("Ping? Pong");
           }
       }


       public static string GetMessage(string inputMessage)
       {
           string message = string.Empty;
           try
           {
               var strings = inputMessage.Split(new string[] { ":" }, StringSplitOptions.None);

               if (!string.IsNullOrEmpty(strings[2]))
               {
                   message = inputMessage.Substring(inputMessage.IndexOf(strings[2], StringComparison.Ordinal));
               }

           }
           catch (Exception)
           {
               //do nothing
           }

           return message;
       }


       public static string GetNickName(string inputMessage)
       {
           string nickname = string.Empty;
           try
           {
               nickname = inputMessage.Substring(1, inputMessage.IndexOf("!", StringComparison.Ordinal) - 1);
           }
           catch (Exception)
           {
               //do nothing
           }

           return nickname;
       }

       public static void CatchKey(string nickname, string inputMessage)
       {
           if (nickname == huntedNickname && inputMessage.Contains("Early Access preview"))
           {
               using (var file = new StreamWriter(@"C:\Keys\ParagonKeys.txt", true))
               {
                   file.WriteLine(inputMessage);
               }
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Founded");
               Console.ResetColor();
           }
       }

    }
}
