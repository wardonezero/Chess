using System.Text;
using static System.Console;
namespace Homework;
internal class Chess
{
    public static void Movement()
    {
        OutputEncoding = Encoding.UTF8;
        ChessSides side = new();
        ChessPieces piece = new();
        char playerSide;
        char playerPiece;
        while (true)
        {
            Write("Choose White or Black side: ");
            playerSide = ReadKey().KeyChar;
            if (playerSide == 'b' || playerSide == 'w')
            {
                side = playerSide == 'b' ? (ChessSides)1 : 0;
                break;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nError 1: Choose black or white ( b / w )");
                ForegroundColor = ConsoleColor.Gray;
            }
        }
        while (true)
        {
            Write("\nChoose your chess piece.\nBishop  Knight  Rook  Queen  King: ");
            playerPiece = ReadKey().KeyChar;
            switch (playerPiece)
            {
                case 'b':
                    piece = ChessPieces.Bishop;
                    break;
                case 'k':
                    piece = ChessPieces.Knight;
                    break;
                case 'r':
                    piece = ChessPieces.Rook;
                    break;
                case 'q':
                    piece = ChessPieces.Queen;
                    break;
                case 'K':
                    piece = ChessPieces.King;
                    break;
                default:
                    ForegroundColor = ConsoleColor.Red;
                    Write("\nError 2: There is no such a piece.\n Enter b, k, r, q or  K");
                    ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            if (piece != 0)
                break;
        }
        Coordinates playercoordinates = new();
        WriteLine();
        char playPiece = GetPieceSymbol(side, piece);
        char[,] board = FillChessBoard(playPiece, playercoordinates);
        DisplayChessBoard(board);
    }
    private static void DisplayChessBoard(char[,] board)
    {
        for (int i = 0; i <= 8; i++)
        {
            for (int j = 0; j <= 8; j++)
            {
                if (i == 0 || j == 0)
                {
                    BackgroundColor = ConsoleColor.Black;
                    ForegroundColor = ConsoleColor.Gray;
                }
                else if ((i + j) % 2 == 0)
                {
                    BackgroundColor = ConsoleColor.White;
                    ForegroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    BackgroundColor = ConsoleColor.Black;
                    ForegroundColor = ConsoleColor.DarkGray;
                }
                Write($" {board[i, j]} ");
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.Gray;
            }
            WriteLine();
        }
    }
    private static char[,] FillChessBoard(char playPiece, Coordinates coordinates)
    {
        char[,] board = new char[9, 9];
        for (int i = 0; i <= 8; i++)
        {
            for (int j = 0; j <= 8; j++)
            {
                if (i == 0)
                    board[i, j] = j == 0 ? ' ' : (char)('@' + j);
                else if (j == 0)
                    board[i, j] = (char)('9' - i);
                else
                    board[i, j] = ' ';
            }
        }
        board[9 - coordinates.row, coordinates.column] = playPiece;
        return board;
    }
    private static char GetPieceSymbol(ChessSides side, ChessPieces piece)
    {
        switch (side)
        {
            case ChessSides.White:
                switch (piece)
                {
                    case ChessPieces.Bishop:
                        return '♗';
                    case ChessPieces.Knight:
                        return '♘';
                    case ChessPieces.Rook:
                        return '♖';
                    case ChessPieces.Queen:
                        return '♕';
                    case ChessPieces.King:
                        return '♔';
                    default:
                        return '♙';
                }
            case ChessSides.Black:
                switch (piece)
                {
                    case ChessPieces.Bishop:
                        return '♝';
                    case ChessPieces.Knight:
                        return '♞';
                    case ChessPieces.Rook:
                        return '♜';
                    case ChessPieces.Queen:
                        return '♛';
                    case ChessPieces.King:
                        return '♚';
                    default:
                        return '♟';
                }
            default:
                return ' ';
        }
    }
}