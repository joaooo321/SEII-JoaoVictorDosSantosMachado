using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace ProgAssincrona
{
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			ExecutarComThreads();
			sw.Stop();
			Console.WriteLine($"Operação gastou {sw.ElapsedMilliseconds} milissegunodos.");

		}
		
		static void RealizarOperacao(int op, string nome, string sobrenome)
		{
			Console.WriteLine($"Iniciando Operação {op}...");
			for (int i =0; i < 1000000000; i++)
			{
				var p = new Pessoa(nome, sobrenome, 35);
			}
			Console.WriteLine($"Finalizando Operação {op}...");
		}

		static void ExecutarComThreads()
		{

			var t1 = new Thread(() =>
			{
				RealizarOperacao(1, "Fulano", "da Silva");
			});
			var t2 = new Thread(() =>
			{
				RealizarOperacao(2, "Beltrano", "da Silva");
			});
			var t3 = new Thread(() =>
			{
				RealizarOperacao(3, "Sicrano", "da Silva");
			});

			t1.Start();
			t2.Start();
			t3.Start();

			t1.Join();
			t2.Join();
			t3.Join();
		}
	}
}
