namespace SimpleIrcBot.Models
{
   public class PremiumUser
    {
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string CloneName { get; set; }

        public bool IsUseCloneNameInsteadNick { get; set; }
    }
}
