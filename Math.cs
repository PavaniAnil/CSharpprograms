using System;

namespace mylib
{
class Test
{
	public static void Main(String[] args)
	{
		MyMath objMath = new MyMath();
		objMath.Square(6);
		objMath.Cube(5);
		
		
	}
}
class MyMath 
{
	public void Square(int numb)
	{
		Console.WriteLine(numb * numb);
	}
	public void Cube(int numb)
	{
		Console.WriteLine(numb * numb * numb);
	}

}
}