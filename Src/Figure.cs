using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

/// <summary>
/// Clase para definir una figura.
/// Una figura tiene color, un grupo y una imagen filtrada
/// </summary>

class Figure
{
    /// <value> El grupo al que pertenece la figura </value>
    private FigureGroups _Group;

    /// <value> El color asociado a la figura [Alpha, Rojo, Azul, Verde] </value>
    private Color _Color;

    /// <value> La imagen que contiene �nicamente a la figura para su manejo </value>
    private Bitmap _FilteredImg;


    /// <summary>
    /// Constructor de clase que se encarga de inicializar los atributos
    /// de clase.
    /// </summary>
    /// 
    /// <param name="filteredImg"> La imagen Filtrada que contiene unicamente la figura </param>
    /// <param name="color"> El color asociado a la figura </param>
    /// <param name="group"> El grupo de clasificaci�n al que pertenece la figura </param>
    public Figure(Bitmap filteredImg, Color color, FigureGroups group)
    {
        _Group = group;
        _Color = color;
        _FilteredImg = filteredImg;
    }

    /// <returns>
    /// Regresa el Bitmap asociado a la figura
    /// </returns>

    public Bitmap GetBitmap()
    {
        return _FilteredImg;
    }


    /// <returns>
    /// Regresa el Color asociado a la figura
    /// </returns>
    public Color GetColor()
    {
        return _Color;
    }

    /// <summary>
    /// Asocia un grupo a la figura
    /// </summary>
    /// 
    /// <param name="group"> El grupo que se le asociar� a la figura</param>
    public void SetGroup(FigureGroups group)
    {
        _Group = group;
    }

    /// @override
    /// <summary>
    /// Convierte a tipo string la informaci�n importante de la figura tales como
    /// El color
    /// La clasificaci�n 
    /// </summary>
    /// <returns> string asociado a la figura con la informaci�n m�s relevante </returns> 
    override public string ToString()
    {
        return AuxColor(_Color) + " = " + AuxEnum(_Group.ToString());
    }

    private static string AuxEnum(String group)
    {
        Dictionary<string, string> options = new Dictionary<string, string>();
        options.Add("Quadrilateral", "C");
        options.Add("Triangles", "T");
        options.Add("Circles", "O");
        options.Add("Others", "X");
        string option = options[group];
        options.Clear();
        return option;
    }

    private static string AuxColor(Color color)
    {
        string hex = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        return hex;
    }

    // DEPURATION ONLY
    // Permite guardar una versi�n de la imagen filtrada en la carpeta raiz
    public void SaveImage(int identifier)
    {
        string srt = "FilteredImageNo_" + identifier + ".bmp";
        _FilteredImg.Save(srt);
    }

}