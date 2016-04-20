using System;
using System.IO;

namespace SimpleIrcBot.Modules
{
   public class HunterModule
   {
       private string huntedNickPersone;
       private string pathToFile;

       public HunterModule(string nickname, string path)
       {
           huntedNickPersone = nickname;
           //pathToFile = @"C:\Keys\ParagonKeys.txt";
       }

       public  void CatchKey(string nickname, string inputMessage)
       {
           if (nickname == huntedNickPersone && inputMessage.Contains("Early Access preview"))
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
