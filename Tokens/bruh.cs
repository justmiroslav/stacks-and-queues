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

public class MyStack
{
    private const int Capacity = 50;

    private string[] _array = new string [Capacity];
    
    private int _pointer = 0;

    public void Push(string value)
    {
        _array[_pointer] = value;
        _pointer++;
    }

    public string Pop()
    {
        string result = _array[_pointer - 1];
        _pointer--;
        return result;
    }

    public int Count()
    {
        return _pointer;
    }

    public string Peek()
    {
        if (_pointer == -1)
        {
            throw new InvalidOperationException();
        }
        return _array[_pointer - 1];
    }
}


public class MyQueue
{
    private const int Capacity = 50;
    private string[] _array = new string [Capacity];

    private int _pointer = 0;
    private int _headPoint;
    private int _tailPoint;

    public MyQueue()
    {
        _headPoint = 0;
        _tailPoint = -1;
    }

    public void Enqueue(string value)
    {
        _tailPoint++;
        _array[_tailPoint] = value;
    }

    public string Dequeue(string value)
    {
        value = _array[_headPoint];
        _headPoint++;
        return value;
    }

    public int Count()
    {
        return _pointer + 1;
    }

    public bool Contains(string value)
    {
        if (_array.Contains(value))
        {
            return true;
        }
        return false;
    }
}