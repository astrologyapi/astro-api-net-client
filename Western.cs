using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Western
{
    private string userId;
    private string apiKey;

    public Western(string userId, string apiKey)
    {
        this.userId = userId;
        this.apiKey = apiKey;
    }

    public JObject GetWesternResponse( int day, int month, int year, int hour, int min, double lat, double lon, double tzone)
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
        string endpoint = $"natal_wheel_chart";

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
