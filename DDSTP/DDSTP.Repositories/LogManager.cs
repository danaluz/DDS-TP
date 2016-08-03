using System;
using DDSTP.Data;
using DDSTP.Domain;
using DDSTP.Proxies;

namespace DDSTP.Repositories
{
    public class LogManager : ILogManager
    {
        private readonly IEmailProxy _emailProxy;
        private readonly int _warningOnDelaySecondsGreaterThan;

        public LogManager(IEmailProxy emailProxy, int warningOnDelaySecondsGreaterThan)
        {
            _emailProxy = emailProxy;
            _warningOnDelaySecondsGreaterThan = warningOnDelaySecondsGreaterThan;
        }

        public void LogSearch(dbDDSTPContext context, User loggedInUser, string filter, TimeSpan timeTaken, int rowsCount)
        {
            if (context != null && loggedInUser != null)
            {
                var useReport = new UseReport()
                {
                    UserID = loggedInUser.Id,
                    Filter = filter,
                    ResultsCount = rowsCount,
                    TimeTaken = timeTaken,
                    CreatedAt = DateTime.Now
                };
                context.UseReports.Add(useReport);
                context.SaveChanges();
            }

            if (timeTaken.TotalSeconds > _warningOnDelaySecondsGreaterThan)
            {
                var bodyInfo = string.Format("Filter: \"{0}\", Time Taken: {1} sec., Rows: {2}",
                                                filter,
                                                timeTaken.TotalSeconds,
                                                rowsCount);

                _emailProxy.SendToAdmin("POI's Search delayed", "The POI's search is taking too long. " + bodyInfo);
            }
        }
    }
}
