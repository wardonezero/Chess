namespace Chess;
internal class King : Pieces
{
    public override bool Move()
    {
        int x = MoveCoordinateArray[0] - CurrentCoordinateArray[0];
        int y = MoveCoordinateArray[1] - CurrentCoordinateArray[1];
        if (x >= -1 && x <= 1 && y >= -1 && y <= 1)
        {
            return true;
        }
        return false;
    }
}