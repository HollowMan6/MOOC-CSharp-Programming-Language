using System;
class Test
{
	static void Fill(object[] array, int index, int count, object value) 
	{
		for (int i = index; i < index + count; i++) array[i] = value;
	}
	static void Main() 
	{
		string[] strings = new string[100];
		Fill(strings, 0, 100, "Undefined");
		Fill(strings, 0, 10, null);
		Fill(strings, 90, 10, 0); 	// 运行时异常
	}
}
