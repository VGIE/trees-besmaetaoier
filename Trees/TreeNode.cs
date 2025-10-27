
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        private List<TreeNode<T>> Children;

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Value = value;
            Children = new List<TreeNode<T>>();
        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below
            
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;
            
            return null;
        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class TreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> newNode = new TreeNode<T>(value);
            Children.Add(newNode);
            return newNode;
            
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree
            int total = 0;
            foreach (TreeNode<T> child in Children)
            {
                total += child.Count();
            }
            total += 1;
            return total;            
        }

        public int Height()
        {
            //TODO #6: Return the height of this tree
            if (Children.Count == 0)
                return 1;

            int max = 0;
            foreach (TreeNode<T> child in Children)
            {
                int childHeight = child.Height();

                if (childHeight > max)
                    max = childHeight;
            }
            return 1 + max;
            
        }




        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
            int aux = 0;
            foreach (TreeNode<T> child in Children)
            {
                if (child.Value.Equals(value))
                {
                    Children.Remove(aux);
                }
                else
                {
                    child.Remove(value);
                }
                aux += 1;
            }
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            if (Value.Equals(value))
                return this;
            foreach (TreeNode<T> child in Children)
            {
                if (child.Find(value) != null)
                    return child;
            }
            return null;
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            int aux = 0;
            foreach (TreeNode<T> child in Children)
            {
                if (child.Equals(node))
                {
                    Children.Remove(aux);
                }
                aux += 1;
            }
        }
    }
}