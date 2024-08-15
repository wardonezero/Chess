namespace Chess;
internal class Knight : Pieces
{
    public override bool Move()
    {
        int x = MoveCoordinate[0] - CurrentCoordinate[0];
        int y = MoveCoordinate[1] - CurrentCoordinate[1];
        if ((x == 2 || x == -2) && (y == 1 || y == -1) || (x == 1 || x == -1) && (y == 2 || y == -2))
            return true;
        else
            throw new Exception("You cannot move there");
    }
}