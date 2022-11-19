using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Src;

/// <summary>
///  Esta clase se encarga de clasificar una figura en espec�fico asignandole un grupo de los 4 disponibles
/// </summary>

class FigureClasificator
{
    /// <summary>
    /// Este m�todo se encarga de llamar a los algoritmos auxiliares encargados de 
    /// asignar toda la l�gica detr�s de clasificar una figura, al final se le asigna
    /// dicha clasificaci�n como atributo de la figura en cuesti�n
    /// </summary>
    /// 
    /// <param name="figure"> la figura que se clasificar� </param>

    public static void Clasificate(Figure figure)
    {
        int[] figureSignal = RayCasting(figure);
        // Llama a calcularPicos(int [] Signal) Retruns: FigureGroup
        // asignamos el figure grupo a la figura con setFigureGroup
    }

    /// <summary>
    /// M�todo privado est�tico encargado de evaluar la distancia que existe entre el centro de la figura
    /// hasta chocar con un borde de la misma, realiza este proceso radialmente hasta cubrir por completo
    /// toda la figura.
    /// </summary>
    ///
    /// <param name="figure"> la figura de la que se evaluar� la distancia del centro a los bordes </param>
    ///
    /// <returns> figureSignal, un arreglo con la distancia registada de cada uno de los rayos en la figura</returns>
    public static int[] RayCasting(Figure figure)
    {
        //DEPURATION
        int AngleOfRay = 360;

        int[] figureSignal = new int[AngleOfRay];

        int[] figureCenter = GetFigureCenter(figure);
        int XCenter = figureCenter[0];
        int YCenter = figureCenter[1];

        Color figureColor = figure.GetColor();
        Bitmap filteredFigure = figure.GetBitmap();

        int hypotenuse = SetAvarageHypo(filteredFigure, figureColor, figureCenter);

        for(int degree = 0; degree < AngleOfRay; degree++)
        {
            double radVersion = degree*(Math.PI/180);

            double unitX = Math.Cos(radVersion)*hypotenuse;
            double unitY = Math.Sin(radVersion)*hypotenuse;

            unitX = XCenter + unitX;
            unitY = YCenter + unitY;

            double dx = XCenter - unitX;
            double dy = YCenter - unitY;

            int stepsNumber = Math.Max(Math.Abs((int)dx), Math.Abs((int)dy));

            double XCoord = XCenter;
            double YCoord = YCenter;

            bool thresholdReached = false;
            int RayLength = 1;

            while (!thresholdReached)
            {
                YCoord += dy/stepsNumber;
                XCoord += dx/stepsNumber;

                if(!filteredFigure.GetPixel((int)Math.Floor(XCoord), (int)Math.Floor(YCoord)).Equals(figureColor))
                {
                    thresholdReached = true;
                    break;
                }
                RayLength++;
            }
            figureSignal[degree] = RayLength;
        }
        return figureSignal;
    }

    /// <summary>
    /// M�todo privado est�tico encargado de asignar una hipotenusa adecuada para realizar c�lculos 
    /// en funci�n del tama�o de una <c>figura</c>.
    /// </summary>
    /// 
    /// <param name="filteredImg"> la imagen filtrada con �nicamente la figura a tratar </param>
    /// <param name="figureColor"> El color de la figura a tratar </param>
    /// <param name="figureCenter"> EL centro en coordenadas de la figura a tratar </param>
    /// 
    /// <returns> Hypotenuse, un entero representante de la hipotenusa </returns>

    private static int SetAvarageHypo(Bitmap filteredImg, Color figureColor, int[] figureCenter)
    {
        bool fuera = false;
        int Hypotenuse = 0;
        int i = 0;

        while (!fuera)
        {
            if (!filteredImg.GetPixel(figureCenter[0] + i, figureCenter[1]).Equals(figureColor))
            {
                fuera = true;
            }
            i++;
            Hypotenuse++;
        }

        return Hypotenuse/2;
    }


    /// <summary>
    /// M�todo privado est�tico encargado de encontrar el centro de una figura
    /// </summary>
    /// 
    /// <param name="figure"> la figura que se clasificar� </param>
    /// 
    /// <returns> centerCoords, un arreglo con las coordenadas del centro de la figura</returns>
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

       return centerCoords;
    }
    
}