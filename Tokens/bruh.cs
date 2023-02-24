public class ArrayList
{
    private string[] _array = new string[10];
    private int _pointer = 0;
    public void Add(string element)
    {
        _array[_pointer] = element;
        _pointer += 1;

        if (_pointer == _array.Length)
        {
            var extendedArray = new string[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray;
        }
    }
    public int IndexOf(string element)
    {
        for (var i = 0; i < _array.Length; i++)
        {
            if (_array[i] == element)
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(string element)
    {
        return IndexOf(element) != -1;
    }
}
public class MyStack<T>
{
    private T[] _items;
    private int _pointer;

    public MyStack(int capacity)
    {
        _items = new T[capacity];
        _pointer = -1;
    }

    public void Push(T item)
    {
        _pointer++;
        _items[_pointer] = item;
    }

    public T Pop()
    {
        T item = _items[_pointer];
        _pointer--;
        return item;
    }

    public T Peek()
    {
        T item = _items[_pointer];
        return item;
    }
    public int Count()
    {
        return _pointer + 1;
    }
}
public class MyQueue<T>
{
    private T[] _items;
    private int _headPoint;
    private int _tailPoint;

    public MyQueue(int capacity)
    {
        _items = new T[capacity];
        _headPoint = 0;
        _tailPoint = -1;
    }

    public void Enqueue(T item)
    {
        _tailPoint++;
        _items[_tailPoint] = item;
    }

    public T Dequeue()
    {
        T item = _items[_headPoint];
        _headPoint++;
        return item;
    }
    public int Count()
    {
        return _tailPoint + 1;
    }
}

//ArrayList opers1 = new ArrayList();
//opers1.Add("+"); opers1.Add("-"); opers1.Add("*"); opers1.Add("/");
//opers1.Add("^"); opers1.Add("("); opers1.Add(")");
//ArrayList opers2 = new ArrayList();
//opers2.Add("+"); opers2.Add("-"); opers2.Add("*"); opers2.Add("/");
//opers2.Add("^");