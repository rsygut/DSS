namespace DSS.Services
{
    public interface IGeocodingService
    {
        Localization GetLocalizationForPlace(string name);
    }

    public class Localization
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public string County { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
