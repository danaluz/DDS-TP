using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDSTP.Data;
using DDSTP.Proxies;
using DDSTP.Repositories;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void Search_InName()
        {
            //UserRepository.CurrentUserId = 1;

            const int configWarningSeconds = 0;

            var logManager = new LogManager(new EmailProxy(), configWarningSeconds);

            var dbContext = new dbDDSTPContext();

            var userRepo = new UserRepository(dbContext);

            var loggedInUser = userRepo.GetCurrentUser();

            var repo = new POIRepository(dbContext, loggedInUser, logManager);

            var result = repo.Search("Santander");

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void Search_Number()
        {
            //UserRepository.CurrentUserId = 1;
            const int configWarningSeconds = 30;
            var logManager = new LogManager(new EmailProxy(), configWarningSeconds);

            var dbContext = new dbDDSTPContext();

            var userRepo = new UserRepository(dbContext);

            var loggedInUser = userRepo.GetCurrentUser();

            var repo = new POIRepository(dbContext, loggedInUser, logManager);

            var result = repo.Search("114");

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void Search_ServiceCGP()
        {
            //UserRepository.CurrentUserId = 1;
            const int configWarningSeconds = 30;
            var logManager = new LogManager(new EmailProxy(), configWarningSeconds);

            var dbContext = new dbDDSTPContext();

            var userRepo = new UserRepository(dbContext);

            var loggedInUser = userRepo.GetCurrentUser();

            var repo = new POIRepository(dbContext, loggedInUser, logManager);

            var result = repo.Search("asesoramiento");

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void Search_CategoryShop()
        {
            //UserRepository.CurrentUserId = 1;
            const int configWarningSeconds = 30;
            var logManager = new LogManager(new EmailProxy(), configWarningSeconds);

            var dbContext = new dbDDSTPContext();

            var userRepo = new UserRepository(dbContext);

            var loggedInUser = userRepo.GetCurrentUser();

            var repo = new POIRepository(dbContext, loggedInUser, logManager);

            var result = repo.Search("librería");

            Assert.IsTrue(result.Count == 1);
        }

    }
}
