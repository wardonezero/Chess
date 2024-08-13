using System.Transactions;

namespace Chess;
internal class Pieces
{
    private PiecsColor _color;
    private static ChessPieces _pieces;
    private Coordinates _current;
    private Coordinates _move;
    public int[] CurrentCoordinate
    {
        get { return _current.CoordinatesArray; }
        set
        {
            _current.CoordinatesArray = value;
        }
    }
    public char CurrentCoordinateLetter
    {
        get { return _current.Letter; }
        set
        {
            _current.Letter = value;
        }
    }
    public int CurrentCoordinateNumber
    {
        get { return _current.Number; }
        set
        {
            _current.Number = value;
        }
    }
    public PiecsColor Color
    {
        get { return _color; }
        set
        {
            if ((char)value == 'b' || (char)value == 'w')
            {
                _color = (char)value == 'b' ? (PiecsColor)1 : 0;
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
    public int[] MoveCoordinate
    {
        get { return _move.CoordinatesArray; }
        set
        {
            _move.CoordinatesArray = value;
        }
    }
    public char MoveCoordinateLetter
    {
        get { return _move.Letter; }
        set
        {
            _move.Letter = value;
        }
    }
    public int MoveCoordinateNumber
    {
        get { return _move.Number; }
        set
        {
            _move.Number = value;
        }
    }
    public virtual bool Move()
    {
        return false;
    }
}