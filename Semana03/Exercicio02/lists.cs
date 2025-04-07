using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Criando uma lista de strings
        List<string> diasSemana = new List<string>();

        // Adicionando valores à lista
        diasSemana.Add("Monday");
        diasSemana.Add("Tuesday");
        diasSemana.Add("Wednesday");
        diasSemana.Add("Thursday");
        diasSemana.Add("Friday");
        diasSemana.Add("Saturday");
        diasSemana.Add("Sunday");

        // Exibindo os valores da lista
        foreach (string dia in diasSemana)
        {
            Console.WriteLine(dia);
        }

        // Modificando a lista: Pegando os três primeiros caracteres de cada dia
        for (int i = 0; i < diasSemana.Count; i++)
        {
            diasSemana[i] = diasSemana[i].Substring(0, 3);
        }

        Console.WriteLine("\nLista modificada:");
        foreach (string dia in diasSemana)
        {
            Console.WriteLine(dia);
        }
    }
}
