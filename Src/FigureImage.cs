using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

        // Clase para guardar e interactuar todas las figuras de una imagen
        //  FigureImage puede agregar, eliminar y clasificar una figura de una imagen.
class FigureImage
{
        // La lista del tipo <Figure> que almacena las figuras.
    private LinkedList<Figure> _figures;

        // Constructor de clase que se encarga de inicializar la lista.
    public FigureImage()
    {
        _figures = new LinkedList<Figure>();
    }
    
        // M�todo encargado de agregar una figura a la lista

        // Param figure: La figura a agregar a la lista
    public void Add(Figure figure)
    {
        _figures.AddLast(figure);
    }
    
        // @Override, m�todo ToString para convertir las figuras a cadena de tipo string

        // return <string> s: La cadena string asociada a la salida del programa.
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