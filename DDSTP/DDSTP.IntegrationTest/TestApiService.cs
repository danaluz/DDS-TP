using System;
using DDSTP.APIService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class TestApiService
    {
        [TestMethod]
        public void GetAllCommunities_Should_Return_2_Records()
        {
            var communities = new CommunityService();
            var result = communities.GetAllCommunities();

            Assert.IsTrue(result.Count == 2);

        }
    }
}
