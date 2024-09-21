namespace Chess;
internal class Rook : Pieces
{
    public override ChessPieces Piece => ChessPieces.Rook;
    public override bool Move()
    {
        if (CurrentCoordinate[1] == MoveCoordinate[1] || CurrentCoordinate[0] == MoveCoordinate[0])
            return true;
        else
            throw new Exception("You cannot move there");
    }
    public override bool CanMove(int i, int j)
    {
        //int x = CurrentCoordinate[0];
        //int y = CurrentCoordinate[1];
        //if (y == i || x == j)
        //    return true;
        //return false;


        return _canMove[i, j];
    }

    public override bool[,] AllCoordinateWherCanMove(char[,] board)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((CurrentCoordinate[1] == i || CurrentCoordinate[0] == j) && board[i, j] == ' ')
                {
                    _canMove[i, j] = true;
                }
            }
        }
        return _canMove;
    }
}