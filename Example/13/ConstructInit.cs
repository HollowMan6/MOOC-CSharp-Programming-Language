using System;
class A
{
	int x = 1;
	//int y = x+M(); //Error，因为域的初始化中不能引用this.x 及 this.M()
	int M(){ return 1; }
	public A( int x ){}
	public A(){}
};

class B : A
{
	int z=5;
	//public B() : base( z ) //Error，在父类型的构造函数被调用之前不能引用 this.z
	//{
	//}
};

class Test
{
	static void Main(){}
}