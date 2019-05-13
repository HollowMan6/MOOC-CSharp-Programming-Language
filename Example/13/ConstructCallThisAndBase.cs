using System;
class ConstructCallThisAndBase 
{
	public static void Main(String[] args) 
	{
		Person p = new Graduate();
	}
}

class Person
{
	String name; 
	int age;
	public Person(){}
	public Person( String name, int age )
	{
		this.name=name; this.age=age; 
		Console.WriteLine("In Person(String,int)");
	}
}

class Student : Person
{
	String school;
	public Student(): this( null, 0, null )
	{
		Console.WriteLine("In Student()");
	}
	public Student( String name, int age, String school ):base( name, age )
	{
		this.school = school;
		Console.WriteLine("In Student(String,int,String)");
	}
}

class Graduate : Student
{
	public Graduate()
	{
		Console.WriteLine("In Graduate()");
	}
}
