namespace Chess;
internal class Rook : Pieces
{
    public override bool Move()
    {
        if (CurrentCoordinateArray[1] == MoveCoordinateArray[1] || CurrentCoordinateArray[0] == MoveCoordinateArray[0])
        {
            return true;
        }
        return false;
    }
} 