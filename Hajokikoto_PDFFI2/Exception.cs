using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajokikoto_PDFFI2
{
    class TakeOutException : Exception
    {
        public TakeOutException()
            : base("The boat has sunk and cannot be moved.") { }
    }
    class BoatDataNotGoodException : Exception
    {
        public BoatDataNotGoodException()
            : base("The boat data don't match.") { }
    }
    class LocationException : Exception
    {
        public LinkedList boats { get; set; }
        public LocationException(LinkedList list)
            : base("It is not possible to put the ship in port.") { boats = list; }
    }
    class PortFullException : Exception
    {
        public PortFullException()
            : base("The port is full.") { }
    }
    class PortEmptyException : Exception
    {
        public PortEmptyException()
            : base("The port is empty.") { }
    }
}
