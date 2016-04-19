namespace DDSTP.Domain
{
    public interface IPOI
    {
        int ID { get; set; }
        float Latitude { get; set; }
        float Longitude { get; set; }
        string Name { get; set; }
        Street MainStreet { get; set; }
        int? Number { get; set; }
        TypeOfPOI Type { get; }
        bool IsNear(double lat, double lon);
        bool IsAvailable();
    }
}