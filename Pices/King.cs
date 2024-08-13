namespace Chess;
internal class King : Pieces
{
    public override bool Move()
    {
        int x = MoveCoordinate[0] - CurrentCoordinate[0];
        int y = MoveCoordinate[1] - CurrentCoordinate[1];
        if (x >= -1 && x <= 1 && y >= -1 && y <= 1)
        {
            return true;
        }
        return false;
    }
}