using System;
class All_220
{
    public static void Main( string[] args){
        for( int n=1; n<=9999; n++){
            int s = divsum(n);
            if( n<s && divsum(s)==n ) 
                Console.WriteLine(n +"," + s);
        }
    }
    public static int divsum( int n ){
        int s = 0;
        for( int i=1; i<n; i++ )
            if( n%i == 0 ) s+=i;
        return s;
    }
}