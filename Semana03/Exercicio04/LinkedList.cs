public class LinkedList
{
    private Node First { get; set; }

    public void InsertFirst(int data)
    {
        Node newNode = new Node { Data = data };
        newNode.Next = First;
        First = newNode;
    }

    public Node DeleteFirst()
    {
        if (First == null) return null;
        Node temp = First;
        First = First.Next;
        return temp;
    }

    public void InsertLast(int data)
    {
        Node newNode = new Node { Data = data };
        if (First == null)
        {
            First = newNode;
            return;
        }

        Node current = First;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public void DisplayList()
    {
        Console.WriteLine("Iterando pela lista:");
        Node current = First;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}
