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

    public override bool[,] AllCoordinateWherCanMove(char[,] board)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((CurrentCoordinate[1] == i || CurrentCoordinate[0] == j))
                {
                    _canMove[i, j] = true;
                }
            }
        }
        CheckWay(board);
        return _canMove;
    }
    public void CheckWay(char[,] board)
    {
        var truePositions =
            from x in Enumerable.Range(0, 8)
            from y in Enumerable.Range(0, 8)
            where _canMove[x, y]
            select (x, y);
        foreach (var (x, y) in truePositions)
        {
            if (CurrentCoordinate[1] == y && CurrentCoordinate[0] == x)
                _canMove[y, x] = false;
            if (board[x, y] != ' ')
            {
                _canMove[x, y] = false;
                if (x < CurrentCoordinate[1] && y == CurrentCoordinate[0])
                {
                    for (int i = x - 1; i < x && i >= 0 && _canMove[i, y]; i--)
                    {
                        _canMove[i, y] = false;
                    }
                }
                if (x == CurrentCoordinate[1] && y < CurrentCoordinate[0])
                {
                    for (int j = y - 1; j < y && j >= 0 && _canMove[x, j]; j--)
                    {
                        _canMove[x, j] = false;
                    }
                }
                if (x > CurrentCoordinate[1] && y == CurrentCoordinate[0])
                {
                    for (int i = x + 1; i > x && i <= 7 && _canMove[i, y]; i++)
                    {
                        _canMove[i, y] = false;
                    }
                }
                if (x == CurrentCoordinate[1] && y > CurrentCoordinate[0])
                {
                    for (int j = y + 1; j > y && j <= 7 && _canMove[x, j]; j++)
                    {
                        _canMove[x, j] = false;
                    }
                }
            }
        }
    }
}