using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajokikoto_PDFFI2
{
    class Port
    {
        public int width { get; set; }
        public int length { get; set; }
        public Stack boats { get; set; }
        public Port(int width, int length)
        {
            this.width = width * 4;
            this.length = length * 8;
            boats = new Stack();
        }
    }
}
