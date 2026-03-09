namespace LinkedListIntroduction.Lib;

public class IntegerNode
{
    internal int _value;
    internal IntegerNode _next;

    internal int Count => _next == null ? 1 : 1 + _next.Count;
            
    internal int Sum => _next == null ? _value : _value + _next.Sum;


    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }

    internal void Append(int v)
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }

    internal bool Contains(int v)
    {
        if (_value == v) return true;
        return _next != null && _next.Contains(v);
    }

}


public class IntegerLinkedList
{
    protected IntegerNode _head;
   
    public IntegerLinkedList()
    {
        _head = null;
    }

    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }

    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;

    public void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);
    }


    public void Prepend(int v)
    {
        IntegerNode newNode = new IntegerNode(v);
        newNode._next = _head;
        _head = newNode;
    }

    public bool Delete(int v)
    {
        if (_head == null) return false;

        if (_head._value == v)
        {
            _head = _head._next;
            return true;
        }

        IntegerNode current = _head;
        while (current._next != null)
        {
            if (current._next._value == v)
            {
                current._next = current._next._next;
                return true;
            }
            current = current._next;
        }
        return false;
    }

    public void Insert(int v, int index)
    {
        if (index <= 0)
        {
            Prepend(v);
            return;
        }

        IntegerNode current = _head;
        for (int i = 0; i < index - 1 && current != null; i++)
        {
            current = current._next;
        }

        IntegerNode newNode = new IntegerNode(v);
        newNode._next = current._next;
        current._next = newNode;
    }

    public void Join(IntegerLinkedList other)
    {
        if (other._head == null) return;
        if (_head == null)
        {
            _head = other._head;
            return;
        }

        IntegerNode current = _head;
        while (current._next != null)
        {
            current = current._next;
        }
        current._next = other._head;
    }

     public bool Contains(int v)
    {
        IntegerNode current = _head;

        while(current != null)
        {
            if(current._value == v) return true;
            current = current._next;
        }
        return false;
    }

    public void RemoveDuplicates()
    {
        IntegerNode current = _head;
        while (current != null)
        {
            IntegerNode runner = current;
            while (runner._next != null)
            {
                if (runner._next._value == current._value)
                    runner._next = runner._next._next; 
                else
                    runner = runner._next;
            }
            current = current._next;
        }
    }

    public IntegerLinkedList Reverse()
    {
        IntegerLinkedList newList = new IntegerLinkedList();
        IntegerNode current = _head;
        while (current != null)
        {
            newList.Prepend(current._value);
            current = current._next;
        }
        return newList;
    }
    public override string ToString() => _head == null ? "{}" : $"{{{_head}}}";
}

public class SortedIntegerLinkedList : IntegerLinkedList
{
    public void AddSorted(int v)
    {
        if (_head == null || v < _head._value)
        {
            Prepend(v);
            return;
        }

        IntegerNode current = _head;
        while (current._next != null && current._next._value < v)
        {
            current = current._next;
        }

        IntegerNode newNode = new IntegerNode(v);
        newNode._next = current._next;
        current._next = newNode;
    }
}