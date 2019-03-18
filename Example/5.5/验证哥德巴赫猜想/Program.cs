using System;
class GDBH 
{
      
   static void Main()
   {
        for (int n = 6; n <= 100; n+=2)
        {
            for (int a = 3; a<=n/2; a+=2)
            {
                int b = n - a;
                if (IsPrime(a) && IsPrime(b))
                {
                    Console.WriteLine(n + "=" + a + "+" + b);
                    break;
                }
            }
        }
    }
  
    static bool IsPrime(int a)
    {
        for (int i = 2; i <= a / 2; i++)
        {
            if (a % i == 0) return false;
        }
        return true;
    }
}