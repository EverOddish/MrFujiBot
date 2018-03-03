using System;

internal class Command
{
    protected StringComparison cmp;

    public Command()
    {
        cmp = StringComparison.InvariantCultureIgnoreCase;
    }
}