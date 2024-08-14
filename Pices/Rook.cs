namespace Chess;
internal class Rook : Pieces
{
    public override bool Move()
    {
        if (CurrentCoordinate[1] == MoveCoordinate[1] || CurrentCoordinate[0] == MoveCoordinate[0])
        {
            return true;
        }
        else
        {
            throw new Exception("You cannot move there");
        }
        return false;
    }
} 