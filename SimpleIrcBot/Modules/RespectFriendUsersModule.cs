using System.Collections.Generic;
using System.Linq;
using SimpleIrcBot.Models;

namespace SimpleIrcBot.Modules
{
   public class RespectFriendUsersModule
    {
       private List<FriendUser> FriendsUsers = new List<FriendUser>()
       {
           new FriendUser() { NickName = "driverrs", FirstName = "Рома", LastName = "топерХарлей"},
           new FriendUser() { NickName = "junior_20k", FirstName = "Димоныыыч", LastName = "Стрельников"}
       };

       private Dictionary<string, bool> GreetingsFriendsUsersDictionary;

       public RespectFriendUsersModule()
       {
           GreetingsFriendsUsersDictionary = new Dictionary<string, bool>()
           {
               {FriendsUsers[0].NickName.ToLower(), false},
               {FriendsUsers[1].NickName.ToLower(), false}
           };
       }

       public bool IsGreetings(string nickname)
       {
           bool value = false;
           if (GreetingsFriendsUsersDictionary.TryGetValue(nickname, out value))
           {
               if (value)
               {
                   return false;
               }
               GreetingsFriendsUsersDictionary[nickname] = true;
               return true;
           }
           return false;
       }


        public string GreetingMessage(string nickname)
        {
            var friend = FriendsUsers.FirstOrDefault(n => n.NickName.ToLower() == nickname);

            return string.Format("Приветствую {0}!", friend == null ? nickname : friend.FirstName);
        }
    }
}
