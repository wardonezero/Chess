using Chess;
using static Chess.Pieces;
using System.Text;
using static Chess.ChessAlgoritms;
using static System.Console;
OutputEncoding = Encoding.UTF8;
char[,] board;
Pieces player1;
char playPiece;
while (true)
{
    Write("Choose your chess piece.\nBishop  Knight  Rook  Queen  King: ");
    try
    {
        player1 = Create(ReadKey().KeyChar);
        player1.PiecsChar = (ChessPieces)Enum.Parse(typeof(ChessPieces), player1.GetType().Name);
        break;
    }
    catch (Exception e)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"\n{e.Message}");
        ForegroundColor = ConsoleColor.Gray;
    }
}
while (true)
{
    Write("\nChoose White or Black color: ");
    try
    {
        player1.Color = (PiecsColor)ReadKey().KeyChar;
        break;
    }
    catch (Exception e)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"\n{e.Message}");
        ForegroundColor = ConsoleColor.Gray;
    }
}
Write("\nEnter coordinates: ");
do
{
    try
    {
        player1.CurrentCoordinateLetter = ReadKey().KeyChar;
        player1.CurrentCoordinateNumber = ReadKey().KeyChar;
        break;
    }
    catch (Exception e)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"\n{e.Message}");
        ForegroundColor = ConsoleColor.Gray;
        Write("Enter coordinate: ");
    }
} while (true);
WriteLine();
playPiece = GetPieceSymbol(player1);
board = FillChessBoard(playPiece, player1);
DisplayChessBoard(board);
do
{
    Write("\nEnter the new coordinates: ");
    try
    {
        player1.MoveCoordinateLetter = ReadKey().KeyChar;
        player1.MoveCoordinateNumber = ReadKey().KeyChar;
        if (player1.Move() == true)
        {
            player1.CurrentCoordinate = player1.MoveCoordinate;
            WriteLine("\nYou can move there");
            board = FillChessBoard(playPiece, player1);
            DisplayChessBoard(board);
        }
    }
    catch (Exception e)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"\n{e.Message}");
        ForegroundColor = ConsoleColor.Gray;
        Write("Enter coordinate: ");
    }
} while (true);
static void DisplayChessBoard(char[,] board)
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