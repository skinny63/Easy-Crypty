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
        
        /// <summary>
        /// test Blake2b-512 hash
        /// </summary>
        [Fact]
        public void TestMethodBlake2b_512Hash() => Assert.Equal("46695df31ca5449cd6e78403652f9a7d69000d89d700ba644c4b4299e467c6f005f45175e643e1f4301d24b1429d0902deb5f6424593328cd308388c19b9aec9", "blake2bhash".Blake2b_512Hash());

        /// <summary>
        /// test Sha1 hash
        /// </summary>
        [Fact]
        public void TestMethodSha1Hash() => Assert.Equal("2ef988b46b0a48b54f9a4ce4619e5fb69205cf74", "sha1hash".Sha1Hash());
    }
}
