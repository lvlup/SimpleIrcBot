using System;

namespace SimpleIrcBot.Models
{
   public class TwitchInfo
    {
        //private const string host = "irc.twitch.tv";
        //private const UInt16 port = 6667;

       public string Host { get; set; }
       public  UInt16 Port { get; set; } 

       public TwitchInfo(string host, UInt16 port)
       {
           Host = host;
           Port = port;
       }
    }
}
