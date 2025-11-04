namespace Lists;


//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using Lists;
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;
    public ListNode<T> Privious = null;

    

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
            Last.Next = newNode;
            newNode.Privious = Last;
            Last = newNode;
        }
        m_numItems++;
        
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        if (index < 0 || index >= m_numItems || First == null)
            return default(T);
        ListNode<T> node = First;
        int currentIndex = 0;

        while (node != null && currentIndex < index)
        {
            node = node.Next;
            currentIndex++;
        }
        
        if (node == null)
        {
            return default(T);
        }
        if (node.Privious != null)
        {
            node.Privious.Next = node.Next;
        }
        else
        {
            First = node.Next;
        }
        if (node.Next != null)
        {
            node.Next.Privious = node.Privious;
        }
        else
        {
            Last = node.Privious;
        }

        m_numItems--;
        return node.Value;        
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        First = null;
        Last = null;
        m_numItems = 0;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        ListNode<T> node = First;
        while(node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
        
    }
}