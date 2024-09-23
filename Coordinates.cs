namespace Chess;
internal struct Coordinates
{
    private char _letter;
    private byte _number;
    private byte[] _coordinates = new byte[2];

    public Coordinates()
    {
    }
    public char Letter
    {
        readonly get => _letter;
        set
        {
            if (value >= 'a' && value <= 'h')
            {
                _letter = value;
            }
            else
            {
                throw new ArgumentException("Error ?.1: Wrong coordinate.( a - b)");
            }
        }
    }
    public byte Number
    {
        readonly get => _number;
        set
        {
            if (value >= 48 && value <= 56)
            {
                _number = (byte)(56 - value);
            }
            else
            {
                throw new ArgumentException("Error ?.2: Wrong coordinate.( 1 - 8 )");
            }
        }
    }
    public byte[] CoordinatesArray
    {
        readonly get => _coordinates;
        set => _coordinates = value;
    }
    //private char IsLetter()
    //{
    //    while (true)
    //    {
    //        if (char.TryParse(ReadKey().KeyChar.ToString(), out char letter) && letter >= 'a' && letter <= 'h')
    //        {
    //            _letter = letter;
    //            coordinates[0] = letter - 'a' + 1;
    //            break;
    //        }
    //        else
    //        {
    //            //Console
    //            ForegroundColor = ConsoleColor.Red;
    //            WriteLine("\nError 3.1: Wrong coordinate.( a - b)");
    //            ForegroundColor = ConsoleColor.Gray;
    //            Write("Enter coordinates: ");
    //        }
    //    }
    //    return _letter;
    //}
    //private int IsNumber()
    //{
    //    while (true)
    //    {
    //        if (char.TryParse(ReadKey().KeyChar.ToString(), out char number) && number >= '1' && number <= '8')
    //        {
    //            _number = number - '1' + 1;
    //            coordinates[1] = _number;
    //            break;
    //        }
    //        else
    //        {
    //            //Console
    //            ForegroundColor = ConsoleColor.Red;
    //            WriteLine("\nError 3.2: Wrong coordinate.( 1 - 8 )");
    //            ForegroundColor = ConsoleColor.Gray;
    //            Write("Enter coordinates: ");
    //        }
    //    }
    //    return _number;
    //}
}