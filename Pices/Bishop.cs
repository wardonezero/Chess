namespace Chess;
internal class Bishop : Pieces
{
    public override bool Move()
    {
        int x = MoveCoordinate[0] - CurrentCoordinate[0];
        int y = MoveCoordinate[1] - CurrentCoordinate[1];
        if (x == y || x == CurrentCoordinate[1] - MoveCoordinate[1])
            return true;
        else
            throw new Exception("You cannot move there");
    }
    public override bool CanMove(int i, int j)
    {
        int x = j - CurrentCoordinate[0];
        int y = i - CurrentCoordinate[1];
        if (x == y || x == CurrentCoordinate[1] - i)
            return true;
        return false;
    }
}