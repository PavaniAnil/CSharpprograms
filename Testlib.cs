using System;
using mylib;

class Testlib
{
	public static void Main(String[] args)
	{
		Test oTest = new Test();
		oTest.TestMethod();
		Test2 objTest = new Test2();
		objTest.TestMethodTwo();
		Test3 objnewTest = new Test3();
		objnewTest.TestMethodThree();
	}
}