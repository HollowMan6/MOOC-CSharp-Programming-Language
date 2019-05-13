using System;
class Test {
	static void Swap(ref int a, ref int b) {
		int t = a;
		a = b;
		b = t;
	}
	static void Main() {
		int x = 1;
		int y = 2;

		Console.WriteLine("pre:  x = {0}, y = {1}", x, y);
		Swap(ref x, ref y);
		Console.WriteLine("post: x = {0}, y = {1}", x, y);
	}
}
