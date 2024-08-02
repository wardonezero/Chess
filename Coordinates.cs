using static System.Console;
namespace Homework;
internal struct Coordinates
{
    public int column;
    public int row;
    public Coordinates()
    {
        Write("\nEnter coordinates: ");
        IsLetter();
        IsNumber();
    }
    private int IsLetter()
    {
        while (true)
        {
            if (char.TryParse(ReadKey().KeyChar.ToString(), out char letter) && letter >= 'a' && letter <= 'h')
            {
                column = letter - 'a' + 1;
                break;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Error 3.1: Wrong coordinate.");
                ForegroundColor = ConsoleColor.Gray;
            }
        }
        return column;
    }
    private int IsNumber()
    {
        while (true)
        {
            if (char.TryParse(ReadKey().KeyChar.ToString(), out char number) && number >= '1' && number <= '8')
            {
                row = number - '1' + 1;
                break;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Error 3.2: Wrong coordinate.");
                ForegroundColor = ConsoleColor.Gray;
            }
        }
        return row;
    }
}