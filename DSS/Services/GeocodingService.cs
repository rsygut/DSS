using DSS.Extensions;
using Google.Maps;
using Google.Maps.Geocoding;
using Google.Maps.Places;
using Google.Maps.Shared;
using System.Linq;

namespace DSS.Services
{
    public class GeocodingService : IGeocodingService
    {
        public GeocodingService()
        {
            GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyAp40B1RQsmp1VJ07YA9dD1JPsl8MnwEfg"));
        }

        public Localization GetLocalizationForPlace(string name)
        {
            TextSearchRequest request = new TextSearchRequest()
            {
                Query = name,
                Sensor = false
            };

            var placesService = new PlacesService().GetResponse(request);
            var place = placesService.Results.FirstOrDefault();
            if (place == null)
            {
                return null;
            }

            var geocodingRequest = new GeocodingRequest();
            geocodingRequest.Address = $"{place.Geometry.Location.Latitude}, {place.Geometry.Location.Longitude}";
            geocodingRequest.Sensor = false;
            var geolocation = new Google.Maps.Geocoding.GeocodingService().GetResponse(geocodingRequest).Results.FirstOrDefault();
            
            return new Localization
            {
                Name = place.Name,
                Latitude = place.Geometry.Location.Latitude,
                Longitude = place.Geometry.Location.Longitude,
                Province = geolocation?.AddressComponents.FirstOrDefault(a => a.Types.Any(t => t.Equals(AddressType.AdministrativeAreaLevel1)))
                        ?.LongName.UpperCaseFirstLetter(),
                County = geolocation?.AddressComponents.FirstOrDefault(a => a.Types.Any(t => t.Equals(AddressType.AdministrativeAreaLevel2)))
                        ?.LongName.UpperCaseFirstLetter()
            };
        }
    }
}