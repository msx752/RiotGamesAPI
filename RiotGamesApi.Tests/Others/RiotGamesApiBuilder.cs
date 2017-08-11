using Xunit;

namespace RiotGamesApi.Tests.Others
{
    public class RiotGamesApiBuilder : BaseTestClass
    {
        [Fact]
        public void ApiToStaticClass()
        {
            //RiotGamesApi.LolApi auto cs generetor
            //after api developing use this method and change LolApi.cs with output
            string output = Extension5.GenerateLolApiClass();
        }
    }
}