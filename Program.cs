using Homework;
using static Homework.ChessAlgoritms;
using static System.Console;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
OutputEncoding = Encoding.UTF8;
ChessSides side = new();
ChessPieces piece = new();
char playerSide;
char playerPiece;
char[,] board;
char playPiece;
while (true)
{
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
    Write("\nEnter coordinates: ");
    Coordinates playercoordinates = new();
    WriteLine();
    playPiece = GetPieceSymbol(side, piece);
    board = FillChessBoard(playPiece, playercoordinates);
    DisplayChessBoard(board);
}
void DisplayChessBoard(char[,] board)//Cansole
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