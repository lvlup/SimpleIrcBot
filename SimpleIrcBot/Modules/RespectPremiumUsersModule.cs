using System.Collections.Generic;
using System.Linq;
using SimpleIrcBot.Models;

namespace SimpleIrcBot.Modules
{

    public class RespectPremiumUsersModule 
    {
       private List<PremiumUser> PremUsers = new List<PremiumUser>()
       {
           new PremiumUser() { NickName = "superrussian1337", RealName = "name1", CloneName = "Рекс", IsUseCloneNameInsteadNick = true},
           new PremiumUser() { NickName = "707_Angel_707", RealName = "name2" , CloneName = "Коуди", IsUseCloneNameInsteadNick = false}
       };

       private Dictionary<string, bool> GreetingsPremUsersDictionary;

       public RespectPremiumUsersModule()
       {
           GreetingsPremUsersDictionary = new Dictionary<string, bool>()
           {
               {PremUsers[0].NickName, false},
               {PremUsers[1].NickName.ToLower(), false}
           };
       }

       public bool IsGreetings(string nickname)
       {
           bool value = false;
           if (GreetingsPremUsersDictionary.TryGetValue(nickname, out value))
           {
               if (value)
               {
                   return false;
               }
               GreetingsPremUsersDictionary[nickname] = true;
               return true;
           }
           return false;
       }


        public string GreetingMessage(string nickname)
        {
            var donater = PremUsers.FirstOrDefault(n => n.NickName.ToLower() == nickname);

            if (donater != null && donater.IsUseCloneNameInsteadNick)
            {
                return string.Format("Рад тебя видеть {0}. И еще раз спасибо за поддержку канала!", donater.CloneName);
            }

            return string.Format("Рад тебя видеть {0}. И еще раз спасибо за поддержку канала!", nickname);
        }
    }
}
