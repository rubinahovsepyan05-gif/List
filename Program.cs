
namespace IntList;

class IntList
{
    private const int DefaultCapacity = 4;
 
    private int[] arr;
 
    public int Count { get; private set; }
    public int Capacity => arr.Length;
 
    public int this[int index]
    {
        get { return arr[index]; }
        set { arr[index] = value; }
    }
    public IntList(int capacity = DefaultCapacity)
    {
        if (capacity < 0)
        {
            capacity = DefaultCapacity;
        }
 
        arr = new int[capacity];
    }
    private void EnsureCapacity(int minCapacity=DefaultCapacity)
    {
        if (minCapacity < Capacity)
        {
            return;
        }

        int newCapacity = Capacity == 0 ? DefaultCapacity : Capacity * 2;
        while (newCapacity < minCapacity)
        {
            if (newCapacity > int.MaxValue / 2)
            {
                newCapacity = minCapacity;
                return;
            }
            newCapacity *= 2;
        }

        int[] newArr = new int[newCapacity];
        for (int i = 0; i < arr.Length; i++)
        {
            newArr[i] = arr[i];
        }
        arr = newArr;
    }

    public void Add(int number)
    {
        EnsureCapacity(Count + 1);
        arr[Count] = number;
        Count++;
    }

    public void Insert(int index, int number)
    {
        if (index < 0 || index > Count)
        {
            Console.WriteLine("Invalid index");
            return;
        }

        EnsureCapacity(Count + 1);

        for (int i = Count; i > index; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[index] = number;
        Count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            Console.WriteLine("There is no value in that position");
            return;
        }

        for (int i = index; i < Count - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[Count - 1] = 0;
        Count--;
    }

    public int? Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            Console.WriteLine("There is no value in that position");
            return null;
        }
        return arr[index];
    }

    public void Print()
    {
        Console.WriteLine("The array numbers are:");
        for (int i = 0; i < Count; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IntList obj=new IntList();
        obj.Add(4);
        obj.Add(8);
        obj.Add(15);
        obj.Print();
        Console.WriteLine($"The element in 0 index: {obj.Get(0)}");
        Console.WriteLine($"The element in 2 index: {obj.Get(2)}");
        obj.Insert(1,6);
        Console.WriteLine("After inserting 6 at index 1");
        obj.Print();
        Console.WriteLine($"The element in 1 index: {obj.Get(1)}");
        Console.WriteLine("After inserting 1 at index 0");
        obj.Insert(0,1);
        obj.Print();
        Console.WriteLine("After inserting 9 at index 5");
        obj.Insert(5,9);
        obj.Print();
        Console.WriteLine("After removing the value at index 2");
        obj.RemoveAt(2);
        obj.Print();
        Console.WriteLine($"The element in 2 index: {obj.Get(2)}");
        Console.WriteLine("After removing the value at index 0");
        obj.RemoveAt(0);
        obj.Print();
        Console.WriteLine("After removing the last value");
        obj.RemoveAt(3);
        obj.Print();
        Console.WriteLine($"The element in 0 index: {obj.Get(0)}");
        Console.WriteLine($"The element in 2 index: {obj.Get(2)}");
    }
}
