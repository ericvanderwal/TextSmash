using System;

namespace TextSmasher.Core.Commands.Text
{
    public class ToLowerAll : ISimpleText
    {
        private const string instructionText = "Convert all text to lowercase letters.";
        
        public string Run(string inputText, out bool error)
        {
            try
            {
                error = false;
                return inputText.ToLower();
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