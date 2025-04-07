using System;

class Pessoa
{
	public string? nome;
	public int idade;

	public void mensagem()
	{
		Console.WriteLine("Oi " +nome+ "voce tem "+idade+" anos");
	}
}
