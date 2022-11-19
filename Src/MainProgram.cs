using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

class MainProgram
{
    static void Main(string[] args)
    {
        Manager manager = new Manager(args);
        manager.Manage();
    }
}
