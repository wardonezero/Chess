using Chess;
using System.Text;
using static Chess.ChessAlgoritms;
using static System.Console;
OutputEncoding = Encoding.UTF8;
char[,] board;
Pieces playerPiece1 = new();
char playPiece;
//Coordinates pc = new();
while (true)
{
    while (true)
    {
        Write("Choose White or Black color: ");
        try
        {
            playerPiece1.Color = (PiecsColor)ReadKey().KeyChar;
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
    do
    {
        try
        {
            //pc.Letter = ReadKey().KeyChar;
            //pc.Number = ReadKey().KeyChar;
            //playerPiece1.currentCoordinates = pc;
            playerPiece1.CurrentCoordinateLetter = ReadKey().KeyChar;
            playerPiece1.CurrentCoordinateNumber = ReadKey().KeyChar;
            playerPiece1.CurrentCoordinateArray = [ playerPiece1.CurrentCoordinateLetter,playerPiece1.CurrentCoordinateNumber ];
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
    playPiece = GetPieceSymbol(playerPiece1);
    board = FillChessBoard(playPiece, playerPiece1);
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