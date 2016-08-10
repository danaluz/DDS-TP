using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DDSTP.Proxies
{
    public class BankProxyMock : IBankProxy
    {
        public List<BankInfo> Search(string name, string service)
        {
            var result = (from x in MockList()
                where x.banco.Contains(name) && x.servicios.Any(y => y == service)
                select x).ToList();
            return result;
        }

        private List<BankInfo> MockList()
        {
            var bank1 = new BankInfo();
            bank1.banco = "Banco de la Plaza";
            bank1.x = -35.9338322f;
            bank1.y = 72.348353f;
            bank1.sucursal = "Avellaneda";
            bank1.gerente = "Javier Loeschbor";
            bank1.servicios.Add("cobro cheques");
            bank1.servicios.Add("depósitos");
            bank1.servicios.Add("extracciones");
            bank1.servicios.Add("transferencias");
            bank1.servicios.Add("créditos");
            bank1.servicios.Add("");
            bank1.servicios.Add("");
            bank1.servicios.Add("");

            var bank2 = new BankInfo();
            bank2.banco = "Banco de la Plaza";
            bank2.x = -35.934568f;
            bank2.y = 72.34454f;
            bank2.sucursal = "Caballito";
            bank2.gerente = "Fabián Fantaguzzi";
            bank2.servicios.Add("depósitos");
            bank2.servicios.Add("extracciones");
            bank2.servicios.Add("transferencias");
            bank2.servicios.Add("seguros");
            bank2.servicios.Add("");
            bank2.servicios.Add("");
            bank2.servicios.Add("");
            bank2.servicios.Add("");

            var list = new List<BankInfo>();
            list.Add(bank1);
            list.Add(bank2);

            return list;

        }
    }

}

