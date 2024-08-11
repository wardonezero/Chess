namespace Chess;
internal struct Coordinates
{
    private char _letter;
    private int _number;
    private int[] _coordinates;
    public int[] CoordinatesArray
    {
        get { return _coordinates; }
        set
        {
            _coordinates = [ 0, 0 ];
            _coordinates[0] = _letter - 'a' + 1;
            _coordinates[1] = _number;
        }
    }
    public char Letter
    {
        get { return _letter; }
        set
        {
            if (value >= 'a' && value <= 'h')
            {
                _letter = value;
            }
            else
            {
                throw new ArgumentException("Error 3.1: Wrong coordinate.( a - b)");
            }
        }
    }
    public int Number
    {
        get { return _number; }
        set
        {
            if (value >= 49 && value <= 56)
            {
                _number = value - 48;
            }
            else
            {
                throw new ArgumentException("Error 3.2: Wrong coordinate.( 1 - 8 )");
            }
        }
    }
    public Coordinates(char letter, int number)
    {
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