using Chess;
using System.Text;
using static Chess.ChessAlgoritms;
using static System.Console;
OutputEncoding = Encoding.UTF8;
char[,] board;
Pieces playerPiece1 = new();
char playPiece;
while (true)
{
    while (true)
    {
        Write("Choose White or Black color: ");
        try
        {
            playerPiece1.Color = (PicesColor)ReadKey().KeyChar;
            break;
        }
        catch(Exception e)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"\n{e.Message}");
            ForegroundColor = ConsoleColor.Gray;
        }
    }
    while (true)
    {
        Write("\nChoose your chess piece.\nBishop  Knight  Rook  Queen  King: ");
        try
        {
            playerPiece1.PiecsChar = (ChessPieces)ReadKey().KeyChar;
            break;
        }
        catch (Exception e)
        {
            WriteLine($"\n{e.Message}");
        }
    }
    Write("\nEnter coordinates: ");

    Coordinates currentCoord = new Coordinates();
    do
    {
        try
        {
            currentCoord.Letter = ReadKey().KeyChar;
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
    do
    {
        try
        {
            currentCoord.Number = ReadKey().KeyChar;
            break;
        }
        catch (Exception e)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"\n{e.Message}");
            ForegroundColor = ConsoleColor.Gray;
            Write($"Enter coordinate: {playerPiece1.Coordinates1.Letter}");
        }
    } while (true);

    playerPiece1.Coordinates1 = currentCoord;

    WriteLine();
    playPiece = GetPieceSymbol(playerPiece1);
    board = FillChessBoard(playPiece, playerPiece1.Coordinates1);
    DisplayChessBoard(board);
}
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