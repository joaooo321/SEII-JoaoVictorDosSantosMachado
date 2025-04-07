using System;

class Pessoa
{
	// Atributos
	public double peso;
	public double altura;

	// Método
	public double IMC()
	{
		return peso/ (altura * altura);
	}	

	public string situacao(double imc)
	{
		if(imc < 18.5)
		{
			return "Abaixo do peso";
		}
		else if (imc < 25) 
		{
			return "Peso normal";
		}
		else if (imc < 30) 
		{
			return "Acima do peso";
		}
		else if (imc < 35) 
		{
			return "Obesidade";
		}
		else if (imc < 40) 
		{
			return "Obesidade II";
		}
		else 
		{
			return "Obesidade III";
		}
	}

	public void mensagem()
	{
		double obterimc = IMC();
		string situation = situacao(obterimc);
		Console.WriteLine("Pessoa com "+altura+" m de altura, pesando "+peso+" kg. IMC: "+obterimc+" . Está em situacao "+ situation);
	}
}
