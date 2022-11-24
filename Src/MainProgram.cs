using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

/// <summary>
/// Ejecución del programa, se mandan a llamar al
/// manager que se encarga de controlar el flujo de entrada y la ejecución
/// del programa.
/// </summary>

class MainProgram
{
    static void Main(string[] args)
    {
        Manager manager = new Manager(args);
        manager.Manage();
    }
}
