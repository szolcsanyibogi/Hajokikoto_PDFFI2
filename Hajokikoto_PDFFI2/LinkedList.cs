using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajokikoto_PDFFI2
{
    class ListItem
    {
        public Boat content { get; set; }
        public ListItem next { get; set; }
        public ListItem(Boat boat)
        {
            content = boat;
            next = null;
        }
    }
    class LinkedList
    {
        private ListItem head;
        public void Add(Boat boat)
        {
            ListItem newitem = new ListItem(boat);
            if (head == null)
            {
                head = newitem;
                return;
            }
            ListItem last = head;
            while (last.next != null)
            {
                last = last.next;
            }
            last.next = newitem;
        }
        public void Delete(Boat boat)
        {
            ListItem p = head;
            ListItem e = null;
            if (p != null && p.content.Equals(boat))
            {
                head = p.next;
                return;
            }
            while (p != null && !p.content.Equals(boat))
            {
                e = p;
                p = p.next;
            }
            if (p == null) { return; }
            e.next = p.next;
        }
        public bool Contain(Boat boat)
        {
            ListItem p = head;
            while (p != null && !p.content.Equals(boat))
            {
                p = p.next;
            }
            return p != null;
        }
        public int Count()
        {
            ListItem p = head;
            if (p == null)
            {
                return 0;
            }
            int i = 1;
            while (p.next != null)
            {
                p = p.next;
                i++;
            }
            return i;

        }
        public Boat Index(int index)
        {
            ListItem p = head;
            int i = 0;
            while (p != null && index != i)
            {
                p = p.next;
                i++;
            }
            if (p != null) { return p.content; }
            else { return null; }

        }
    }
}
