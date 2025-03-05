using System;

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();

        linkedList.InsertFirst(1);
        linkedList.InsertFirst(2);
        linkedList.InsertFirst(3);
        linkedList.InsertFirst(4);

        Console.WriteLine("Lista após inserções:");
        linkedList.DisplayList();

        linkedList.DeleteFirst();
        Console.WriteLine("Lista após deletar o primeiro elemento:");
        linkedList.DisplayList();

        linkedList.InsertLast(5);
        linkedList.InsertLast(6);
        Console.WriteLine("Lista após inserir no final:");
        linkedList.DisplayList();
    }
}
