using DDSTP.Data;
using DDSTP.Proxies;
using DDSTP.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class Search_POI_UseCase2
    {
        [TestMethod]
        public void Busqueda_POIS_por_Texto_y_Cercania()
        {
            const int configWarningSeconds = 30;
            var logManager = new LogManager(new EmailProxy(), configWarningSeconds);

            var dbContext = new dbDDSTPContext();

            var userRepo = new UserRepository(dbContext);

            var loggedInUser = userRepo.GetCurrentUser();

            var repo = new POIRepository(dbContext, loggedInUser, logManager);

            var result = repo.Search("114",-34.593942f, -58.412321f);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
