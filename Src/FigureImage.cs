using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

class FigureImage
{
    private LinkedList<Figure> _figures;

    public FigureImage()
    {
        _figures = new LinkedList<Figure>();
    }

    public void Add(Figure figure)
    {
        _figures.AddLast(figure);
    }
    
    override public string ToString()
    {
        string s = "";
        foreach (Figure figure in _figures)
        {
            s+= figure.ToString() + "\n";            
        }

        return s;
    }
}