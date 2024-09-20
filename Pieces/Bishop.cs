namespace Chess;
internal class Bishop : Pieces
{
    public override ChessPieces Piece => ChessPieces.Bishop;

    public override bool Move()
    {
        int x = MoveCoordinate[0] - CurrentCoordinate[0];
        int y = MoveCoordinate[1] - CurrentCoordinate[1];
        if (x == y || x == CurrentCoordinate[1] - MoveCoordinate[1])
            return true;
        else
            throw new Exception("You cannot move there");
    }
    public override bool CanMove(int i, int j)
    {
        //int x = j - CurrentCoordinate[0];
        //int y = i - CurrentCoordinate[1];
        //if (x == y || x == CurrentCoordinate[1] - i)
        //    return true;
        //return false;

        return _canMove[i, j];
    }

    public override bool[,] AllCoordinateWherCanMove(Board board)
    {
        int x;
        int y;
        for (int i = 1; i <= 8; i++)
        {
            y = i - CurrentCoordinate[1];
            for (int j = 1; j <= 8; j++)
            {
                x = j - CurrentCoordinate[0];
                if ((x == y || x == CurrentCoordinate[1] - i) && board.board[i, j] == ' ')
                {
                    _canMove[i, j] = true;
                }
                else
                {
                    continue;
                }

            }
        }
        return _canMove;
    }
}