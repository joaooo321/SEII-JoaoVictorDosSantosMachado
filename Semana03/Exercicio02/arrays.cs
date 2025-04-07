using System;

class Program
{
    static void Main()
    {
        // Criando um array de strings para os dias da semana
        string[] diasSemana = new string[7];

        // Atribuindo valores ao array
        diasSemana[0] = "Monday";
        diasSemana[1] = "Tuesday";
        diasSemana[2] = "Wednesday";
        diasSemana[3] = "Thursday";
        diasSemana[4] = "Friday";
        diasSemana[5] = "Saturday";
        diasSemana[6] = "Sunday";

        // Percorrendo e imprimindo o array
        for (int i = 0; i < diasSemana.Length; i++)
        {
            Console.WriteLine(diasSemana[i]);
        }
    }
}
