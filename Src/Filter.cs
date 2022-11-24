using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

/// <summary>
/// Clase est�tica que se encarga de filtrar figuras de una im�gen
/// Puede filtrar figuras por color.
/// </summary>
#pragma warning disable CS8625,CA1416
class Filter
{

    /// <summary>
    /// M�todo est�tico encargado de instanciar un objeto de tipo FigureImage donde se
    /// guardar� la informaci�n de cada figura iterada en este mismo m�todo.
    /// </summary>
    /// 
    /// <param name="fullImage"> la im�gen completa (de entrada del programa) </param>
    /// <param name="color"> El color asociado a la figura </param>
    /// <param name="group"> El grupo de clasificaci�n al que pertenece la figura </param>
    /// 
    /// <returns> AllImages, una instancia de FigureImage que guarda todas las figuras de una imagen </returns>
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


    /// <summary>
    /// M�todo est�tico que filtra una figura de una imagen por color
    /// </summary>
    /// 
    /// <param name="fullImage"> la im�gen completa (de entrada del programa) </param>
    /// <param name="FilterColor"> El color en el que se basar� para filtrar una figura de toda la imagen </param>
    /// <param name="BGColor"> El color del fondo de la imagen, para evitar considerar dicho color </param>
    /// 
    /// <returns> filteredImg un Bitmap filtrado con la �nica figura del color especificado </returns>
    private static Bitmap FilterFigure(Bitmap fullImage, Color filterColor, Color BGColor){
        Color tempColor;
        Bitmap filteredImg = (Bitmap)fullImage.Clone();

        for(int x= 0; x<fullImage.Width; x++)
        {
            for(int y=0; y<fullImage.Height; y++)
            {
                tempColor = fullImage.GetPixel(x,y);
                if(!tempColor.Equals(filterColor))
                {
                    filteredImg.SetPixel(x,y,BGColor);
                }
            }
        }
        return filteredImg;
    }
}