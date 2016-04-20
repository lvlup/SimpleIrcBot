using System.IO;
using System.Net.Sockets;

namespace SimpleIrcBot.Models
{
   public class Bot
    {
       private TcpClient tcp;
       public StreamReader Reader { get; set; }
       public StreamWriter Writer { get; set; }
       public string UserName { get; set; }
       private string Password { get; set; }


        #region значения
        //private const string username = "Bot_IronKnights";
        //private const string password = "oauth:aggfmq7gp19hw3o64bn688f5xv0mis";
        #endregion

        public Bot(TwitchInfo twitchInfo, string username,string password)
       {
           tcp = new TcpClient(twitchInfo.Host,twitchInfo.Port);
           var stream = tcp.GetStream();
           Reader = new StreamReader(stream);
           Writer  = new StreamWriter(stream);
           UserName = username.ToLower();
           Password = password;

           Writer.WriteLine("PASS " + Password);
           Writer.WriteLine("NICK " + UserName);
           Writer.WriteLine("USER " + UserName + " 8 * :" + UserName);
           Writer.Flush();
       }
    }
}
