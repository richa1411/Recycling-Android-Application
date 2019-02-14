using System;

namespace KymiraAdmin.Models
{
    public class Utils
    {
        public static string shortAnswer(string answer, int maxLen)
        {
            if(answer.Length > maxLen)
            {
                return answer.Substring(0, maxLen) + "...";
            }
            return answer;
        }

    }
}
