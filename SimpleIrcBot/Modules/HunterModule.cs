using System;
using System.IO;

namespace SimpleIrcBot.Modules
{
   public class HunterModule
   {
        private string huntedNickPersone;
        private string pathToFile;
        private OutputConsoleModule consoleNotifer;

        public HunterModule(string nickname, string path, OutputConsoleModule consoleModule)
        {
            huntedNickPersone = nickname;
            consoleNotifer = consoleModule;
            //pathToFile = @"C:\Keys\ParagonKeys.txt";
        }

        public void CatchKey(string nickname, string inputMessage)
        {
            if (nickname == huntedNickPersone && inputMessage.Contains("Early Access preview"))
            {
                using (var file = new StreamWriter(@"C:\Keys\ParagonKeys.txt", true))
                {
                    file.WriteLine(inputMessage);
                }
                consoleNotifer.HiglightMessage(ConsoleColor.Red, "Founded");
                consoleNotifer.PlayImpMarch();
            }
        }
    }
}
