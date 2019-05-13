using System;

class DateClass
{
	private int day = 12;
	private int month = 6;
	private int year = 1900;
	public DateClass(int y, int m, int d) 
	{
		year = y;
		month = m;
		day = d;
	}     
	public void addDay()
	{
		day ++;
	}
	public void display() 
	{
		Console.WriteLine(year + "-" + month + "-" +day);  
	}
}

struct DateStruct
{
	public int day ;
	public int month ;
	public int year ;
	public DateStruct(int y, int m, int d) 
	{
		year = y;
		month = m;
		day = d;
	} 
	public void addDay()
	{
		day ++;
	}
	public void display() 
	{
		Console.WriteLine(year + "-" + month + "-" +day);  
	}
}

public class Test 
{
	public static void Main(string[] args) 
	{
		DateClass p, q;
		p = new DateClass(2004,1,1);
		q = p;
		p.addDay();
		p.display();
		q.display();
		
		DateStruct  m, n;
		m = new DateStruct(2004,1,1);
		n = m;
		m.addDay();
		m.display();
		n.display();

		Console.Read();

	}    
}
