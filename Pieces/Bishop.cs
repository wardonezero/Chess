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
                if ((x == y || x == CurrentCoordinate[1] - i) )
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
            select (x,y);
        foreach (var p in truePositions)
        {
            if (CurrentCoordinate[1] == p.y && CurrentCoordinate[0] == p.x)
                _canMove[p.y, p.x] = false;

        }
    }
}