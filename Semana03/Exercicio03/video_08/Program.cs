using System;
using System.IO;

namespace CSCourse
{
	class Program
	{
		public static void Main(string[] args)
		{
			string pasta = "Nova pasta";

			Directory.CreateDirectory(pasta);

			Console.ReadKey(true);
		}
	}
}
