using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

        // Clase est�tica que se encarga de filtrar figuras de una im�gen
        // Puede filtrar figuras por color.
class Filter
{

        // M�todo est�tico encargado de instanciar un objeto de tipo FigureImage donde se
        // guardar� la informaci�n de cada figura iterada en este mismo m�todo.

        // param fullImage: la im�gen completa (de entrada del programa)

        // returns <FigureImage> AllImages: la instancia de FigureImage que guarda todas las figuras en una imagen.
    public static FigureImage FilterImage(Bitmap fullImage)
    {
        FigureImage AllImages = new FigureImage();
        Color tempColor;
        Color BGColor = fullImage.GetPixel(0,0);
        HashSet<Color> figureColors = new HashSet<Color>();

        for(int x = 0; x< fullImage.Width; x++)
        {
            for(int y = 0; y< fullImage.Height; y++)
            {
                tempColor = fullImage.GetPixel(x,y);
                if(!tempColor.Equals(BGColor) && !figureColors.Contains(tempColor))
                {
                    figureColors.Add(tempColor);
                }
            }
        }
        
        foreach(Color color in figureColors)
        {
            Bitmap imgFilteredByColor = FilterFigure(fullImage, color, BGColor);
            Figure colorFigure = new Figure(imgFilteredByColor, color, FigureGroups.Null);
            AllImages.Add(colorFigure);
        }

        return AllImages;
    }

        // M�todo est�tico que filtra una figura de una imagen por color

        // param fullImage: la im�gen completa (de entrada del programa)
        // param FilterColor: El color en el que se basar� para filtrar una figura de toda la imagen.
        // param BGColor: El color del fondo de la imagen, para evitar considerar dicho color.

        // returns <Bitmap> la imagen filtrada con la �nica figura del color especificado.
    private static Bitmap FilterFigure(Bitmap fullImage, Color FilterColor, Color BGColor){
        Color tempColor;

        for(int x= 0; x<fullImage.Width; x++)
        {
            for(int y=0; y<fullImage.Height; y++)
            {
                tempColor = fullImage.GetPixel(x,y);
                if(!tempColor.Equals(FilterColor) && !tempColor.Equals(BGColor))
                {
                    fullImage.SetPixel(x,y,BGColor);
                }
            }
        }
        return fullImage;
    }
}