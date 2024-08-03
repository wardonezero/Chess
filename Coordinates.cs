using static System.Console;
namespace Homework;
internal struct Coordinates
{
    private int _column;
    private int _row;
    public int column
    {
        get { return _column; }
        set
        {
            
        }
    }
    public int row
    {
        get { return _row; }
        //set
        //{
        //    _column = value;
        //}
    }
    public Coordinates()
    {
        Write("\nEnter coordinates: ");//Console
        IsLetter();
        IsNumber();
    }
    private int IsLetter()
    {
        while (true)
        {
            if (char.TryParse(ReadKey().KeyChar.ToString(), out char letter) && letter >= 'a' && letter <= 'h')
            {
                _column = letter - 'a' + 1;
                break;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Error 3.1: Wrong coordinate.");//Console
                ForegroundColor = ConsoleColor.Gray;
            }
        }
        return _column;
    }
    private int IsNumber()
    {
        while (true)
        {
            if (char.TryParse(ReadKey().KeyChar.ToString(), out char number) && number >= '1' && number <= '8')
            {
                _row = number - '1' + 1;
                break;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Error 3.2: Wrong coordinate.");//Console
                ForegroundColor = ConsoleColor.Gray;
            }
        }
        return _row;
    }
}