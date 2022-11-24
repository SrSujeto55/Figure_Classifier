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
        Bitmap originalImage = figure.GetBitmap();
        int[] figureSignal = RayCasting(figure, 90, 450);

        int Smoother = originalImage.Width < 120 ? 8 : 15;

        LinkedList<int> smootherSignal = SmoothSignal(figureSignal, Smoother);

        int [] ARRSmoothSignal = smootherSignal.ToArray();
        Array.Sort(ARRSmoothSignal);

        if(IsCircle(ARRSmoothSignal)){
            figure.SetGroup(FigureGroups.Circles);
            return;
        }
        
        int numberOfPeaks = GetFigurePeaks(smootherSignal);
        figure.SetGroup(GetFigureGroup(numberOfPeaks));
    }

    /// <summary>
    /// Obtenemos el grupo al que pertenece la figura en función del número de 
    /// picos registrados.
    /// </summary>
    /// 
    /// <param name="peakNumber"> El número de picos registrados </param>
    /// <return> El grupo al que pertenece la figura </return>
    private static FigureGroups GetFigureGroup(int peakNumber)
    {
        if(peakNumber <= 3)
            return FigureGroups.Triangles;
        if(peakNumber == 4 || peakNumber == 5)
            return FigureGroups.Quadrilateral;
        return FigureGroups.Others;
    }

    /// <summary>
    /// Revisamos la señal recibida, si el valor máxima y mínima de ésta
    /// resulta ser menor a 8, entonces se trata de un círculo.
    /// </summary>
    /// 
    /// <param name="sortedSignal"> La señal ordenada </param>
    /// <return> Si la señal se atribuye a un círculo </return>
    private static bool IsCircle(int[] sortedSignal)
    {
        int max = sortedSignal[sortedSignal.Length-1];
        int min = sortedSignal[0];
        
        return (max-min) < 8;
    }

    /// <summary>
    /// M�todo privado est�tico encargado de evaluar la distancia que existe entre el centro de la figura
    /// hasta chocar con un borde de la misma, realiza este proceso radialmente hasta cubrir por completo
    /// toda la figura.
    /// </summary>
    ///
    /// <param name="figure"> la figura de la que se evaluar� la distancia del centro a los bordes </param>
    /// <param name="gradIni"> El ángulo donde empezamos a lanzar rayos </param>
    /// <param name="gradFin"> El ángulo final donde paramos de lanzar rayos (la diferencia con gradIni debe ser 360) </param>
    /// <returns> figureSignal, un arreglo con la distancia registada de cada uno de los rayos en la figura</returns>
    public static int[] RayCasting(Figure figure, int gradIni, int gradFin)
    {
        int[] figureSignal = new int[360];

        int[] figureCenter = GetFigureCenter(figure);
        int XCenter = figureCenter[0];
        int YCenter = figureCenter[1];

        Color figureColor = figure.GetColor();
        Bitmap filteredFigure = figure.GetBitmap();

        int hypotenuse = 4;
        int index = 0;
        for(int degree = gradIni; degree < gradFin; degree += 1)
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

                if(!filteredFigure.GetPixel((int)Math.Ceiling(XCoord), (int)Math.Ceiling(YCoord)).Equals(figureColor))
                {
                    thresholdReached = true;
                    break;
                }
                RayLength++;
            }

            figureSignal[index] = RayLength;
            index++;
        }
        return figureSignal;
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
        int figurePixels = 0;

        centerCoords[0] = 0;
        centerCoords[1] = 0;;
        
        for(int x = 0; x < figureBitmap.Width; x++)
        {
            for(int y = 0; y < figureBitmap.Height; y++)
            {
                Color pixelColor = figureBitmap.GetPixel(x,y);

                if (pixelColor.Equals(figureColor))
                {
                    centerCoords[0] += x;
                    centerCoords[1] += y;
                    figurePixels++;
                }
            }
        }

        centerCoords[0] /= figurePixels;
        centerCoords[1] /= figurePixels;

       return centerCoords;
    }

    /// <summary>
    /// Obtenemos el número de picos máximos que encontremos 
    /// dentro de una señal suavizada.
    /// </summary>
    /// 
    /// <param name="smoothSignal"> La señal suavizada a trabajar</param>
    /// <return> numberPeaks, el número de picos máximos registrados </return>
    private static int GetFigurePeaks(LinkedList<int> smoothSignal)
    {
        int[] arrSmoothSignal = smoothSignal.ToArray();
        int Baseline = (int)arrSmoothSignal.Average();
        int numberPeaks = 0;
        bool isAcending = false;

        for(int i = 1; i< arrSmoothSignal.Length-1; i++)
        {
            int LasDelta = arrSmoothSignal[i] - arrSmoothSignal[i-1];
            int DeltaInFront = arrSmoothSignal[i+1] - arrSmoothSignal[i];
            if (LasDelta > 0)
                isAcending = true;
            if (LasDelta < 0)
                isAcending = false;
            if (arrSmoothSignal[i] < Baseline)
                continue;
            if ((LasDelta > 0 && DeltaInFront < 0) || (LasDelta == 0 && DeltaInFront < 0) && isAcending)
            {
                numberPeaks++;
                isAcending = false;
            }
        }
        if (isAcending)
            numberPeaks++;

        return numberPeaks;
    }

    /// <summary>
    /// Método auxiliar para calcular un promedio entre un intervalo de un arreglo
    /// </summary>
    /// 
    /// <param name="partialSignal"> El intervalo donde vamos a promediar </param>
    /// <param name="start"> el índice de inicio, inicio del subArreglo </param>
    /// <param name="finish"> el índice final, límite del subArreglo </param>
    /// <return> promedio del subarreglo </return>
    private static int GetAverage(int[] partialSignal, int start, int finish)
    {
        int sum = 0;

        int total = finish-start;

        for(int idx = start; idx <= finish; idx++)
        {
            sum += partialSignal[idx];
        }


        return sum/total;
    }

    /// <summary>
    /// Suaviza una señal promediando intervalos
    /// </summary>
    /// 
    /// <param name="signal"> Un arreglo, la señal recibida </param>
    /// <param name="range"> el rango de cuantos valores frente y detrás consideraremos para el promedio </param>
    /// <return> smoothSignal, la señal suavizada </return>
    private static LinkedList<int> SmoothSignal(int[] signal, int range)
    {
        LinkedList<int> smoothSignal = new LinkedList<int>();

        for(int idx = range ;idx < signal.Length-range; idx++)
        {
            int val = signal[idx];
            smoothSignal.AddLast(GetAverage(signal,idx-range,idx+range)); 
        }

        return smoothSignal;
    }
}