namespace Chess;
internal class King : Pieces
{
    public override ChessPieces Piece => ChessPieces.King;

    public override bool Move()
    {
        int x = MoveCoordinate[0] - CurrentCoordinate[0];
        int y = MoveCoordinate[1] - CurrentCoordinate[1];
        if (x >= -1 && x <= 1 && y >= -1 && y <= 1)
            return true;
        else
            throw new Exception("You cannot move there");
    }
    public override bool CanMove(int i, int j)
    {
        int x = j - CurrentCoordinate[0];
        int y = i - CurrentCoordinate[1];
        if (x >= -1 && x <= 1 && y >= -1 && y <= 1)
            return true;
        return false;
    }

    public override bool[,] AllCoordinateWherCanMove(Board board)
    {
        throw new NotImplementedException();
    }
}