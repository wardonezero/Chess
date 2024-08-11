namespace Chess;
internal class Queen : Pieces
{
    public override bool Move()
    {
        int x = MoveCoordinateArray[0] - CurrentCoordinateArray[0];
        int y = MoveCoordinateArray[1] - CurrentCoordinateArray[1];
        if ((x == 0 || y == 0) || (x == y) || (x == -y))
        {
            return true;
        }
        return false;
    }
}