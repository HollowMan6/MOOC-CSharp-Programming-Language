using System;

class Color
{
	public Color()
	{
		this.red = 255;
		this.green = 255;
		this.blue = 255;
	}
	public Color( int r, int g, int b)
	{
		this.red =r ;
		this.green = g;
		this.blue = b;
	}

	protected int red;
	protected int green;
	protected int blue;

	public void GetRGB(out int red, out int green, out int blue)
	{
		red = this.red;
		green = this.green;
		blue = this.blue;
	}
}

class Test
{
	public static void Main()
	{
		Color color = new Color();
		int red;
		int green;
		int blue;
		color.GetRGB(out red, out green, out blue);
		Console.WriteLine("red = {0}, green = {1}, blue = {2}",
			red, green, blue);
	}
}
