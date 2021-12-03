using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajokikoto_PDFFI2
{
    //class Stack
    //{
    //    Node top;
    //    public int Count { get; private set; }
    //    //private int length = 0;
    //    private List<Boat> boats = new List<Boat>();
    //    public Stack()
    //    {
    //        top = null;
    //        Count = 0;
    //    }
    //    public Stack(Stack stack)
    //    { 
    //        for (int i = 0; i < stack.Count; i++)
    //        {
    //            boats[i] = stack.boats[i];
    //        }
    //        Count = stack.Count;
    //    }

    //    public void Push(Boat data) //kell hogy tele legyen a kikoto
    //    {
    //        top = new Node(data, top);
    //        Count++;
    //    }
    //    public Boat Pop()
    //    {
    //        if (top == null)
    //            throw new PortEmptyException();
    //        Boat data = top.data;
    //        top = top.next;
    //        Count--;
    //        return data;
    //    }
    //    //public IEnumerable<Boat> PopAll()
    //    //{
    //    //    if (top == null)
    //    //        throw new Exception("Empty");
    //    //    List<Boat> outpost = new List<Boat>();
    //    //    while (Count != 0)
    //    //        outpost.Add(Pop());
    //    //    return outpost;
    //    //}
    //    //public Boat Peek()
    //    //{
    //    //    if (top == null)
    //    //        throw new Exception("Empty");
    //    //    Boat data = top.data;
    //    //    return data;
    //    //}
    //    public bool Contains(Boat data)
    //    {
    //        Node p = null;
    //        while (top != null)
    //        {
    //            p = top;
    //            if (p.data.Equals(data))
    //                return true;
    //        }
    //        return false;
    //    }
    //    //public void Clear()
    //    //{
    //    //    top = null;
    //    //}
    //    class Node
    //    {
    //        public Boat data;
    //        public Node next;
    //        public Node(Boat data, Node next = null)
    //        {
    //            if (data == null)
    //                throw new NullReferenceException();
    //            this.data = data;
    //            this.next = next;
    //        }
    //    }
    //}
    class Stack
    {
        private int length = -1;
        //private List<Boat> boats = new List<Boat>();
        private Boat[] boats = new Boat[2];
        public Stack()
        {

        }
        public Stack(Stack stack)
        {
            for (int i = 0; i < stack.Count; i++)
            {
                boats[i] = stack.boats[i];
            }
            length = stack.Count - 1;
        }
        public int Count
        {
            get
            {
                return length + 1;
            }
            
        }
        public void Push(Boat boat)
        {
            if (length >= boats.Length - 1)
            {
                throw new PortFullException();
            }
            length++;
            boats[length] = boat;
        }
        public Boat Pop()
        {
            if (boats.Length == 0)
            {
                throw new PortEmptyException();
            }
            int end = boats.Length - 1;
            Boat ret = boats[end];
            boats[end] = null;
            length--;
            return ret;
        }

    }
}
