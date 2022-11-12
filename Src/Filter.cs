using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

class Filter
{
    public static Image FilterImage(Bitmap fullImage)
    {
        Image AllImages = new Image();
        Color tempColor;
        Color BGColor = fullImage.GetPixel(0,0);
        set FigureColors = new set();

        for(int x = 0; x<Width; x++)
        {
            for(int y = 0; y<Height; y++)
            {
                tempColor = fullImage.GetPixel(x,y);
                if(!tempColor.Equals(BGColor) && tempColor.isNotInSet())
                {
                    FigureColors.add(tempColor);
                }
            }
        }
        
        foreach(Color in FigureColors)
        {
            Bitmap Filttered = FilterByColor(fullImage, Color, BGColor);
            Figure figure = new Figure(Filtered, Color, FigureGroups.NONE);
            AllImages.add(figure);
        }

        return AllImages;
    }


    private Bitmap FilterFigure(Bitmap fullImage, Color FilterColor, Color BGColor){
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