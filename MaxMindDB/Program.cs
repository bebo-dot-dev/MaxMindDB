/*
    https://dev.maxmind.com/geoip/geolite2-free-geolocation-data?lang=en#accessing-geolite2-free-geolocation-data
    https://www.maxmind.com/en/accounts/current/geoip/downloads
    
    replace YOUR_LICENSE_KEY with a MaxMind license key
    
    curl -v 'https://download.maxmind.com/app/geoip_download?edition_id=GeoLite2-Country&license_key=YOUR_LICENSE_KEY&suffix=tar.gz.sha256' --output ./GeoLite2-Country.tar.gz.sha256
    curl -v 'https://download.maxmind.com/app/geoip_download?edition_id=GeoLite2-Country&license_key=YOUR_LICENSE_KEY&suffix=tar.gz' --output ./GeoLite2-Country.tar.gz
    cat ./GeoLite2-Country.tar.gz.sha256
    sha256sum ./GeoLite2-Country.tar.gz
    tar -xzf ./GeoLite2-Country.tar.gz
*/

using MaxMind.GeoIP2;

using var reader = new DatabaseReader("./GeoLite2-Country.mmdb");
Console.WriteLine(reader.TryCountry("24.24.24.24", out var countryResponse)
    ? $"{countryResponse!.Country.Name}:{countryResponse!.Country.IsoCode}" //United States:US
    : "country not found");