using Xunit;

namespace RiotGamesApi.Tests.Others
{
    public class RiotGamesApiBuilder : BaseTestClass
    {
        [Fact]
        public void ApiToStaticClass()
        {
            //RiotGamesApi.AspNetCore.Api auto cs generetor
            //after api developing use this method and change Api.cs with output
            string output = Extension5.GenerateApiClass();
        }
    }
}