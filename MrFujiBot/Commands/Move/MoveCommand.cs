internal class MoveCommand : Command, ITextHandler
{
    private MoveFactory moveFactory;

    public MoveCommand(MoveFactory moveFactory)
    {
        this.moveFactory = moveFactory;
    }

    public bool HandleText(string sourceUser, string text, System.Action<string> outputFunction)
    {
        bool handled = false;

        if (text.StartsWith("!move ", cmp))
        {
            string output = "";
            string name = text.Split(' ')[1];
            Move move = moveFactory.getMove(name);

            if (null != move)
            {
                output += move.Name + ": ";
            }
            else
            {
                output = "Could not find Move '" + name + "'";
            }

            outputFunction(output);

            handled = true;
        }

        return handled;
    }
}