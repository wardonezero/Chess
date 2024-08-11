namespace Chess;
internal class Bishop : Pieces
{
    public override bool Move()
    {
        if (MoveCoordinateArray[0] - CurrentCoordinateArray[0] == MoveCoordinateArray[1] - CurrentCoordinateArray[1] || MoveCoordinateArray[0] - CurrentCoordinateArray[0] == CurrentCoordinateArray[1] - MoveCoordinateArray[1])
        {
            return true;
        }
        return false;
    }
}