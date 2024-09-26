using static Chess.ChessAlgoritms;
using static Chess.Pieces;
namespace Chess;
internal class Board
{
    public char[,] board = new char[8, 8];
    private Pieces[] pieces = new Pieces[16];
    public int playingPieceID;
    int AIPieceID = 8;
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
            pieces[i].CleanCanMove();
        }
        return board;
    }
    private Pieces[] DefaultBoardPieces()
    {
        pieces[0] = new Rook
        {
            Color = PlayerColor,
            CurrentLetter = 'a',
            CurrentNumber = 49,
            CurrentCoordinate = ['a' - 'a', 56 - 49]
        };

        pieces[1] = new Knight
        {
            Color = PlayerColor,
            CurrentLetter = 'b',
            CurrentNumber = 49,
            CurrentCoordinate = ['b' - 'a', 56 - 49]
        };

        pieces[2] = new Bishop
        {
            Color = PlayerColor,
            CurrentLetter = 'c',
            CurrentNumber = 49,
            CurrentCoordinate = ['c' - 'a', 56 - 49]
        };

        pieces[3] = new Queen
        {
            Color = PlayerColor,
            CurrentLetter = 'd',
            CurrentNumber = 49,
            CurrentCoordinate = ['d' - 'a', 56 - 49]
        };

        pieces[4] = new King
        {
            Color = PlayerColor,
            CurrentLetter = 'e',
            CurrentNumber = 49,
            CurrentCoordinate = ['e' - 'a', 56 - 49]
        };

        pieces[5] = new Bishop
        {
            Color = PlayerColor,
            CurrentLetter = 'f',
            CurrentNumber = 49,
            CurrentCoordinate = ['f' - 'a', 56 - 49]
        };

        pieces[6] = new Knight
        {
            Color = PlayerColor,
            CurrentLetter = 'g',
            CurrentNumber = 49,
            CurrentCoordinate = ['g' - 'a', 56 - 49]
        };

        pieces[7] = new Rook
        {
            Color = PlayerColor,
            CurrentLetter = 'h',
            CurrentNumber = 49,
            CurrentCoordinate = ['h' - 'a', 56 - 49]
        };

        pieces[8] = new Rook
        {
            Color = PlayerColor == PieceColors.Black ? PieceColors.White : PieceColors.Black,
            CurrentLetter = 'a',
            CurrentNumber = 56,
            CurrentCoordinate = ['a' - 'a', 56 - 56]
        };

        pieces[9] = new Knight
        {
            Color = PlayerColor == PieceColors.Black ? PieceColors.White : PieceColors.Black,
            CurrentLetter = 'b',
            CurrentNumber = 56,
            CurrentCoordinate = ['b' - 'a', 56 - 56]
        };

        pieces[10] = new Bishop
        {
            Color = PlayerColor == PieceColors.Black ? PieceColors.White : PieceColors.Black,
            CurrentLetter = 'c',
            CurrentNumber = 56,
            CurrentCoordinate = ['c' - 'a', 56 - 56]
        };

        pieces[11] = new Queen
        {
            Color = PlayerColor == PieceColors.Black ? PieceColors.White : PieceColors.Black,
            CurrentLetter = 'd',
            CurrentNumber = 56,
            CurrentCoordinate = ['d' - 'a', 56 - 56]
        };

        pieces[12] = new King
        {
            Color = PlayerColor == PieceColors.Black ? PieceColors.White : PieceColors.Black,
            CurrentLetter = 'e',
            CurrentNumber = 56,
            CurrentCoordinate = ['e' - 'a', 56 - 56]
        };

        pieces[13] = new Bishop
        {
            Color = PlayerColor == PieceColors.Black ? PieceColors.White : PieceColors.Black,
            CurrentLetter = 'f',
            CurrentNumber = 56,
            CurrentCoordinate = ['f' - 'a', 56 - 56]
        };

        pieces[14] = new Knight
        {
            Color = PlayerColor == PieceColors.Black ? PieceColors.White : PieceColors.Black,
            CurrentLetter = 'g',
            CurrentNumber = 56,
            CurrentCoordinate = ['g' - 'a', 56 - 56]
        };

        pieces[15] = new Rook
        {
            Color = PlayerColor == PieceColors.Black ? PieceColors.White : PieceColors.Black,
            CurrentLetter = 'h',
            CurrentNumber = 56,
            CurrentCoordinate = ['h' - 'a', 56 - 56]
        };
        return pieces;
    }
    public bool ChoosePiece(Coordinates c)
    {
        for (int i = 0; i < 16; i++)
        {
            if (c.CoordinatesArray[0] == pieces[i].CurrentCoordinate[0] && c.CoordinatesArray[1] == pieces[i].CurrentCoordinate[1] && PlayerColor == pieces[i].Color)
            {
                playingPieceID = i;
                pieces[playingPieceID].CleanCanMove();
                pieces[playingPieceID].AllCoordinateWherCanMove(board);
                return true;
            }
        }
        throw new ArgumentException("Coorinate or empty or wrong");
    }

    public Pieces MovePiece(char l, byte n)
    {
        pieces[playingPieceID].MoveLetter = l;
        pieces[playingPieceID].MoveNumber = n;
        pieces[playingPieceID].MoveCoordinate = [(byte)(pieces[playingPieceID].MoveLetter - 'a'), pieces[playingPieceID].MoveNumber];
        if (pieces[playingPieceID].CanMove([pieces[playingPieceID].MoveCoordinate[1], pieces[playingPieceID].MoveCoordinate[0]]))
        {
            board[pieces[playingPieceID].CurrentCoordinate[1], pieces[playingPieceID].CurrentCoordinate[0]] = ' ';
            pieces[playingPieceID].CurrentLetter = pieces[playingPieceID].MoveLetter;
            pieces[playingPieceID].CurrentNumber = (byte)(48 + pieces[playingPieceID].MoveNumber);
            pieces[playingPieceID].CurrentCoordinate = pieces[playingPieceID].MoveCoordinate;
            board[pieces[playingPieceID].CurrentCoordinate[1], pieces[playingPieceID].CurrentCoordinate[0]] = GetPieceSymbol(pieces[playingPieceID]);
            pieces[playingPieceID].CleanCanMove();
            //pieces[playingPieceID].AllCoordinateWherCanMove(board);
            return pieces[playingPieceID];
        }
        throw new ArgumentException("You cannot move there");
    }

    /*public void PutPieceInBoard(char charPiece, Pieces piece)
    {
        if (BoardChack(piece))
        board[piece.CurrentCoordinate[1], piece.CurrentCoordinate[0]] = charPiece;
    }*/

    //public void RandomPicesInBoard(byte p = 8)//DO NOT TOUCH
    //{
    //    if (p > 16) throw new Exception("The board can't containt more than 32 pieces");
    //    Random random = new();
    //    char randomLetter;
    //    byte randomNumber;
    //    for (int i = 0; i < 8; i++)
    //    {
    //        board[0, i] = ' ';
    //    }
    //    for (byte i = 0; i < p; i++)
    //    {
    //        AIPieceID = 8 + i;
    //        do
    //        {
    //            randomLetter = (char)random.Next('a', 'i');
    //            randomNumber = (byte)random.Next(50, 56);

    //            board[pieces[AIPieceID].CurrentCoordinate[1], pieces[AIPieceID].CurrentCoordinate[0]] = ' ';
    //            pieces[AIPieceID].CurrentLetter = randomLetter;
    //            pieces[AIPieceID].CurrentNumber = randomNumber;
    //            pieces[AIPieceID].CurrentCoordinate = [(byte)(randomLetter - 'a'), (byte)(56 - randomNumber)];
    //        }
    //        while (!BoardChack(pieces[AIPieceID]));
    //        if (BoardChack(pieces[AIPieceID]))
    //            board[pieces[AIPieceID].CurrentCoordinate[1], pieces[AIPieceID].CurrentCoordinate[0]] = GetPieceSymbol(pieces[AIPieceID]);
    //    }
    //}
    public void RandomPicesInBoard(byte p = 16)
    {
        if (p > 16) throw new Exception("The board can't containt more than 32 pieces");
        Random random = new();
        char randomLetter;
        byte randomNumber;
        EmptyBoard();
        for (byte i = 0; i < p; i++)
        {
            AIPieceID = i;
            do
            {
                randomLetter = (char)random.Next('a', 'i');
                randomNumber = (byte)random.Next(49, 57);
                
                pieces[AIPieceID].CurrentLetter = randomLetter;
                pieces[AIPieceID].CurrentNumber = randomNumber;
                pieces[AIPieceID].CurrentCoordinate = [(byte)(randomLetter - 'a'), (byte)(56 - randomNumber)];
            }
            while (!BoardChack(pieces[AIPieceID]));
            if (BoardChack(pieces[AIPieceID]))
                board[pieces[AIPieceID].CurrentCoordinate[1], pieces[AIPieceID].CurrentCoordinate[0]] = GetPieceSymbol(pieces[AIPieceID]);
        }
    }
    private bool BoardChack(Pieces piece)
    {
        byte pieceIndex;
        byte[] eachPiece = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
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
        if (eachPiece[pieceIndex] < 2 && 
            piece.Piece != ChessPieces.King && 
            piece.Piece != ChessPieces.Queen && 
            board[piece.CurrentCoordinate[1], piece.CurrentCoordinate[0]] == ' ')
            return true;
        else if (eachPiece[pieceIndex] < 1 && 
            (piece.Piece == ChessPieces.King || piece.Piece == ChessPieces.Queen) && 
            board[piece.CurrentCoordinate[1], piece.CurrentCoordinate[0]] == ' ')
            return true;
        else return false;
    }
    public Pieces GetPiece() => pieces[playingPieceID];
}