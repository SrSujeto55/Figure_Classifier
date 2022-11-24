using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

/// <summary>
/// Clase para guardar e interactuar todas las figuras de una imagen.
/// FigureImage puede agregar, eliminar y clasificar una figura de una imagen.
/// </summary>
class FigureImage
{
    /// <value> La lista del tipo <Figure> que almacena las figuras </value>
    private LinkedList<Figure> _figures;

    /// <summary>
    /// Constructor de clase, inicializa la lista
    /// </summary>
    public FigureImage()
    {
        _figures = new LinkedList<Figure>();
    }

    /// <summary>
    /// Para cada figura en la lista de figuras, ejecuta su clasificación y queda asignado para 
    /// cada figura
    /// </summary>
    public void Clasificate()
    {
        foreach(Figure fig in _figures){
            FigureClasificator.Clasificate(fig);
        }
    }
    
    /// <summary>
    /// Agrega una figura a la lista
    /// </summary>
    /// 
    /// <param name="figure"> la figura que se agregará </param>
    public void Add(Figure figure)
    {
        _figures.AddLast(figure);
    }

    /// <summary>
    /// regresa la primera figura de la lista de figuras.
    /// </summary>
    /// <returns> regresa la primera figura de la lista de figuras. </returns> 
    public Figure GetFirst()
    {
        return _figures.First();
    }

    /// <summary>
    /// regresa la última figura de la lista de figuras.
    /// </summary>
    /// <returns> regresa la última figura de la lista de figuras. </returns> 
    public Figure GetLast()
    {
        return _figures.Last();
    }

    /// @Override
    /// <summary>
    /// transforma a string todas las figuras en la lista, usando sus respectivos ToString
    /// </summary>
    /// <returns> string asociado a todas las figuras en la lista </returns> 
    override public string ToString()
    {
        string data = "";
        foreach (Figure figure in _figures)
        {
            data+= figure.ToString() + "\n";            
        }

        return data;
    }
}