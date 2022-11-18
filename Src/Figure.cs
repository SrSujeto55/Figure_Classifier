using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

        // Clase para definir una figura.
        // una figura tiene color, un grupo y una imagen filtrada
class Figure
{
        // El grupo al que pertenece la figura
    private FigureGroups _Group;

        // El color asociado a la figura [Alpha, Rojo, Azul, Verde]
    private Color _Color;

        // La imagen que contiene únicamente a la figura para su manejo.
    private Bitmap _FilteredImg;

        // Constructor de clase que se encarga de inicializar los atributos
        // de clase.
    public Figure(Bitmap filteredImg, Color color, FigureGroups group)
    {   
        _Group = group;
        _Color = color;
        _FilteredImg = filteredImg;
    }


    public Bitmap GetBitmap()
    {
        return _FilteredImg;
    }

    public Color GetColor()
    {
        return _Color;
    }

    public void SetGroup(FigureGroups group)
    {
        _Group = group;
    }

        // @Override, Método ToString que se encarga de convertir la información asociada
        // de la figura a una cadena de tipo string.
    override public string ToString()
    {
        return _Color.ToString() + ", Class: " +  _Group.ToString();
    }


        // DEPURATION ONLY
        // Permite guardar una versión de la imagen filtrada en la carpeta raiz
    public void SaveImage(int identifier)
    {
        string srt = "FilteredImageNo_" + identifier + ".bmp";
        _FilteredImg.Save(srt);
    }
    
}