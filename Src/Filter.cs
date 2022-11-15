using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

class Filter
{
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