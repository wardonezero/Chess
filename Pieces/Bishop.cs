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
                if ((x == y || x == CurrentCoordinate[1] - i))
                    _canMove[i, j] = true;
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
                if (p.x < CurrentCoordinate[1] && p.y > CurrentCoordinate[0])
                {
                    for (int i = p.x - 1, j = p.y + 1; i < p.x && j > p.y && i >= 0 && j <= 7 && _canMove[i, j]; i--, j++)
                    {
                        _canMove[i, j] = false;
                    }
                }
                if (p.x < CurrentCoordinate[1] && p.y < CurrentCoordinate[0])
                {
                    for (int i = p.x - 1, j = p.y - 1; i < p.x && j < p.y && i >= 0 && j >= 0 && _canMove[i, j]; i--, j--)
                    {
                        _canMove[i, j] = false;
                    }
                }
                if (p.x > CurrentCoordinate[1] && p.y > CurrentCoordinate[0])
                {
                    for (int i = p.x + 1, j = p.y + 1; i > p.x && j > p.y && i <= 7 && j <= 7 && _canMove[i, j]; i++, j++)
                    {
                        _canMove[i, j] = false;
                    }
                }
                if (p.x > CurrentCoordinate[1] && p.y < CurrentCoordinate[0])
                {
                    for (int i = p.x + 1, j = p.y - 1; i > p.x && j < p.y && i <= 7 && j <= 0 && _canMove[i, j]; i++, j--)
                    {
                        _canMove[i, j] = false;
                    }
                }
            }
        }
    }
}