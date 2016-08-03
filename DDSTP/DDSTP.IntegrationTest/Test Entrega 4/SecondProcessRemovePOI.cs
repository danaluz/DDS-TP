using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;
using DDSTP.Proxies.RemovePOIProxy;
using DDSTP.Repositories;
using DDSTP.Repositories.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class SecondProcessRemovePOI
    {
        [TestMethod]
        public void Test_Delete_POI_From_Service()
        {
            var command = new RemovePOICommand(RemovePOIFactory.Create());
            var commandProcessor = new CommandExecutor();
            commandProcessor.SetCommand(command);
            commandProcessor.Execute();
            
        }


    }
}
