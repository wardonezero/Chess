using System.Transactions;

namespace Chess;
internal class Pieces
{
    private PiecsColor _color;
    private ChessPieces _pieces;
    private Coordinates _currentCoordinates;
    private Coordinates _moveCoordinates;
    public int[] CurrentCoordinateArray
    {
        get { return _currentCoordinates.CoordinatesArray; }
        set
        {
            _currentCoordinates.CoordinatesArray = value;
        }
    }
    public char CurrentCoordinateLetter
    {
        get { return _currentCoordinates.Letter; }
        set
        {
            _currentCoordinates.Letter = value;
        }
    }
    public int CurrentCoordinateNumber
    {
        get { return _currentCoordinates.Number; }
        set
        {
            _currentCoordinates.Number = value;
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
    public int[] MoveCoordinateArray
    {
        get { return _moveCoordinates.CoordinatesArray; }
        set
        {
            _moveCoordinates.CoordinatesArray = value;
        }
    }
    public char MoveCoordinateLetter
    {
        get { return _moveCoordinates.Letter; }
        set
        {
            _moveCoordinates.Letter = value;
        }
    }
    public int MoveCoordinateNumber
    {
        get { return _moveCoordinates.Number; }
        set
        {
            _moveCoordinates.Number = value;
        }
    }
    public virtual bool Move()
    {
        return false;
    }
}