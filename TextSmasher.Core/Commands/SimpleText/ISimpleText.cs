namespace TextSmasher.Core.Commands
{
    public interface ISimpleText
    {
         string Run(string inputText, out bool error);

         string Instructions();
    }
}