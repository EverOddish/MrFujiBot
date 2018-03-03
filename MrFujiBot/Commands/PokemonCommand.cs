internal class PokemonCommand : Command, ITextHandler
{
    private FujiTextHandler fujiTextHandler;

    public PokemonCommand(FujiTextHandler fujiTextHandler)
    {
        this.fujiTextHandler = fujiTextHandler;
    }

    public void HandleText(string sourceUser, string text)
    {
        if(text.StartsWith("!pokemon ", cmp))
        {
            fujiTextHandler.Output("Hello");
        }
    }
}