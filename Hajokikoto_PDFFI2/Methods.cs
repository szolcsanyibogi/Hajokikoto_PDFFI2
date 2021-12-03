using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hajokikoto_PDFFI2
{
    public delegate void EventDelegate();
    class Methods
    {
        public event EventDelegate Event;
        public void Start(EventDelegate delegat)
        {
            Write w = new Write();
            Port port = Read();
            Event += delegat;
            string data = "";
            do
            {
                w.Choose();
                data = Console.ReadLine();
                if (data == "A" && data == "a")
                {
                    TakeOut(ref port);
                }
                else if(data == "B" && data == "b")
                {
                    Add(ref port);
                }
            } while (data != "C" && data != "c");
        }
        public Port Read()
        {
            Write w = new Write();
            StreamReader sr = new StreamReader("data.txt");
            string[] first = sr.ReadLine().Split('*');
            Stack boats = new Stack();
            LinkedList save = new LinkedList();
            LinkedList dontSave = new LinkedList();
            Stack stack = new Stack(boats);
            while (!sr.EndOfStream)
            {
                string[] row = sr.ReadLine().Split('*');
                Boat boat = new Boat(Convert.ToDouble(row[0]), Convert.ToDouble(row[1]), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]));
                boats.Push(boat);
            }
            Port port = new Port(Convert.ToInt32(first[0]), Convert.ToInt32(first[1]));
            bool success = Location(ref port, ref boats, ref save);
            w.Success(success);
            for (int i = 0; i < boats.Count; i++)
            {
                Boat temp = stack.Pop();
                if(!save.Contain(temp)) { dontSave.Add(temp); }
            }
            if (!success) { throw new LocationException(dontSave); }
            return port;
        }
        public void Add(ref Port port)
        {
            Write w = new Write();
            Stack boats = new Stack();
            Stack first = new Stack(port.boats);
            LinkedList save = new LinkedList();
            w.BoatsData();
            string[] row = Console.ReadLine().Split('*');
            Boat boat = new Boat(Convert.ToDouble(row[0]), Convert.ToDouble(row[1]), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]));
            boats.Push(boat);
            bool success = Location(ref port, ref boats, ref save);
            Stack temp = new Stack(port.boats);
            Stack id = new Stack();
            if (!success)
            {
                int i = 0;
                while (temp.Count > 0 && !success && i < temp.Count)
                {
                    i = 0;
                    do
                    {
                        i++;
                        boat = temp.Pop();
                        if (boat.sunk == true) { id.Push(boat); }
                    } while (boat.sunk == true && temp.Count > 0);
                    while (id.Count > 0) { temp.Push(id.Pop()); }
                    boats.Push(boat);
                    port.boats = new Stack(temp);
                    success = Location(ref port, ref boats, ref save);
                }
            }
            if (!success) { port.boats = first; }
            w.Success(success);
        }
        public void TakeOut(ref Port port)
        {
            Write w = new Write();
            Stack stack = new Stack(port.boats);
            LinkedList list = new LinkedList();
            for (int i = 0; i < port.boats.Count; i++)
            {
                Boat boat = stack.Pop();
                list.Add(boat);
                w.Listing(i, boat);
            }
            int x;
            do
            {
                w.ChooseBoat();
                x = Convert.ToInt32(Console.ReadLine());
            } while (x < 1 || x > list.Count());
            Boat takeOut = list.Index(x - 1);
            Stack stackTakenOut = new Stack();
            Boat takenOut = port.boats.Pop();
            while (!takenOut.Equals(takeOut))
            {
                stackTakenOut.Push(takenOut);
                takenOut = port.boats.Pop();
            }
            if (takeOut.sunk == true)
            {
                port.boats.Push(takenOut);
                while (stackTakenOut.Count > 0) { port.boats.Push(stackTakenOut.Pop()); }
                throw new TakeOutException();
            }
            else if (stackTakenOut.Count > 0)
            {
                LinkedList save = new LinkedList();
                Location(ref port, ref stackTakenOut, ref save);
                Event?.Invoke();
            }
        }
        public bool Location(ref Port port, ref Stack boats, ref LinkedList list)
        {
            Boat boat = boats.Pop();
            if (!boat.wheelWorks)
            {
                for (int i = 0; i < port.length - (boat.length - 1); i++)
                {
                    if(Fits(port.boats, boat, boat.x, i))
                    {
                        boat.y = i;
                        port.boats.Push(boat);
                        if (!list.Contain(boat)) { list.Add(boat); }
                        if (boats.Count > 0)
                        {
                            bool success = Location(ref port, ref boats, ref list);
                            if (success) { return true; }
                            else { port.boats.Pop(); list.Delete(boat); }
                        }
                    }
                    else { return true; }
                }
            }
            else
            {
                for (int i = 0; i < port.length - (boat.length - 1); i++)
                {
                    for (int j= 0; j < port.length - (boat.length - 1); j++)
                    {
                        if (Fits(port.boats, boat, i, j))
                        {
                            boat.x = i;
                            boat.y = j;
                            port.boats.Push(boat);
                            if (!list.Contain(boat)) { list.Add(boat); }
                            if (boats.Count > 0)
                            {
                                bool success = Location(ref port, ref boats, ref list);
                                if (success) { return true; }
                                else
                                {
                                    port.boats.Pop();
                                    list.Delete(boat);
                                    Boat sunkboat = null;
                                    if (boat.sunk == true)
                                    {
                                        bool removed = false;
                                        Stack removedBoat = new Stack();
                                        while (port.boats.Count > 0 && !removed)
                                        {
                                            sunkboat = port.boats.Pop();
                                            if (sunkboat.sunk == true) { removedBoat.Push(sunkboat); }
                                            else { removed = true; }
                                        }
                                        while (removedBoat.Count > 0)
                                        {
                                            Boat boat2 = removedBoat.Pop();
                                            port.boats.Push(boat);
                                            list.Add(boat2);
                                        }
                                        port.boats.Push(boat);
                                        list.Add(boat);
                                        if (sunkboat != null) { port.boats.Push(boat); }
                                        return false;
                                    }
                                }
                            }
                        }
                        else { return true; }
                    }
                }
            }
            boats.Push(boat);
            return false;
        }
        public bool Fits(Stack boats, Boat boat, int x, int y)
        {
            Stack stack = new Stack(boats);
            for (int i = 0; i < boats.Count; i++)
            {
                Boat newboat = stack.Pop();
                bool fits = false;
                if (x > newboat.x)
                {
                    if ((newboat.x + newboat.width) <= x) { fits = true; }
                }
                else
                {
                    if ((x + boat.width) <= newboat.x) { fits = true; }
                }
                if (y > newboat.y)
                {
                    if ((newboat.y + newboat.length) <= y) { fits = true; }
                }
                else
                {
                    if ((y + boat.length) <= newboat.y) { fits = true; }
                }
                if (!fits) { return false; }
            }
            return true;
        }

    }
}
