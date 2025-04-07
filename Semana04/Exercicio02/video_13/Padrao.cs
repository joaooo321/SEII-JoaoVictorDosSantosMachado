using System;

abstract class Padrao
{
	// Obrigatorio
	public abstract void taxaEmprestimo(double valor);
	// Opcional
	public void CalculoPoupanca(double valor, double taxa)
	{
		Console.WriteLine("Ganhos obtios pela pupança R$ "+(valor*taxa));
	}

}
