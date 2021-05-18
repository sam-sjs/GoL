using System;
using GoL;
using Xunit;

namespace GoLTests
{
    public class DisplayTests
    {
        [Fact]
        public void DisplayWelcome_ShouldHaveCorrectMessage()
        {
            string message = "Welcome to Game of Life!";
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            
            display.WelcomeMessage();

            Assert.Equal(message, output.Message);
        }
        
        [Fact]
        public void DisplayEnterHeight_ShouldHaveCorrectMessage()
        {
            string message = "Enter a world height:";
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            
            display.EnterHeight();

            Assert.Equal(message, output.Message);
        }
        
        [Fact]
        public void DisplayEnterWidth_ShouldHaveCorrectMessage()
        {
            string message = "Enter a world width:";
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            
            display.EnterWidth();

            Assert.Equal(message, output.Message);
        }

        [Fact]
        public void DisplaySetInitialState_ShouldHaveCorrectMessage()
        {
            string message = "Set initial world state ([arrows] to move, [space] to set, [enter] to start game:";
            TestOutput output = new TestOutput();
            Display display = new Display(output);

            display.SetInitialState();
            
            Assert.Equal(message, output.Message);
        }

        [Fact]
        public void DisplayWorld_ShouldShowAnEmptyRepresentationOfTheWorld()
        {   // Add test for populated world - will I have to use Populate() for this?
            World world = new World(5, 5);
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            string message = "\n\n\n\n";

            display.World(world);
            
            Assert.Equal(message, output.Message);
        }
        
        [Fact]
        public void DisplayInvalidInput_ShouldHaveCorrectMessage()
        {
            string message = "Invalid input - please try again:";
            TestOutput output = new TestOutput();
            Display display = new Display(output);

            display.InvalidInput();
            
            Assert.Equal(message, output.Message);
        }

        [Theory]
        [InlineData(ConsoleKey.UpArrow, 2, 1)]
        [InlineData(ConsoleKey.DownArrow, 2, 3)]
        [InlineData(ConsoleKey.LeftArrow, 1, 2)]
        [InlineData(ConsoleKey.RightArrow, 3, 2)]
        public void MoveCursor_ShouldMoveCursorInGivenDirection(ConsoleKey input, int expectedLeft, int expectedTop)
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            output.SetCursorPosition(2, 2);
            
            display.MoveCursor(input);
            int actualLeft = output.CursorLeft;
            int actualTop = output.CursorTop;
            
            Assert.Equal(expectedLeft, actualLeft);
            Assert.Equal(expectedTop, actualTop);
        }

        [Fact]
        public void Clear_ShouldRemoveAllMessagesFromDisplay()
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            output.Message = "Test message to be cleared";
            string expected = "";
            
            display.Clear();
            
            Assert.Equal(expected, output.Message);
        }

        [Fact]
        public void ResetCursorPosition_ShouldSetTheCursorTo00()
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            output.CursorLeft = 5;
            output.CursorTop = 3;
            int expected = 0;

            display.ResetCursorPosition();
            int actualLeft = output.CursorLeft;
            int actualTop = output.CursorTop;
            
            Assert.Equal(expected, actualLeft);
            Assert.Equal(expected, actualTop);
        }

        [Fact]
        public void GetCursorPosition_ShouldReturnCurrentCursorLocation()
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            output.CursorLeft = 3;
            output.CursorTop = 2;
            WorldLocation expected = new WorldLocation(3, 2);

            WorldLocation actual = display.GetCursorPosition();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RefreshWorld_ShouldPlaceCursorInSamePositionAfterRefresh()
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            World world = new World(5, 5);
            output.CursorLeft = 3;
            output.CursorTop = 2;
            
            display.RefreshWorld(world);
            
            Assert.True(output.CursorLeft == 3);
            Assert.True(output.CursorTop == 2);
        }
    }
}