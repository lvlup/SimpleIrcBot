using System;

namespace SimpleIrcBot.Modules
{
   public class OutputConsoleModule
    {
       public void HiglightMessage(ConsoleColor color, string outputMessage)
       {
           Console.ForegroundColor = color;
           Console.WriteLine(outputMessage);
           Console.ResetColor();
       }

       public void PlaySignal()
       {
           int i = 0;
           while (i < 6)
           {
               Console.Beep();
               i++;
           }
       }

       public void PlayImpMarch()
       {
           Console.Beep(440,500);
           Console.Beep(440,500);
           Console.Beep(440,500);
           Console.Beep(349,350);
           Console.Beep(523,150);
           Console.Beep(440,500);
           Console.Beep(349,350);
           Console.Beep(523,150);
           Console.Beep(440,1000);
           Console.Beep(659,500);
           Console.Beep(659,500);
           Console.Beep(659,500);
           Console.Beep(698,350);
           Console.Beep(523,150);
           Console.Beep(415,500);
           Console.Beep(349,350);
           Console.Beep(523,150);
           Console.Beep(440,1000);
       }
    }
}
