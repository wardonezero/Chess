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
                if ((x >= -1 && x <= 1 && y >= -1 && y <= 1) && board[i, j] == ' ')
                {
                    _canMove[i, j] = true;
                }

            }
        }
        //CheckWay(board);
        return _canMove;
    }
}