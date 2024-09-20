using Chess;
using static Chess.Pieces;
using System.Text;
using static Chess.ChessAlgoritms;
using static System.Console;
OutputEncoding = Encoding.UTF8;
Board board1 = new();
//Pieces player1;
//char playPiece;
board1.EmptyBoard();
board1.DefaultBoard();

DisplayChessBoard(board1);

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
while (true)
{
    while (true)
    {
        Write("Choose coourdinate of piece in board, which you want to move: ");
        try
        {
            Coordinates c = new Coordinates();
            c.Letter = ReadKey().KeyChar;
            c.Number = ReadKey().KeyChar;
            c.CoordinatesArray = [c.Letter - 'a', c.Number];
            board1.ChoosePiece(c);
            WriteLine(board1.ChoosePiece(c));
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
        Write("\nWher you want to move? Enter the coordinates: ");
        try
        {
            board1.MovePiece(ReadKey().KeyChar, ReadKey().KeyChar);
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











//board1.RandomPicesInBoard(14);
/*DisplayChessBoard1(board1.board);
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
        player1.Color = (PieceColors)ReadKey().KeyChar;
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
//board1.EmptyBoard();
//board1.PutPieceInBoard(playPiece, player1);
DisplayChessBoard(board1, player1);
do
{
    Write("\nEnter the new coordinates: ");
    try
    {
        player1.MoveCoordinateLetter = ReadKey().KeyChar;
        player1.MoveCoordinateNumber = ReadKey().KeyChar;
        if (player1.Move())
        {
            player1.CurrentCoordinate = player1.MoveCoordinate;
            WriteLine("\nYou can move there");
            //board1.PutPieceInBoard(playPiece, player1);
            DisplayChessBoard(board1, player1);
        }
    }
    catch (Exception e)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"\n{e.Message}");
        ForegroundColor = ConsoleColor.Gray;
        Write("Enter coordinate: ");
    }
} while (true);*/
static void DisplayChessBoard(Board board/*, Pieces player*/)
{
    char content = ' ';
    //player.AllCoordinateWherCanMove(board);
    for (int i = 0; i <= 8; i++)
    {
        for (int j = 0; j <= 8; j++)
        {
            if (i == 0 || j == 0)
            {
                if (i == 0)
                    content = j == 0 ? ' ' : (char)('@' + j);
                else //if (j == 0)
                    content = (char)('9' - i);
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.Gray;
            }
            else if ((i + j) % 2 == 0)
            {
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.DarkGray;
                content = board.board[i - 1, j - 1];
            }
            else
            {
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.DarkGray;
                content = board.board[i - 1, j - 1];
            }
            if (i != 0 && j != 0 && board.GetPiece().CanMove(i, j))
            {
                BackgroundColor = ConsoleColor.Green;
                ForegroundColor = ConsoleColor.DarkGray;
            }
            Write($" {content} ");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Gray;
        }
        WriteLine();
    }
}
static void DisplayChessBoard1(char[,] board)
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