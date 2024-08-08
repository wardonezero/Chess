using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Homework;
internal struct Coordinates
{
    private char _letter;
    private int _number;
    public int[] coordinates = new int[2];
    public char Letter
    {
        get { return _letter; }
        set
        {
            if (value >= 'a' && value <= 'h')
            {
                _letter = value;
                coordinates[0] = _letter - 'a' + 1;
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
                coordinates[1] = value - 48;
            }
            else
            {
                throw new ArgumentException("Error 3.2: Wrong coordinate.( 1 - 8 )");
            }
        }
    }
    public Coordinates()
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