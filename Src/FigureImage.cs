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

    /// <value> Constructor de clase que se encarga de inicializar la lista </value>
    public FigureImage()
    {
        _figures = new LinkedList<Figure>();
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

    //DEPURATION ONLY
    // Regresa el inicio de la lista
    public Figure GetFirst()
    {
        return _figures.First();
    }

    // DEPURATION ONLY
    // Regresa el final de la lista.
    public Figure GetLast()
    {
        return _figures.Last();
    }


    /// @Override
    /// <summary>
    /// transforma a string todas las figuras en la lista
    /// </summary>
    /// <returns> string asociado a todas las figuras en la lista </returns> 
    override public string ToString()
    {
        string s = "";
        foreach (Figure figure in _figures)
        {
            s+= figure.ToString() + "\n";            
        }

        return s;
    }

    //Agregar Método Clasificate para clasificar todas las fguras con un foreach.

    // DEPURATION ONLY
    // Guarda una imagen filtrada para cada Figura en la lista
    public void SaveAllImg()
    {
        int i = 0;
        foreach (Figure fig in _figures)
        {
            fig.SaveImage(i);
            i++;
        }
        Console.WriteLine("Done");
    }
}