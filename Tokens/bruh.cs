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