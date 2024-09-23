namespace Chess;
internal abstract class Pieces
{
    public abstract ChessPieces Piece { get; }
    private PieceColors _color;
    private Coordinates _current;
    private Coordinates _move;
    protected bool[,] _canMove = new bool[8, 8];
    public PieceColors Color
    {
        get => _color;
        set
        {
            if ((value == PieceColors.White || value == PieceColors.Black))
                _color = value;
            else
                throw new ArgumentException("Error 1: Choose black or white ( b / w )");
        }
    }
    public char CurrentLetter
    {
        get => _current.Letter;
        set => _current.Letter = value;
    }
    public byte CurrentNumber
    {
        get => _current.Number;
        set => _current.Number = value;
    }
    public byte[] CurrentCoordinate
    {
        get => _current.CoordinatesArray;
        set => _current.CoordinatesArray = value;
    }
    public char MoveLetter
    {
        get => _move.Letter;
        set => _move.Letter = value;
    }
    public byte MoveNumber
    {
        get => _move.Number;
        set => _move.Number = value;
    }
    public byte[] MoveCoordinate
    {
        get => _move.CoordinatesArray;
        set => _move.CoordinatesArray = value;
    }
    public abstract bool Move();
    public bool CanMove(byte[] ij) => _canMove[ij[0], ij[1]];
    public abstract bool[,] AllCoordinateWherCanMove(char[,] board);
    public bool[,] CleanCanMove()
    {
        Array.Clear(_canMove, 0, _canMove.Length);
        return _canMove;
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