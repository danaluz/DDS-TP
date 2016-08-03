using System;
using System.Collections.Generic;
using System.Linq;

namespace DDSTP.Proxies.ShopsProxy
{
    public class ShopProxy : IShopsProxy
    {
        public List<ShopInfo> GetData()
        {
            var fileContent = Properties.Resources.UpdateShops;
            if (string.IsNullOrEmpty(fileContent))
                return new List<ShopInfo>();

            var result = new List<ShopInfo>();

            var shops = fileContent.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var shop in shops)
            {
                var infoArray = shop.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);

                var info = new ShopInfo
                {
                    Name = infoArray[0],
                    Keywords = infoArray[1].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList()
                };

                result.Add(info);
            }

            return result;
        }
    }
}
