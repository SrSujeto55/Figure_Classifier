using Xunit;
using System.Drawing;

namespace Src.Tests
{
    /// Prueba el ToString de la clase Figure.
    public class Figure_IsFigureShould
    {
        private Figure _figure;
        public Figure_IsFigureShould()
        {
            _figure = new Figure(null, Color.AliceBlue, FigureGroups.Quadrilateral);
        }

        #region Sample_TestCode
        [Theory]
        [InlineData(0)]
        public void ToStringTest_ShouldFigure(int n)
        {
            String s1 = _figure.ToString();
            String s2 = "Color [AliceBlue], Class: Quadrilateral";
            Assert.True(s1.Equals(s2), "Should equals");
        }
        #endregion

    }
}