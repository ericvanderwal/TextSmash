using System;

namespace TextSmasher.Core.Commands.Text
{
    public class ToUpperAll : ISimpleText
    {
        private const string instructionText = "Convert all text to uppercase (capital) letters.";

        public string Run(string inputText, out bool error)
        {
            try
            {
                error = false;
                return inputText.ToUpper();
            }
            catch (Exception e)
            {
                error = true;
                return e.ToString();
            }
        }

        public string Instructions()
        {
            return instructionText;
        }
    }
}