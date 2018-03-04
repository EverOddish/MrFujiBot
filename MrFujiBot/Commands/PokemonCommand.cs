internal class PokemonCommand : Command, ITextHandler
{
    private FujiTextHandler fujiTextHandler;

    public PokemonCommand(FujiTextHandler fujiTextHandler)
    {
        this.fujiTextHandler = fujiTextHandler;
    }

    public bool HandleText(string sourceUser, string text)
    {
        bool handled = false;

        if(text.StartsWith("!pokemon ", cmp))
        {
            fujiTextHandler.Output("Hello");
            handled = true;
        }

        return handled;
    }
}