using System;

namespace KymiraAdmin.Models
{
    /*If the answer is too long to fit on the page, this class will shorten is up 
     //Change this inside Views/FAQs/Index >> Line 32
    */
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
