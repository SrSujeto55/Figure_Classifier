using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Src;

/// <summary>
///  Esta clase se encarga de clasificar una figura en espec�fico asignandole un grupo de los 4 disponibles
/// </summary>
#pragma warning disable CA1416
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
        Bitmap original = figure.GetBitmap();
        Bitmap IMG = (Bitmap)original.Clone();
        // figura, angulo de inicio, angulo final (diferencia debe ser 360)
        int[] figureSignal = RayCasting(figure, 180, 540);
        //LinkedList<int> smoothie = SmoothSignal(figureSignal, 2);
        //int PeaksAgain = GetFigurePeaks(smoothie);
        //Console.WriteLine(PeaksAgain);
        // string s = "[";
        // foreach(int num in smoothie)
        // {
        //     s += num + ", ";
        // }
        // s += "]";
        // Console.WriteLine(s);
        // IMG.Save("FigureAnalized.bmp");
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
    public static int[] RayCasting(Figure figure, int gradini, int gradfin)
    {

        int[] figureSignal = new int[120];

        int[] figureCenter = GetFigureCenter(figure);
        int XCenter = figureCenter[0];
        int YCenter = figureCenter[1];

        Color figureColor = figure.GetColor();
        Bitmap filteredFigure = figure.GetBitmap();

        int hypotenuse = SetAvarageHypo(filteredFigure, figureColor, figureCenter);
        int IND = 0;
        for(int degree = gradini; degree < gradfin; degree += 3)
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

            figureSignal[IND] = RayLength;
            IND++;
        }
        Console.WriteLine(IND);
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

    private static int GetFigurePeaks(LinkedList<int> smoothSignal)
    {
        int[] smoothArr = smoothSignal.ToArray();
        LinkedList<int> peakIndices = new LinkedList<int>();
        int peakIndex = -1;
        int peakValue = -1;
        int baseline = (int)smoothArr.Average();
        Console.WriteLine("Baselina: " + baseline);
        for(int i = 0; i<smoothArr.Length; i++)
        {
            if (smoothArr[i] > baseline)
            {
                if(peakValue == -1 || smoothArr[i] > peakValue)
                {
                    peakValue = smoothArr[i];
                    peakIndex = i;
                }
            }
            else if (peakIndex != -1)
            {
                peakIndices.AddLast(peakIndex);
                peakIndex = -1;
                peakValue = -1;
            }
        }
        if(peakIndex != -1)
        {
            peakIndices.AddLast(peakIndex);
        }
        return peakIndices.Count;
    }

    private static int GetAverage(int[] peaks, int low, int high)
    {
        int sum = 0;

        int total = high-low;

        for(int idx = low; idx <= high; idx++)
        {
            sum += peaks[idx];
        }


        return sum/total;
    }

    private static LinkedList<int> SmoothSignal(int[] peaksArray, int smothie)
    {
        LinkedList<int> smoothSignal = new LinkedList<int>();


        for(int idx = smothie ;idx < peaksArray.Length-smothie; idx++)
        {
            int val = peaksArray[idx];


            smoothSignal.AddLast(GetAverage(peaksArray,idx-smothie,idx+smothie)); 
        }


        return smoothSignal;
    }
}