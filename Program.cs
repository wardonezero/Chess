using Chess;
using static Chess.Pieces;
using System.Text;
using static Chess.ChessAlgoritms;
using static System.Console;
OutputEncoding = Encoding.UTF8;
Board board1 = new();
board1.EmptyBoard();


while (true)
{
    Write("Choose color to play ( b / w ): ");
    try
    {
        char c = ReadKey().KeyChar;
        if (c == 'b' || c == 'w')
        {
            board1.PlayerColor = c == 'b' ? PieceColors.Black : PieceColors.White;
            WriteLine($"\nYou will play with {board1.PlayerColor} pieces.");
            break;
        }
        else
            throw new Exception("Enter b or w");
    }
    catch (Exception e)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"\n{e.Message}");
        ForegroundColor = ConsoleColor.Gray;
    }
}
board1.DefaultBoard();
board1.RandomPicesInBoard();
DisplayChessBoard(board1);
while (true)
{
    while (true)
    {
        Write("Choose coourdinate of piece in board, which you want to move: ");
        try
        {
            Coordinates c = new()
            {
                Letter = ReadKey().KeyChar,
                Number = (byte)ReadKey().KeyChar
            };
            c.CoordinatesArray = [(byte)(c.Letter - 'a'), c.Number];
            WriteLine();
            board1.ChoosePiece(c); WriteLine();
            DisplayChessBoard(board1);
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
        WriteLine($"You coosed {GetPieceSymbol(board1.GetPiece())} in {board1.GetPiece().CurrentLetter}{board1.GetPiece().CurrentNumber}");
        Write("Wher you want to move? Enter the coordinates: ");
        try
        {
            board1.MovePiece(ReadKey().KeyChar, (byte)ReadKey().KeyChar);
            WriteLine("\nYou can move there");
            DisplayChessBoard(board1);
            break;

        }
        catch (Exception e)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"\n{e.Message}");
            ForegroundColor = ConsoleColor.Gray;
        }
    }
}










static void DisplayChessBoard(Board board)
{
    char content = ' ';
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            if (i == 0 || j == 0 || j == 9 || i == 9)
            {
                if (i == 0 || i == 9)
                    content = j == 0 || j == 9 ? ' ' : (char)('@' + j);
                else
                    content = (char)('9' - i);
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.Gray;
            }
            else if ((i + j) % 2 == 0 && i < 9 && j < 9)
            {
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.DarkGray;
                content = board.board[i - 1, j - 1];
            }
            else if (i < 9 && j < 9)
            {
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.DarkGray;
                content = board.board[i - 1, j - 1];
            }
            if ((i > 0 && j > 0 && i < 9 && j < 9 && board.GetPiece().CanMove([(byte)(i - 1), (byte)(j - 1)])) || (i == 7 && j == 7 && board.GetPiece().CanMove([(byte)i, (byte)j])))
            {
                BackgroundColor = ConsoleColor.Green;
                ForegroundColor = ConsoleColor.DarkGray;
            }
            if (i > 0 && j > 0 && i < 9 && j < 9 && board.GetPiece().CurrentCoordinate[1] == i - 1 && board.GetPiece().CurrentCoordinate[0] == j - 1)
            {
                BackgroundColor = ConsoleColor.Cyan;
                ForegroundColor = ConsoleColor.DarkGray;
            }
            Write($" {content} ");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Gray;
        }
        WriteLine();
    }
}