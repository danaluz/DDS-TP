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

        [TestMethod]
        public void Test_Search_Partial_Count_By_Terminal()
        {
            var context = new dbDDSTPContext();

            var repo = new UseReportRepository(context);

            var repoUser = new UserRepository(context);

            var result = repo.GetPartialSearchCountByTerminal(1);
            var userName = repoUser.GetById(1).Name;

            Console.WriteLine("Cantidad de Resultados Parciales");
            Console.WriteLine(@"{0}", userName.ToString());
            foreach (var useReportByTerminal in result)
            {
                if (useReportByTerminal != null)
                    Console.WriteLine(@"{0}", useReportByTerminal.Count);
            }
        }

        [TestMethod]
        public void Test_Search_Summary_Count_By_Terminal()
        {
            var context = new dbDDSTPContext();

            var repo = new UseReportRepository(context);

            var result = repo.GetSummarySearchCountByTerminal();


            Console.WriteLine("Usuario: Cantidad de Resultados Totales");

            foreach (var useReportByTerminal in result)
            {
                if (useReportByTerminal != null)
                    Console.WriteLine(@"{0}: {1}", useReportByTerminal.UserName, useReportByTerminal.Count);
            }
        }
    }
}