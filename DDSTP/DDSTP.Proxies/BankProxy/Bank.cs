using System.Collections.Generic;

namespace DDSTP.Proxies
{
    public class Bank
    {
        public Bank()
        {
            servicios = new List<string>();
        }
        public string banco { get; set; }
        public float x { get; set; }      
        public float y { get; set; }
        public string sucursal { get; set; }
        public string gerente { get; set; }
        public List<string> servicios { get; set; }
    }
}
