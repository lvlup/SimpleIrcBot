using System;

namespace SimpleIrcBot.Modules
{
   public class ParserModule
    {
        public  string GetMessage(string inputMessage)
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


        public  string GetNickName(string inputMessage)
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
    }
}
