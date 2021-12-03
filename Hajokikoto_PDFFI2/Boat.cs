using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajokikoto_PDFFI2
{
    class Boat
    {
        public double width { get; set; }
        public double length { get; set; }
        public bool wheelWorks { get; set; }
        public bool sunk { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Boat(double width, double length, int wheelWorks = 0, int sunk = 0)
        {
            this.width = width;
            this.length = length;
            if (wheelWorks == 0)
            {
                this.wheelWorks = true;
            }
            else if (wheelWorks == 1)
            {
                this.wheelWorks = false;
            }
            else { throw new BoatDataNotGoodException(); }
            if (sunk == 0)
            {
                this.sunk = false;
            }
            else if (sunk == 1)
            {
                this.sunk = true;
            }
            else { throw new BoatDataNotGoodException(); }
        }
    }
}
