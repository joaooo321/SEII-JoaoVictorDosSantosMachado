using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string nomeArquivo = "arquivo.txt";

        // 1- Criando e Escrevendo em um Arquivo de Texto
        string textoParaEscrever = "Este é um documento de texto.";
        File.WriteAllText(nomeArquivo, textoParaEscrever);
        Console.WriteLine("Arquivo criado com sucesso!");

        // 2- Lendo o Conteúdo do Arquivo
        string conteudoLido = File.ReadAllText(nomeArquivo);
        Console.WriteLine("\n📂 Conteúdo do arquivo:");
        Console.WriteLine(conteudoLido);

        // 3: Escrevendo Múltiplas Linhas em um Arquivo
        List<string> documentos = new List<string>
        {
            "Documento 1",
            "Documento 2",
            "Documento 3"
        };

        File.WriteAllLines(nomeArquivo, documentos);
        Console.WriteLine("\nMúltiplas linhas escritas no arquivo.");

        // 4:  Lendo Linhas do Arquivo
        string[] linhasLidas = File.ReadAllLines(nomeArquivo);
        Console.WriteLine("\nLinhas lidas do arquivo:");
        foreach (string linha in linhasLidas)
        {
            Console.WriteLine(linha);
        }

        // 5:  Adicionando Texto a um Arquivo Existente
        File.AppendAllText(nomeArquivo, "\nNova linha adicionada!");
        Console.WriteLine("\nNova linha adicionada ao arquivo.");
        
        // 6:  Lendo novamente para ver a alteração
        Console.WriteLine("\nArquivo atualizado:");
        string novoConteudo = File.ReadAllText(nomeArquivo);
        Console.WriteLine(novoConteudo);
    }
}
