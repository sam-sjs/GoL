using Xunit;

namespace GoLTests.Output
{
    public class OutputTests
    {
        [Fact]
        public void WriteLine_ReturnExpected()
        {
            TestOutput output = new TestOutput();
            string expected = "Testing";

            output.WriteLine(expected);

            Assert.Equal(expected, output.Message);
        }

        [Fact]
        public void SetCursorPosition_ReturnsExpected()
        {
            TestOutput output = new TestOutput();
            int expectedX = 3;
            int expectedY = 5;

            output.SetCursorPosition(expectedX, expectedY);

            Assert.Equal(expectedX, output.CursorLeft);
            Assert.Equal(expectedY, output.CursorTop);
        }

        [Fact]
        public void WriteLivingCell_ReturnsExpected()
        {
            TestOutput output = new TestOutput();
            string expected = "██";
            
            output.WriteLivingCell();
            
            Assert.Equal(expected, output.Message);
        }
        
        [Fact]
        public void WriteDeadCell_ReturnsExpected()
        {
            TestOutput output = new TestOutput();
            string expected = "..";
            
            output.WriteDeadCell();
            
            Assert.Equal(expected, output.Message);
        }
    }
}