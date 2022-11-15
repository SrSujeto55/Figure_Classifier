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
    private Bitmap _FilteredImg;

    public Figure(Bitmap filteredImg, Color color, FigureGroups group)
    {   
        _Group = group;
        _Color = color;
        _FilteredImg = filteredImg;
    }

    // Todo: Agregar + _Group.ToString() junto con el método en la enumeración.
    override public string ToString()
    {
        return _Color.ToString();
    }
    
}