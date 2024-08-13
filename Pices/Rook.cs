namespace Chess;
internal class Rook : Pieces
{
    public override bool Move()
    {
        if (CurrentCoordinate[1] == MoveCoordinate[1] || CurrentCoordinate[0] == MoveCoordinate[0])
        {
            return true;
        }
        return false;
    }
} 