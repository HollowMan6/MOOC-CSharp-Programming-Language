using System;
using System.Collections.Generic;
public class ListTest
{
    public static void Main()  
    {
        List<string> fruits = new List<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Carrot");
 
        Console.WriteLine( "Count: {0}", fruits.Count );
        PrintValues1( fruits );
        PrintValues2( fruits );
        PrintValues3( fruits );
    }
 
    static void PrintValues1( IList<string> myList )
    {
        for(int i=0; i<myList.Count; i++ )
            Console.Write( "{0}\n", myList[i] );
    }
    static void PrintValues2( IList<string> myList )
    {
        foreach(string item in myList )
            Console.Write( "{0}\n", item );
    }
    static void PrintValues3( IEnumerable<string> myList )  
    {
        IEnumerator<string> myEnumerator = myList.GetEnumerator();
        while ( myEnumerator.MoveNext() )
            Console.Write( "{0}\n", myEnumerator.Current );
        Console.WriteLine();
    }
}