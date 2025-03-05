using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Criando um dicionário com números como chave e nomes dos dias como valores
        Dictionary<int, string> diasSemana = new Dictionary<int, string>();

        // Adicionando valores ao dicionário
        diasSemana[0] = "Monday";
        diasSemana[1] = "Tuesday";
        diasSemana[2] = "Wednesday";
        diasSemana[3] = "Thursday";
        diasSemana[4] = "Friday";
        diasSemana[5] = "Saturday";
        diasSemana[6] = "Sunday";

        // Exibindo os valores do dicionário
        foreach (var item in diasSemana)
        {
            Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
        }
    }
}
