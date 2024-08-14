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
        set { _current.CoordinatesArray = value; }
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
            CurrentCoordinate = [CurrentCoordinateLetter - 'a' + 1, CurrentCoordinateNumber];
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
            switch (value)
            {
                case ChessPieces.Bishop:
                    _pieces = ChessPieces.Bishop;
                    break;
                case ChessPieces.Knight:
                    _pieces = ChessPieces.Knight;
                    break;
                case ChessPieces.Rook:
                    _pieces = ChessPieces.Rook;
                    break;
                case ChessPieces.Queen:
                    _pieces = ChessPieces.Queen;
                    break;
                case ChessPieces.King:
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
        set { 
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
            MoveCoordinate = [MoveCoordinateLetter - 'a' + 1, MoveCoordinateNumber];
        }
    }
    public virtual bool Move()
    {
        return false;
    }
    public static Pieces Create(char f)
    {
        return f switch
        {
            'b' => new Bishop(),
            'K' => new King(),
            'k' => new Knight(),
            'q' => new Queen(),
            'r' => new Rook(),
            _ => throw new ArgumentException("There is no such piece")
        };
    }
}