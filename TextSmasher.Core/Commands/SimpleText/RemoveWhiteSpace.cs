using System;

namespace TextSmasher.Core.Commands.Text
{
    public class RemoveWhiteSpace : ISimpleText
    {
        private const string instructionText = "Remove all white space, including tabs, unicode spaces and new lines.";

        public string Run(string inputText, out bool error)
        {
            try
            {
                error = false;
// source: https://stackoverflow.com/questions/1279859/how-to-replace-multiple-white-spaces-with-one-white-space

                var len = inputText.Length;
                var src = inputText.ToCharArray();
                int dstIdx = 0;
                bool lastWasWS = false; //Added line
                for (int i = 0; i < len; i++)
                {
                    var ch = src[i];
                    switch (ch)
                    {
                        case '\u0020': //SPACE
                        case '\u00A0': //NO-BREAK SPACE
                        case '\u1680': //OGHAM SPACE MARK
                        case '\u2000': // EN QUAD
                        case '\u2001': //EM QUAD
                        case '\u2002': //EN SPACE
                        case '\u2003': //EM SPACE
                        case '\u2004': //THREE-PER-EM SPACE
                        case '\u2005': //FOUR-PER-EM SPACE
                        case '\u2006': //SIX-PER-EM SPACE
                        case '\u2007': //FIGURE SPACE
                        case '\u2008': //PUNCTUATION SPACE
                        case '\u2009': //THIN SPACE
                        case '\u200A': //HAIR SPACE
                        case '\u202F': //NARROW NO-BREAK SPACE
                        case '\u205F': //MEDIUM MATHEMATICAL SPACE
                        case '\u3000': //IDEOGRAPHIC SPACE
                        case '\u2028': //LINE SEPARATOR
                        case '\u2029': //PARAGRAPH SEPARATOR
                        case '\u0009': //[ASCII Tab]
                        case '\u000A': //[ASCII Line Feed]
                        case '\u000B': //[ASCII Vertical Tab]
                        case '\u000C': //[ASCII Form Feed]
                        case '\u000D': //[ASCII Carriage Return]
                        case '\u0085': //NEXT LINE
                            if (lastWasWS == false) //Added line
                            {
                                src[dstIdx++] = ' '; // Updated by Ryan
                                lastWasWS = true; //Added line
                            }

                            continue;
                        default:
                            lastWasWS = false; //Added line 
                            src[dstIdx++] = ch;
                            break;
                    }
                }

                return new string(src, 0, dstIdx);
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