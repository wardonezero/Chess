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
        foreach (var p in truePositions)
        {
            if (CurrentCoordinate[1] == p.y && CurrentCoordinate[0] == p.x)
                _canMove[p.y, p.x] = false;
            if (board[p.x, p.y] != ' ')
            {
                _canMove[p.x, p.y] = false;
                if (p.x < CurrentCoordinate[1] && p.y == CurrentCoordinate[0])
                {
                    for (int i = p.x - 1; i < p.x && i >= 0 && _canMove[i, p.y]; i--)
                    {
                        _canMove[i, p.y] = false;
                    }
                }
                if (p.x == CurrentCoordinate[1] && p.y < CurrentCoordinate[0])
                {
                    for (int j = p.y - 1; j < p.y && j >= 0 && _canMove[p.x, j]; j--)
                    {
                        _canMove[p.x, j] = false;
                    }
                }
                if (p.x > CurrentCoordinate[1] && p.y == CurrentCoordinate[0])
                {
                    for (int i = p.x + 1; i > p.x && i <= 7 && _canMove[i, p.y]; i++)
                    {
                        _canMove[i, p.y] = false;
                    }
                }
                if (p.x == CurrentCoordinate[1] && p.y > CurrentCoordinate[0])
                {
                    for (int j = p.y + 1; j > p.y && j <= 7 && _canMove[p.x, j]; j++)
                    {
                        _canMove[p.x, j] = false;
                    }
                }
            }
        }
    }
}