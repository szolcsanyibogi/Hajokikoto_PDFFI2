using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajokikoto_PDFFI2
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods test = new Methods();
            Write writetest = new Write();
            test.Start(writetest.NewPlace);
        }
    }
}
