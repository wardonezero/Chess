using Homework;
using static Homework.ChessAlgoritms;
using static System.Console;
using System.Text;
while (true)
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
                //Console
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