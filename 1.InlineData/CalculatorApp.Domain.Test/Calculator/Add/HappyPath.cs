using Xunit;
using CalculatorApp.Domain;
using System;

namespace CalculatorApp.Domain.Test.Calculator.Add
{
    public class HappyPath{
        private readonly CalculatorApp.Domain.Calculator _sut = new CalculatorApp.Domain.Calculator();
        
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,3,5)]
        [InlineData(10,30,40)]
        [InlineData(-5,5,0)]
        public void Adding_TwoIntegers_ReturnsExpectedSum(int a, int b, int expectedSum)
        {
            //Act
            var actual = _sut.Add(a, b);

            //Assert
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData(1073741024,1073742624)]
        public void Adding_TwoIntegersThatCauseOverflow_ShouldThrowOverflowException(int a, int b)
        {
            //Act
            //Assert
            Assert.Throws<OverflowException>(() => _sut.Add(a, b));
        }

        // [Fact]
        // public void Adding_1To1_Returns2()
        // {
        //     //Arrange
        //     var a = 1;
        //     var b = 1;
        //     var expected = 2;

        //     //Act
        //     var actual = _sut.Add(a, b);

        //     //Assert
        //     Assert.Equal(expected, actual);
        // }

        // [Fact]
        // public void Adding_2To3_Returns5()
        // {
        //     //Arrange
        //     var a = 2;
        //     var b = 3;
        //     var expected = 5;

        //     //Act
        //     var actual = _sut.Add(a, b);

        //     //Assert
        //     Assert.Equal(expected, actual);
        // }
    }
}