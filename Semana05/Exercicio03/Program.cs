using System;
using System.Threading;

class MainClass
{
	static void Main()
	{
		var thread = new Thread(DifferentMethod);
		thread.Start();
	}

	static void DifferentMethod()
	{
		Console.WriteLine("My Name");
	}
}
