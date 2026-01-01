using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GenericsCustomization
    {
        public GenericsCustomization() 
        { 
        }

        public void ExampleOfList()
        {
            List<string> names = new List<string>();
        }
}

    public class MyCollection : IList
    {
        public List<object> items = new List<object>();
        public object this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public int Count => items.Count;
    public bool IsReadOnly => false;
    public bool IsFixedSize => false;
    public bool IsSynchronized => false;
    public object SyncRoot => this;

        public int Add(object? value)
        {
            items.Add(value!);
            return items.Count-1;
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(object? value)
        {
            return items.Contains(value!);
        }

        public void CopyTo(Array array, int index)
        {
            items.ToArray().CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public int IndexOf(object? value)
        {
            return items.IndexOf(value!);
        }

        public void Insert(int index, object? value)
        {
            items.Insert(index, value!);
        }

        public void Remove(object? value)
        {
            items.Remove(value!);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }
    }
