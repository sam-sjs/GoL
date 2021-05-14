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
            
            display.Welcome();

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
    }
}