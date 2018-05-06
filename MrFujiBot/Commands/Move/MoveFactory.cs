using MrFujiBot;

internal class MoveFactory
{
    private FujiDatabase database;

    public MoveFactory(FujiDatabase database)
    {
        this.database = database;
    }

    public Move getMove(string name)
    {
        Move move = new Move();

        return move;
    }
}