namespace Chess;
internal class Pieces
{
    private PicesColor _color;
    private ChessPieces _pieces;
    public Coordinates coord;
    public PicesColor Color
    {
        get { return _color; }
        set
        {
            if ((char)value == 'b' || (char)value == 'w')
            {
                _color = (char)value == 'b' ? (PicesColor)1 : 0;
            }
            else
            {
                throw new ArgumentException("Error 1: Choose black or white ( b / w )");
            }
        }
    }
    public ChessPieces PiecsChar
    {
        get { return _pieces; }
        set
        {
            switch ((char)value)
            {
                case 'b':
                    _pieces = ChessPieces.Bishop;
                    break;
                case 'k':
                    _pieces = ChessPieces.Knight;
                    break;
                case 'r':
                    _pieces = ChessPieces.Rook;
                    break;
                case 'q':
                    _pieces = ChessPieces.Queen;
                    break;
                case 'K':
                    _pieces = ChessPieces.King;
                    break;
                default:
                    throw new ArgumentException("Error 2: There is no such a piece.\n Enter b, k, r, q or  K");
            }
        }
    }
}