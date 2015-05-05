using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffplay
{
    class Program
    {
        static void Main(string[] args)
        {
            ffplay player = new ffplay();
            player.main(args);
        }
    }
}
