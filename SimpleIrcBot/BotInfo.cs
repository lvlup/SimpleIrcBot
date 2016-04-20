using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIrcBot
{
   public class BotInfo
    {
       public string Username { get; private set; }

       public string Password { get; private set; }

       public BotInfo(string username, string password)
       {
           this.Username = username;
           this.Password = password;
       }
    }
}
