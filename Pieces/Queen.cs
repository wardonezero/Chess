namespace Chess;
internal class Queen : Pieces
{
    public override ChessPieces Piece => ChessPieces.Queen;
    public override bool Move()
    {
        int x = MoveCoordinate[0] - CurrentCoordinate[0];
        int y = MoveCoordinate[1] - CurrentCoordinate[1];
        if ((x == 0 || y == 0) || (x == y || x == -y))
            return true;
        else
            throw new Exception("You cannot move there");
    }
    public override bool CanMove(int i, int j)
    {
        //int x = j - CurrentCoordinate[0];
        //int y = i - CurrentCoordinate[1];
        //if ((x == 0 || y == 0) || (x == y || x == -y))
        //    return true;
        //return false;


        return _canMove[i, j];
    }

    public override bool[,] AllCoordinateWherCanMove(char[,] board)
    {
        int x;
        int y;
        for (int i = 0; i < 8; i++)
        {
            y = i - CurrentCoordinate[1];
            for (int j = 0; j < 8; j++)
            {
                x = j - CurrentCoordinate[0];
                if (((x == 0 || y == 0) || (x == y || x == -y)) && board[i, j] == ' ')
                {
                    _canMove[i, j] = true;
                }

            }
        }
        return _canMove;
    }
}