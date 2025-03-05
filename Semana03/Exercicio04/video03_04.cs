using System;

class Video03_04 // 
{
    static void Main(string[] args) //
    {
        Console.WriteLine("Código do vídeo 03_04");
    }
}

// Definição de um Tipo Abstrato de Dado (ADT) - Representação de um Pokémon
public class Pokemon {
    public string Name { get; set; }
    public int Experience { get; set; }

    public Pokemon(string name, int experience) {
        Name = name;
        Experience = experience;
    }

    public void ShowInfo() {
        Console.WriteLine($"Pokemon: {Name}, XP: {Experience}");
    }
}

class Program {
    static void Main() {
        //ADT
        Console.WriteLine("--- Abstract Data Type Example ---");
        Pokemon pikachu = new Pokemon("Pikachu", 100);
        pikachu.ShowInfo();

        // Big O - O(1), O(n), O(n^2)
        Console.WriteLine("\n--- Big O Notation Examples ---");
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine("O(1) - Acessando elemento direto: " + numbers[2]);
        
        Console.Write("O(n) - Percorrendo o array: ");
        foreach (var num in numbers) {
            Console.Write(num + " ");
        }

        Console.WriteLine("\nO(n^2) - Comparando todos os pares:");
        for (int i = 0; i < numbers.Length; i++) {
            for (int j = 0; j < numbers.Length; j++) {
                Console.Write($"({numbers[i]}, {numbers[j]}) ");
            }
            Console.WriteLine();
        }

        // Manipulação de Arrays
        Console.WriteLine("\n--- Array Insertions and Deletions ---");
        int[] array = new int[6] {1, 2, 3, 4, 5, 0};
        int length = 5;

        Console.WriteLine("Antes da inserção:");
        PrintArray(array, length);


        array[length] = 6;
        length++;
        Console.WriteLine("Após inserção no fim:");
        PrintArray(array, length);

        length--;
        Console.WriteLine("Após remoção do último elemento:");
        PrintArray(array, length);
    }

    static void PrintArray(int[] array, int length) {
        for (int i = 0; i < length; i++) {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
