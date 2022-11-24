using Xunit;
using System.Drawing;

namespace Src.Tests
{
    /// Comprueba que la clase Filter filtre correctamente. 
    #pragma warning disable CA1416, xUnit1026
    public class Filter_IsFilterShould
    {   
        private Bitmap _bitmap;

        public Filter_IsFilterShould()
        {   
            String [] arr = Environment.CurrentDirectory.Split("bin");
            string path = arr[0] + @"Utility\example_1.bmp";
            _bitmap = new Bitmap(path);
        }

        #region Sample_TestCode
        [Theory]
        [InlineData(0)]
        public void Test(int n)
        {
            FigureImage list = Filter.FilterImage(_bitmap);
            Figure figure = list.GetFirst();
            figure.SetGroup(FigureGroups.Triangles);
            Color colorFigure = figure.GetColor();
            Color background = _bitmap.GetPixel(0,0);
            Assert.True(!colorFigure.Equals(background));
        }
        #endregion
    }
}