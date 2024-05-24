using System;

class Program
{
    static void Main(string[] args)
    {
        SingleLinkedList list = new SingleLinkedList();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add item to end of list");
            Console.WriteLine("2. Find an element multiple of the specified value ");
            Console.WriteLine("3. Replace items in even positions with '0'");
            Console.WriteLine("4. Get a new list of element values greater than the specified value ");
            Console.WriteLine("5. Delete items at odd positions ");
            Console.WriteLine("6. Show list ");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your option: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Incorrect input. Try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter a value to add: ");
                    if (short.TryParse(Console.ReadLine(), out short value))
                    {
                        list.AddToEnd(value);
                        Console.WriteLine("Element was added.");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect item.");
                    }
                    break;
                case 2:
                    Console.Write("Enter multiple value: ");
                    if (short.TryParse(Console.ReadLine(), out short multipleValue))
                    {
                        Node foundNode = list.FindMultipleOf(multipleValue);
                        Console.WriteLine(foundNode != null ? $"First element, multiple of {multipleValue}: {foundNode.Data}"
                            : $"Element, that is multiple of {multipleValue}, wasn't found.");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value.");
                    }
                    break;
                case 3:
                    list.ReplaceEvenPositions();
                    Console.WriteLine("Elements in even positions are replaced by '0'.");
                    break;
                case 4:
                    Console.Write("Enter a value to compare: ");
                    if (short.TryParse(Console.ReadLine(), out short greaterValue))
                    {
                        SingleLinkedList greaterList = list.GetElementsGreaterThan(greaterValue);
                        Console.WriteLine($"New list of values greater than {greaterValue}:");
                        greaterList.PrintList();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value.");
                    }
                    break;
                case 5:
                    list.RemoveOddPositions();
                    Console.WriteLine("Items in odd positions are deleted.");
                    break;
                case 6:
                    Console.WriteLine("Current list:");
                    list.PrintList();
                    break;
                case 7:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
public class Node
{
    public short Data;
    public Node Next;

    public Node(short data)
    {
        Data = data;
        Next = null;
    }
}

public struct SingleLinkedList
{
    private Node head;

    public void AddToEnd(short data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }
    public Node FindMultipleOf(short value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data % value == 0)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public void ReplaceEvenPositions()
    {
        int position = 0;
        while (position < Count())
        {
            if (position % 2 == 0)
            {
                this[position] = 0;
            }
            position++;
        }
    }

    public SingleLinkedList GetElementsGreaterThan(short value)
    {
        SingleLinkedList newList = new SingleLinkedList();
        Node current = head;
        while (current != null)
        {
            if (current.Data > value)
            {
                newList.AddToEnd(current.Data);
            }
            current = current.Next;
        }
        return newList;
    }

    public void RemoveOddPositions()
    {
        int count = Count();

        if (count == 0)
        {
            return;
        }

        for (int i = count - 1; i >= 0; i--)
        {
            if (i % 2 != 0)
            {
                for (int j = i; j < count - 1; j++)
                {
                    this[j] = this[j + 1];
                }
                count--;
            }
        }

        Node current = head;
        for (int i = 0; i < count - 1; i++)
        {
            current = current.Next;
        }
        current.Next = null;
    }

    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    private int Count()
    {
        int count = 0;
        Node current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node current = head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.Data;
                }
                current = current.Next;
                currentIndex++;
            }

            throw new IndexOutOfRangeException("Index is out of range");
        }
        set
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node current = head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    current.Data = value;
                    break;
                }
                current = current.Next;
                currentIndex++;
            }
        }
    }
}
