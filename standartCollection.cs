using System;
using System.Collections;
using System.Collections.Generic;

public class StandartGenericCollection<T> : IEnumerable<T>
{
    private List<T> list = new List<T>();

    private int count;
    // Events
    public event EventHandler ItemAdded;
    public event EventHandler ItemRemoved;
    public event EventHandler CollectionCleared;

    public StandartGenericCollection()
    {
        count = 0;
    }

    public void Add(T item)
    {
        list.Add(item);
        count = list.Count;
        ItemAdded?.Invoke(this, EventArgs.Empty); // Invoke the event
    }

    public bool Remove(T item)
    {
        var removed = list.Remove(item);
        if (removed)
        {
            count = list.Count;
            ItemRemoved?.Invoke(this, EventArgs.Empty); // Invoke the event
        }
        return removed;
    }

    public void Clear()
    {
        list.Clear();
        count = 0;
        CollectionCleared?.Invoke(this, EventArgs.Empty); // Invoke the event
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return list[index];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => list.Count;
}

class StandartCollection
{
    public void Run()
    {
        var collection = new MyGenericCollection<int>();
        collection.ItemAdded += (sender, e) => Console.WriteLine("Item added");
        collection.ItemRemoved += (sender, e) => Console.WriteLine("Item removed");
        collection.CollectionCleared += (sender, e) => Console.WriteLine("Collection cleared");

        collection.Add(1);
        collection.Add(2);
        collection.Remove(1);
        collection.Clear();

        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}

