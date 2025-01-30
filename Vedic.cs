using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Vedic
{
    private string userId;
    private string apiKey;

    public Vedic(string userId, string apiKey)
    {
        this.userId = userId;
        this.apiKey = apiKey;
    }

    public JObject GetVedicResponse( int day, int month, int year, int hour, int min, double lat, double lon, double tzone)
    {
        
    
        var requestDataObj = new {
            
        
            day = day,
            month = month,
            year = year,
            hour = hour,
            min = min,
            lat = lat,
            lon = lon,
            tzone = tzone,
           
        };
        string requestJson = JsonConvert.SerializeObject(requestDataObj);

        // Endpoint name
        string endpoint = $"birth_details";

        // Call the API using your wrapper
        string response = new ApiCall(userId, apiKey).makeApiCall(endpoint, requestJson,"json");
        
        // Parse with Newtonsoft.Json
        if (!string.IsNullOrEmpty(response))
        {
            return JObject.Parse(response);
        }

        return null;
    }
}
