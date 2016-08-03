using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class UseReportRepository
    {
        private readonly dbDDSTPContext context;

        public UseReportRepository(dbDDSTPContext context)
        {
            this.context = context;
        }

        public List<UseReportByDateDto> GetSearchCountByDate()
        {
            var result = (from x in context.UseReports
                          where x.User.UserType == UserType.Terminal
                          group x by EntityFunctions.TruncateTime(x.CreatedAt) into g
                            select new UseReportByDateDto()
                            {
                                Date = g.Key, //x.CreatedAt.Date
                                Count = g.Count()
                            }).ToList();

            return result;
        }

        public List<UseReportPartialByTerminalDto> GetPartialSearchCountByTerminal(int userTerminalId)
        {
            var result = (from x in context.UseReports
                          where x.UserID == userTerminalId && x.User.UserType == UserType.Terminal
                            select new UseReportPartialByTerminalDto()
                            {
                                Count = x.ResultsCount
                            }).ToList();

            return result;
        }

        public List<UseReportByTerminalDto> GetSummarySearchCountByTerminal()
        {
            var result = (from x in context.UseReports
                          where x.User.UserType == UserType.Terminal
                          group x by x.UserID into g
                            select new UseReportByTerminalDto()
                            {
                                UserId = g.Key,
                                UserName = g.First().User.Name,
                                Count = g.Sum(y=>y.ResultsCount)
                            }).ToList();

            return result;
        }   
    }

    public class UseReportPartialByTerminalDto
    {
        public int Count { get; set; }
    }

    public class UseReportByDateDto
    {
        public DateTime? Date { get; set; }
        public int Count { get; set; }
    }

    public class UseReportByTerminalDto
    {
        public int Count { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
