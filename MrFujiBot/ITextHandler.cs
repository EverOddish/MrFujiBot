internal interface ITextHandler
{
    bool HandleText(string sourceUser, string text, System.Action<string> outputFunction);
}