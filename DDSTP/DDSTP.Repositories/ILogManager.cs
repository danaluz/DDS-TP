using System;
using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public interface ILogManager
    {
        void LogSearch(dbDDSTPContext context, User loggedInUser, string filter, TimeSpan timeTaken, int rowsCount);
    }
}