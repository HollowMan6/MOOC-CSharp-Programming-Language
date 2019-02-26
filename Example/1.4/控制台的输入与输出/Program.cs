using System;
public class AppLineInOut 
{
    public static void Main(string[] args) 
    {
        string s = "";
        Console.Write("Please input a line: ");
        s = Console.ReadLine();
        Console.WriteLine("You have entered: {0}" , s );
    }
}