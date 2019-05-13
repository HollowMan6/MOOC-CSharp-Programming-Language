using System;
class LocalVarAndMemberVar 
{
	static int a;	//域变量
	static void Main(){
		int b; //局部变量
		int [] c= new int[5];
		Console.WriteLine(a);	// a的值为0
		//Console.WriteLine(b);  //编译不能通过
		Console.WriteLine( c[3] );  //c[3]的值为0
	}
}
