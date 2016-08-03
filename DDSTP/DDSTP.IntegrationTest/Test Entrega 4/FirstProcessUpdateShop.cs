using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Proxies.RemovePOIProxy;
using DDSTP.Proxies.ShopsProxy;
using DDSTP.Repositories.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class FirstProcessUpdateShop
    {
        [TestMethod]
        public void Test_Update_Shops()
        {
            var command = new UpdateShopsCommand(new ShopProxy());
            var commandProcessor = new CommandExecutor();
            commandProcessor.SetCommand(command);
            commandProcessor.Execute();

        }
    }
}
