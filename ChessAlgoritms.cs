namespace Chess;
internal static class ChessAlgoritms
{
    /*public void Movement()
    {
        OutputEncoding = Encoding.UTF8;
        ChessSides side = new();
        ChessPieces piece = new();
        char playerSide;
        char playerPiece;
        while (true)
        {
            Write("Choose White or Black side: ");//Console
            playerSide = ReadKey().KeyChar;
            if (playerSide == 'b' || playerSide == 'w')
            {
                side = playerSide == 'b' ? (ChessSides)1 : 0;
                break;
            }
            else
            {
                //Console
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nError 1: Choose black or white ( b / w )");
                ForegroundColor = ConsoleColor.Gray;
            }
        }
        while (true)
        {
            Write("\nChoose your chess piece.\nBishop  Knight  Rook  Queen  King: ");//Console
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
    }*/
    public static char[,] FillChessBoard(char playPiece, Pieces player)
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
        board[9 - player.coord.coordinates[1], player.coord.coordinates[0]] = playPiece;
        return board;
    }
    public static char GetPieceSymbol(Pieces playerPieces)
    {
        switch (playerPieces.Color)
        {
            case PicesColor.White:
                switch (playerPieces.PiecsChar)
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
            case PicesColor.Black:
                switch (playerPieces.PiecsChar)
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