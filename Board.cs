using static Chess.ChessAlgoritms;
using static Chess.Pieces;
namespace Chess;
internal class Board
{
    public char[,] board = new char[8, 8];
    private Pieces[] pieces = new Pieces[16];
    int[] eachPiece = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    int playingPieceID;

    public PieceColors PlayerColor { get; set; }

    public char[,] EmptyBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board[i, j] = ' ';
            }
        }
        return board;
    }
    public char[,] DefaultBoard()
    {
        DefaultBoardPieces();
        for (int i = 0; i < 16; i++)
        {
            board[pieces[i].CurrentCoordinate[1], pieces[i].CurrentCoordinate[0]] = GetPieceSymbol(pieces[i]);
        }
        return board;
    }
    private Pieces[] DefaultBoardPieces()
    {
        pieces[0] = new Rook();
        pieces[0].Color = PieceColors.White;
        pieces[0].CurrentCoordinateLetter = 'a';
        pieces[0].CurrentCoordinateNumber = 49;


        pieces[1] = new Knight();
        pieces[1].Color = PieceColors.White;
        pieces[1].CurrentCoordinateLetter = 'b';
        pieces[1].CurrentCoordinateNumber = 49;

        pieces[2] = new Bishop();
        pieces[2].Color = PieceColors.White;
        pieces[2].CurrentCoordinateLetter = 'c';
        pieces[2].CurrentCoordinateNumber = 49;

        pieces[3] = new Queen();
        pieces[3].Color = PieceColors.White;
        pieces[3].CurrentCoordinateLetter = 'd';
        pieces[3].CurrentCoordinateNumber = 49;

        pieces[4] = new King();
        pieces[4].Color = PieceColors.White;
        pieces[4].CurrentCoordinateLetter = 'e';
        pieces[4].CurrentCoordinateNumber = 49;

        pieces[5] = new Bishop();
        pieces[5].Color = PieceColors.White;
        pieces[5].CurrentCoordinateLetter = 'f';
        pieces[5].CurrentCoordinateNumber = 49;

        pieces[6] = new Knight();
        pieces[6].Color = PieceColors.White;
        pieces[6].CurrentCoordinateLetter = 'g';
        pieces[6].CurrentCoordinateNumber = 49;

        pieces[7] = new Rook();
        pieces[7].Color = PieceColors.White;
        pieces[7].CurrentCoordinateLetter = 'h';
        pieces[7].CurrentCoordinateNumber = 49;

        pieces[8] = new Rook();
        pieces[8].Color = PieceColors.Black;
        pieces[8].CurrentCoordinateLetter = 'a';
        pieces[8].CurrentCoordinateNumber = 56;

        pieces[9] = new Knight();
        pieces[9].Color = PieceColors.Black;
        pieces[9].CurrentCoordinateLetter = 'b';
        pieces[9].CurrentCoordinateNumber = 56;

        pieces[10] = new Bishop();
        pieces[10].Color = PieceColors.Black;
        pieces[10].CurrentCoordinateLetter = 'c';
        pieces[10].CurrentCoordinateNumber = 56;

        pieces[11] = new Queen();
        pieces[11].Color = PieceColors.Black;
        pieces[11].CurrentCoordinateLetter = 'd';
        pieces[11].CurrentCoordinateNumber = 56;

        pieces[12] = new King();
        pieces[12].Color = PieceColors.Black;
        pieces[12].CurrentCoordinateLetter = 'e';
        pieces[12].CurrentCoordinateNumber = 56;

        pieces[13] = new Bishop();
        pieces[13].Color = PieceColors.Black;
        pieces[13].CurrentCoordinateLetter = 'f';
        pieces[13].CurrentCoordinateNumber = 56;

        pieces[14] = new Knight();
        pieces[14].Color = PieceColors.Black;
        pieces[14].CurrentCoordinateLetter = 'g';
        pieces[14].CurrentCoordinateNumber = 56;

        pieces[15] = new Rook();
        pieces[15].Color = PieceColors.Black;
        pieces[15].CurrentCoordinateLetter = 'h';
        pieces[15].CurrentCoordinateNumber = 56;
        return pieces;
    }

    public bool ChoosePiece(Coordinates c)
    {
        for (int i = 0; i < 16; i++)
        {
            if (c.CoordinatesArray[0] == pieces[i].CurrentCoordinate[0] && c.CoordinatesArray[1] == pieces[i].CurrentCoordinate[1] && PlayerColor == pieces[i].Color)
            {
                playingPieceID = i;
                return true;
            }
        }
        throw new ArgumentException ("Coorinate or empty or wrong");
    }

    public Pieces MovePiece(char l, int n)
    {
        pieces[playingPieceID].MoveCoordinateLetter = l;
        pieces[playingPieceID].MoveCoordinateNumber = n;
        pieces[playingPieceID].MoveCoordinate = [l - 'a', n];
        if (pieces[playingPieceID].Move())
        {
            board[pieces[playingPieceID].CurrentCoordinate[1], pieces[playingPieceID].CurrentCoordinate[0]] = ' ';
            pieces[playingPieceID].CurrentCoordinateLetter = l;
            pieces[playingPieceID].CurrentCoordinateNumber = n;
            pieces[playingPieceID].CurrentCoordinate = pieces[playingPieceID].MoveCoordinate;
            board[pieces[playingPieceID].CurrentCoordinate[1], pieces[playingPieceID].CurrentCoordinate[0]] = GetPieceSymbol(pieces[playingPieceID]);
            return pieces[playingPieceID];
        }
        throw new ArgumentException("Somthing went wrong");
    }

    /*public void PutPieceInBoard(char charPiece, Pieces piece)
    {
        if (BoardChack(piece))
        board[piece.CurrentCoordinate[1], piece.CurrentCoordinate[0]] = charPiece;
    }*/

    /*public void RandomPicesInBoard(byte p = 1)
    {
        if (p > 31) throw new Exception("The board can't containt more than 32 pieces");
        Random random = new();
        Pieces randomPiece;
        char randomColor;
        char randomLetter;
        int randomNumber;
        char[] chars = { 'b', 'k', 'r', 'q', 'K' };
        char randomChar;
        for (byte i = 0; i < p; i++)
        {
            do
            {
                randomLetter = (char)random.Next('a', 'i');
                randomNumber = random.Next(49, 56);
                randomColor = random.Next(2) == 0 ? 'b' : 'w';
                randomChar = chars[random.Next(chars.Length)];
                randomPiece = Create(randomChar);
                randomPiece.PiecsChar = (ChessPieces)Enum.Parse(typeof(ChessPieces), randomPiece.GetType().Name);
                randomPiece.Color = (PieceColors)randomColor;
                randomPiece.CurrentCoordinateLetter = randomLetter;
                randomPiece.CurrentCoordinateNumber = randomNumber;
            }
            while (!BoardChack(randomPiece));

            PutPieceInBoard(GetPieceSymbol(randomPiece), randomPiece);
        }
    }*/

    public bool BoardChack(Pieces piece)
    {
        int pieceIndex = 0;
        eachPiece = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                //if (shortName[0] == 'B' && shortName[1] == 'b') eachPiece[0]++;
                //if (eachPiece[0] <= 2) return true;
                switch (board[i, j])
                {
                    case '♗'://white
                        eachPiece[2]++;
                        break;
                    case '♘'://white
                        eachPiece[4]++;
                        break;
                    case '♖'://white
                        eachPiece[6]++;
                        break;
                    case '♕'://white
                        eachPiece[8]++;
                        break;
                    case '♔'://white
                        eachPiece[10]++;
                        break;
                    case '♝'://black
                        eachPiece[3]++;
                        break;
                    case '♞'://black
                        eachPiece[5]++;
                        break;
                    case '♜'://black
                        eachPiece[7]++;
                        break;
                    case '♛'://black
                        eachPiece[9]++;
                        break;
                    case '♚'://black
                        eachPiece[11]++;
                        break;
                    default:
                        break;
                }
            }
        }
        pieceIndex = piece.Color switch
        {
            PieceColors.White when piece.Piece == ChessPieces.Bishop => 2,
            PieceColors.White when piece.Piece == ChessPieces.Knight => 4,
            PieceColors.White when piece.Piece == ChessPieces.Rook => 6,
            PieceColors.White when piece.Piece == ChessPieces.Queen => 8,
            PieceColors.White when piece.Piece == ChessPieces.King => 10,
            PieceColors.Black when piece.Piece == ChessPieces.Bishop => 3,
            PieceColors.Black when piece.Piece == ChessPieces.Knight => 5,
            PieceColors.Black when piece.Piece == ChessPieces.Rook => 7,
            PieceColors.Black when piece.Piece == ChessPieces.Queen => 9,
            PieceColors.Black when piece.Piece == ChessPieces.King => 11,
            _ => throw new Exception("Error in pieceIndex Board.cs"),
        };
        if (eachPiece[pieceIndex] < 2 && piece.Piece != ChessPieces.King && piece.Piece != ChessPieces.Queen && board[piece.CurrentCoordinate[1], piece.CurrentCoordinate[0]] == ' ')
            return true;
        else if (eachPiece[pieceIndex] < 1 && (piece.Piece == ChessPieces.King || piece.Piece == ChessPieces.Queen) && board[piece.CurrentCoordinate[1], piece.CurrentCoordinate[0]] == ' ')
            return true;
        else return false;
    }

    public Pieces GetPiece() => pieces[playingPieceID];
}