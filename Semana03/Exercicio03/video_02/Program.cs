using System;
using System.IO;

namespace CSCourse
{
	class Program
	{
		public static void Main(string[] args)
		{
			string arquivo = "arquivo.txt";
			string texto = File.ReadAllText(arquivo);

			Console.WriteLine("Conteúdo do arquivo : " + texto);

			Console.ReadKey(true);
		}
	}
}
