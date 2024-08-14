namespace Chess;
internal class Bishop : Pieces
{
    public override bool Move()
    {
        if ((MoveCoordinate[0] - CurrentCoordinate[0] == MoveCoordinate[1] - CurrentCoordinate[1]) || (MoveCoordinate[0] - CurrentCoordinate[0] == CurrentCoordinate[1] - MoveCoordinate[1]))
        {
            return true;
        }
        else
        {
            throw new Exception("You cannot move there");
        }
    }
}