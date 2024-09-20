namespace Chess;
internal abstract class Pieces
{
    private PieceColors _color;
    public abstract ChessPieces Piece { get; }
    private Coordinates _current;
    private Coordinates _move;
    protected bool[,] _canMove = new bool[9, 9];
    public int[] CurrentCoordinate
    {
        get => _current.CoordinatesArray;
        set { _current.CoordinatesArray = [CurrentCoordinateLetter - 'a' , CurrentCoordinateNumber]; }
    }
    public char CurrentCoordinateLetter
    {
        get => _current.Letter;
        set => _current.Letter = value;
    }
    public int CurrentCoordinateNumber
    {
        get => _current.Number;
        set
        {
            _current.Number = value;
            CurrentCoordinate = [CurrentCoordinateLetter - 'a', CurrentCoordinateNumber];
        }
    }
    public PieceColors Color
    {
        get => _color;
        set
        {
            if (((char)value == 'b' || (char)value == 'w') || (value == PieceColors.White || value == PieceColors.Black))
            {
                _color = (char)value == 'b' ? (PieceColors)1 : 0;
                _color = value == PieceColors.Black? (PieceColors)1 : 0;
            }
            else
            {
                throw new ArgumentException("Error 1: Choose black or white ( b / w )");
            }
        }
    }
    //public ChessPieces PiecsChar
    //{
    //    get => _piece;
    //    set
    //    {
    //        _piece = value switch
    //        {
    //            ChessPieces.Bishop => ChessPieces.Bishop,
    //            ChessPieces.Knight => ChessPieces.Knight,
    //            ChessPieces.Rook => ChessPieces.Rook,
    //            ChessPieces.Queen => ChessPieces.Queen,
    //            ChessPieces.King => ChessPieces.King,
    //            _ => throw new ArgumentException("Error 2: There is no such a piece.\n Enter b, k, r, q or  K"),
    //        };
    //    }
    //}
    public int[] MoveCoordinate
    {
        get => _move.CoordinatesArray;
        set { }
    }
    public char MoveCoordinateLetter
    {
        get => _move.Letter;
        set => _move.Letter = value;
    }
    public int MoveCoordinateNumber
    {
        get => _move.Number;
        set
        {
            _move.Number = value;
            MoveCoordinate = [MoveCoordinateLetter - 'a' + 1, MoveCoordinateNumber];
        }
    }
    public abstract bool Move();
    public abstract bool CanMove(int i, int j);
    public abstract bool[,] AllCoordinateWherCanMove(Board board);
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
    //public char[] GetShortName() => [Color.ToString()[0], PiecsChar.ToString().ToLowerInvariant() == "king" ? 'K' : 'k'];
}