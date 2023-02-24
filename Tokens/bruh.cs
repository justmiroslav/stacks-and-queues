internal class MyStack<T>
{
    private T[] _items;
    private int _pointer;

    public MyStack(int size)
    {
        _items = new T[size];
        _pointer = -1;
    }

    public void Push(T item)
    {
        if (_pointer == _items.Length - 1)
        {
            throw new StackOverflowException();
        }
        _pointer++;
        _items[_pointer] = item;
    }

    public T Pop()
    {
        if (_pointer == -1)
        {
            throw new InvalidOperationException();
        }
        T item = _items[_pointer];
        _pointer--;
        return item;
    }

    public T Peek()
    {
        if (_pointer == -1)
        {
            throw new InvalidOperationException();
        }
        return _items[_pointer];
    }

    public int Count
    {
        get { return _pointer + 1; }
    }
}
public class MyQueue<T>
{
    private List<T> items;

    public MyQueue()
    {
        items = new List<T>();
    }

    public void Enqueue(T item)
    {
        items.Add(item);
    }
}