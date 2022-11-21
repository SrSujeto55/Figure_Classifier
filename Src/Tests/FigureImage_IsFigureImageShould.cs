using Xunit;
using System.Drawing;

namespace Src.Tests
{
    /// Prueba el ToString de la clase FigureImage.
    public class FigureImage_IsFigureImageShould
    {
        private FigureImage _list;
        public FigureImage_IsFigureImageShould()
        {
            _list = new FigureImage();
        }

        #region Sample_TestCode
        [Theory]
        [InlineData(0)]
        public void ToString_TestFigureImageShould(int n)
        {
            _list.Add(new Figure(null, Color.Blue, FigureGroups.Circles));
            _list.Add(new Figure(null, Color.Red, FigureGroups.Triangles));
            _list.Add(new Figure(null, Color.Orange, FigureGroups.Others));
            String s1 = $"Color [Blue], Class: Circles{Environment.NewLine}" +
                        $"Color [Red], Class: Triangles{Environment.NewLine}" + 
                        $"Color [Orange], Class: Others{Environment.NewLine}"; 
            String s2 = _list.ToString();
            Assert.True(s1.Equals(s1), "Should Equals");
        }
        #endregion

    }
}