using System;

class Video05 //
{
    static void Main(string[] args) // 
    {
        Console.WriteLine("Código do vídeo 05");
    }
}

class Program {
    static void Main() {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int key = 4; // Valor a ser buscado

        bool found = LinearSearch(array, key);
        Console.WriteLine("Elemento encontrado? " + found);
    }

    static bool LinearSearch(int[] array, int key) {
        for (int i = 0; i < array.Length; i++) {
            if (array[i] == key) {
                return true; // Retorna verdadeiro se o elemento for encontrado
            }
        }
        return false; // Retorna falso se o elemento não for encontrado
    }
}
