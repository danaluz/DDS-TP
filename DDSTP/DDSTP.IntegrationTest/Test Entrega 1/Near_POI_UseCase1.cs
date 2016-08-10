using DDSTP.Data;
using DDSTP.Proxies;
using DDSTP.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class Near_POI_UseCase1
    {
        [TestMethod]
        public void Consultar_Disponibilidad_Punto_de_Interés()
        {
            const int configWarningSeconds = 30;
            var logManager = new LogManager(new EmailProxy(), configWarningSeconds);

            var dbContext = new dbDDSTPContext();

            var userRepo = new UserRepository(dbContext);

            var loggedInUser = userRepo.GetCurrentUser();

            var repo = new POIRepository(dbContext, loggedInUser, logManager);

            var result = repo.SearchNear(-34.593942f, -58.412321f);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
