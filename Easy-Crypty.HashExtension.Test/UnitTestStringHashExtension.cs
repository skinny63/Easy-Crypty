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

        /// <summary>
        /// test Sha256 hash
        /// </summary>
        [Fact]
        public void TestMethodSha256Hash() => Assert.Equal("d7fc5162511d42d22462ad5b4c716b73903a677806119f9ad0314763ccd719ca", "sha256hash".Sha256Hash());

        /// <summary>
        /// test Sha384 hash
        /// </summary>
        [Fact]
        public void TestMethodSha384Hash() => Assert.Equal("e99e181623fa6b45e6eb97ab8015380cec90ec081c398f857a3c6b7f8b97718256d9856ccc1e77c9012278c3457d698d", "sha384hash".Sha384Hash());

        /// <summary>
        /// test Sha512 hash
        /// </summary>
        [Fact]
        public void TestMethodSha512Hash() => Assert.Equal("6900eddde41707d46e03c50c49ed9c3d60e595943c7dc6934c693b20e74744f57da1c08892aa53e3c53b86fd2763675b5e3a0c56411c01be1337368137cb8e49", "sha512hash".Sha512Hash());
    }
}
