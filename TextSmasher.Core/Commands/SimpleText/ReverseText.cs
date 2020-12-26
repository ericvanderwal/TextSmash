using System;

namespace TextSmasher.Core.Commands.Text
{
    public class ReverseText : ISimpleText
    {
        private const string instructionText = "Reverse the direction of the text.";

        public string Run(string inputText, out bool error)
        {
            try
            {
                error = false;

                char[] reverse = inputText.ToCharArray();
                Array.Reverse(reverse);

                return new string(reverse);
            }
            catch (Exception e)
            {
                error = true;
                return "Error Message:" + e.ToString();
            }
        }

        public string Instructions()
        {
            return instructionText;
        }
    }
}