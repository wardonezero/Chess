namespace Chess;
internal class Rook : Pieces
{
    public override bool Move()
    {
        if (CurrentCoordinate[1] == MoveCoordinate[1] || CurrentCoordinate[0] == MoveCoordinate[0])
            return true;
        else
            throw new Exception("You cannot move there");
    }
    public override bool CanMove(int i, int j)
    {
        int x = CurrentCoordinate[0];
        int y = CurrentCoordinate[1];
        if (y == i || x == j)
            return true;
        return false;
    }
}