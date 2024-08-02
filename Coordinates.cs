using static System.Console;
namespace Homework;
internal struct Coordinates
{
    public int column;
    public int row;
    public Coordinates()
    {
        Write("\nEnter coordinates: ");
        IsLatter();
        IsNumber();
    }
    private int IsLetter()
    {
        while (true)
        {
            if (char.TryParse(ReadKey().KeyChar.ToString(), out char latter) && latter >= 'a' && latter <= 'h')
            {
                column = latter - 'a' + 1;
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