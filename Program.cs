
namespace IntList;

class IntList
{
    private int[] arr=new int[4];
    public int count = 0;

    private void Resize(int[] array)
    {
        int size = array.Length;
        int[] newArr=new int[size];
        for (int i = 0; i < size; i++)
        {
            newArr[i] = arr[i];
        }

        arr = new int[size * 2];
        for (int i = 0; i < size; i++)
        {
            arr[i] = newArr[i];
        }
    }

    public void Add(int number)
    {
        if (arr.Length > count)
        {
            arr[count] = number;
            count++;
        }
        else
        {
            Resize(arr);
            Add(number);
        }
    }

    public void Insert(int index, int number)
    {
        if (index < 0 || index > count)
        {
            Console.WriteLine("Invalid index");
            return;
        }

        if (arr.Length == count)
        {
            Resize(arr);
        }

        for (int i = count; i > index; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[index] = number;
        count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("There is no value in that position");
            return;
        }

        for (int i = index; i < count - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[count - 1] = 0;
        count--;
    }

    public int? Get(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("There is no value in that position");
            return null;
        }
        return arr[index];
    }

    public void Print()
    {
        Console.WriteLine("The array numbers are:");
        for (int i = 0; i < count; i++)
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
