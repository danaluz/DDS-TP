namespace DDSTP.Proxies
{
    public static class CentroDTOFactory
    {
        public static IObtenerDTO Create()
        {
            return new ObtenerDTOPrecargado();
        }
    }
}
