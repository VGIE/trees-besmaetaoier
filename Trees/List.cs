namespace Lists;


//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using Lists;
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        return m_numItems;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
            if (index < 0 || index >= Count() || First == null )
                return default(T);
        ListNode<T> node = First;
        int currentIndex = 0;

        while (node != null && currentIndex < index)
        {

            node = node.Next;
            currentIndex++;
        }

        if (node != null)
        {
            return node.Value;
        }
        else
        {
            return default(T);    
        }        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        ListNode<T> newNode = new ListNode<T>(value);
        if (First == null)
        {
            First = newNode;
            Last = newNode;
        }
        else
        {
            ListNode<T> node2 = Last;
            node2 = node2.Next;
            Last = newNode;
        }
        
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        
        return default(T);
        
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        
        yield return null;
        
    }
}