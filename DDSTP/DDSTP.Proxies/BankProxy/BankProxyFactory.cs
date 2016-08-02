namespace DDSTP.Proxies
{
    public static class BankProxyFactory
    {
        public static IBankProxy Create()
        {
            return new BankProxyMock();
        }
    }
}
