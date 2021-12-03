using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajokikoto_PDFFI2
{
    class Write
    {
        public void Choose()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("", Console.ForegroundColor);
            Console.WriteLine("A) Moving boat out.");
            Console.WriteLine("B) Boat add in port.");
            Console.WriteLine("C) Exit.");
        }
        public void NewPlace() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("", Console.ForegroundColor);
            Console.WriteLine("The boat is in a new location."); 
        }
        public void BoatsData() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("", Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The boat datas is (width, length, wheel works, sunk)", Console.ForegroundColor);
            Console.WriteLine("\t INFO: If wheel works then type 0 and if boat is not sunk, type 1.");
        }
        public void Success(bool success)
        {
            if (success == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("", Console.ForegroundColor);
                Console.WriteLine("The boat was successfully put on the port.");
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("", Console.ForegroundColor);
                Console.WriteLine("The boat was unsuccessful put on the port.");
                Console.WriteLine();
            }
        }
        public void Listing(int i, Boat boat)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("", Console.ForegroundColor);
            Console.WriteLine($"{i + 1}. \t {boat.width}, {boat.length}, the wheel is working: {boat.wheelWorks}, the boat sank: {boat.sunk}");
            Console.WriteLine();
        }
        public void ChooseBoat()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("", Console.ForegroundColor);
            Console.WriteLine("Which boat should we move?");
            Console.WriteLine();
        }

    }
}
