using Xunit;
using AspNetCoreWebService.Controllers;

namespace AspNetCoreWebServiceTest.Controllers
{
    public class HelloControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = (ViewResult) controller.Index();
            Assert.Single(result.ViewData);
            Assert.Equal("You just created a ASP.Net Core web application!", result.ViewData["Message"]);
        }

        [Theory]
        [InlineData(null, "Hello !")]
        [InlineData("", "Hello !")]
        [InlineData("AWS CodeStar", "Hello AWS CodeStar!")]
        public void InputParamGetResponseTest(string inputValue, string expectedOutput)
        {
            HelloController controller = new HelloController();
            var response = controller.Get(inputValue).Value as Response;
            Assert.Equal(expectedOutput, response.Output);
        }

        [Fact]
        public void NoInputParamPostResponseTest()
        {
            HelloController controller = new HelloController();
            var response = controller.Post().Value as Response;
            Assert.Equal("Hello World!", response.Output);
        }

        [Theory]
        [InlineData(null, "Hello !")]
        [InlineData("", "Hello !")]
        [InlineData("AWS CodeStar", "Hello AWS CodeStar!")]
        public void InputParamPostResponseTest(string inputValue, string expectedOutput)
        {
            HelloController controller = new HelloController();
            var response = controller.Post(inputValue).Value as Response;
            Assert.Equal(expectedOutput, response.Output);
        }
    }
}
