using System;

class Test

{

    unsafe static string IntToString(int value) 

    {

        char* buffer = stackalloc char[16];

        char* p = buffer + 16;

        int n = value >= 0? value: -value;

        do 

        {

            *--p = (char)(n % 10 + '0');

            n /= 10;

        } while (n != 0);

        if (value < 0) *--p = '-';

        return new string(p, 0, (int)(buffer + 16 - p));

    }

    static void Main() 

    {

        Console.WriteLine(IntToString(12345));

        Console.WriteLine(IntToString(-999));

    }

}

