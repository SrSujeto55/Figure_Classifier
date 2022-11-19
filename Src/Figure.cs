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

    /// <value> La imagen que contiene únicamente a la figura para su manejo </value>
    private Bitmap _FilteredImg;


    /// <summary>
    /// Constructor de clase que se encarga de inicializar los atributos
    /// de clase.
    /// </summary>
    /// 
    /// <param name="filteredImg"> La imagen Filtrada que contiene unicamente la figura </param>
    /// <param name="color"> El color asociado a la figura </param>
    /// <param name="group"> El grupo de clasificación al que pertenece la figura </param>
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
    /// <param name="group"> El grupo que se le asociará a la figura</param>
    public void SetGroup(FigureGroups group)
    {
        _Group = group;
    }

    /// @override
    /// <summary>
    /// Convierte a tipo string la información importante de la figura tales como
    /// El color
    /// La clasificación 
    /// </summary>
    /// <returns> string asociado a la figura con la información más relevante </returns> 
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