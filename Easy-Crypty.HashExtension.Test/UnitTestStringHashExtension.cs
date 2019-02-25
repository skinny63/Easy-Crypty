using Xunit;

namespace Easy_Crypty.HashExtension.Test
{
    public class UnitTestStringHashExtension
    {
        /// <summary>
        /// test Md5 hash
        /// </summary>
        [Fact]
        public void TestMethodMd5Hash() => Assert.Equal("f9d08276bc85d30d578e8883f3c7e843", "md5hash".Md5Hash());
        
    }
}
