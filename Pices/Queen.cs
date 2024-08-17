namespace Chess;
internal class Queen : Pieces
{
    public override bool Move()
    {
        int x = MoveCoordinate[0] - CurrentCoordinate[0];
        int y = MoveCoordinate[1] - CurrentCoordinate[1];
        if ((x == 0 || y == 0) || (x == y || x == -y))
            return true;
        else
            throw new Exception("You cannot move there");
    }
    public override bool CanMove(int i, int j)
    {
        int x = j - CurrentCoordinate[0];
        int y = i - CurrentCoordinate[1];
        if ((x == 0 || y == 0) || (x == y || x == -y))
            return true;
        return false;
    }
}