namespace Chess;
internal class Knight : Pieces
{
    public override bool Move()
    {
        int x = MoveCoordinateArray[0] - CurrentCoordinateArray[0];
        int y = MoveCoordinateArray[1] - CurrentCoordinateArray[1];
        if ((x == 2 || x == -2) && (y == 1 || y == -1) || (x == 1 || x == -1) && (y == 2 || y == -2))
        {
            return true;
        }
        return false;
    }
}
}