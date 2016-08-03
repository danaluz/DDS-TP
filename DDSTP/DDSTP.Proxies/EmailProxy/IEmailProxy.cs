namespace DDSTP.Proxies
{
    public interface IEmailProxy
    {
        void SendToAdmin(string subject, string content);
    }
}
