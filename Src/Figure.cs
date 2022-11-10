using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;
class Figure
{
    private FigureGroups _Group;
    private Color _Color;
    private int[][] _asociatedMatrix;

    public Figure(FigureGroups group, Color color, int[][] asociatedMatrix)
    {   
        _Group = group;
        _Color = color;
        _asociatedMatrix = asociatedMatrix;
    }
    
}