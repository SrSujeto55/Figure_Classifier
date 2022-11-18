using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Src;

class FigureClasificator
{
     public static void Clasificate(Figure figure)
    {
        int[] center = GetFigureCenter(figure);

    }


    // bitmap solo tentativo
    private static int[] GetFigureCenter(Figure figure)
    {

        Bitmap figureBitmap = (Bitmap)figure.GetBitmap().Clone();

        Color bgColor = figureBitmap.GetPixel(0,0);

        Color figureColor = figure.GetColor();

        int[] centerCoords = new int[2];

        centerCoords[0] = 0;
        centerCoords[1] = 0;

        int pixels = 0;
        
        for(int x = 0; x < figureBitmap.Width; x++)
        {
            for(int y = 0; y < figureBitmap.Height; y++)
            {
                Color pixelColor = figureBitmap.GetPixel(x,y);

                if (pixelColor.Equals(figureColor))
                {
                    centerCoords[0] += x;
                    centerCoords[1] += y;
                    pixels++;
                }
            }
        }

        centerCoords[0] /= pixels;
        centerCoords[1] /= pixels;

        figureBitmap.SetPixel(centerCoords[0], centerCoords[1], Color.FromName("Red"));

        figureBitmap.Save("ExampleCenter.bmp");

       return centerCoords;

    }
    
}