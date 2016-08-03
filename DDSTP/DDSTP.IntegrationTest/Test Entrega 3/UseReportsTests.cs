using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;
using DDSTP.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class UseReportsTests
    {
        [TestMethod]
        public void Test_Search_Summary_Count_By_Date()
        {
            var context = new dbDDSTPContext();

            var repo = new UseReportRepository(context);

            var result = repo.GetSearchCountByDate();

            Console.WriteLine("Fecha: Cantidad Búsquedas");
            foreach (var useReportByDateDto in result)
            {
                if (useReportByDateDto.Date != null)
                    Console.WriteLine(@"{0}: {1}", useReportByDateDto.Date.Value.ToString("yyyy-MM-dd"), useReportByDateDto.Count);
            }
        }
    }
}
