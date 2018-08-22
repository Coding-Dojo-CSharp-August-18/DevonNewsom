namespace SinglyLinkedLists
{
    public class Node
    {
        public int Value;
        public Node Next;
        public Node(int val)
        {
            Value = val;
            Next = null;
        }
    }

    public class SinglyLinkedList
    {
        public Node Head;
        public bool IsEmpty
        {
            get {
                return Head == null;
            }
        }

        public void AddToFront(int value)
        {
            // create a node object (with value)

            Node newNode = new Node(value);

            newNode.Next = Head;
            Head = newNode;
        }

        public void AddToBack(int value)
        {
            // initialize new node
            Node newNode = new Node(value);
            Node current = Head;

            // Edge Case: Empty List
            if(current == null)
            {
                Head = newNode;
                return;
            }

            // find the end of the list
            while(current.Next != null)
                current = current.Next;
            
            // put the node there!
            current.Next = newNode;

        }

        public int Size()
        {
            int count = 0;

            return count;
        }

        public bool Contains(int value)
        {
            return false;
        }


    }
}