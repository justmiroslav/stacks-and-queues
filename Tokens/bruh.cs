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
    public string[] GetElements()
    {
        return _array;
    }
}