using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class PDF
{
    private string userId;
    private string apiKey;

    public PDF(string userId, string apiKey)
    {
        this.userId = userId;
        this.apiKey = apiKey;
    }

    public JObject GetPDFResponse(string name,string gender ,int day, int month, int year, int hour, int min, double lat, double lon, double tzone, string place)
    {
 
        var requestDataObj = new {
            name = name,
            gender = gender,
            day = day,
            month = month,
            year = year,
            hour = hour,
            minute = min,
            latitude = lat,
            longitude = lon,
            timezone = tzone,
            place = place
        };
        string requestJson = JsonConvert.SerializeObject(requestDataObj);

        // Endpoint name
        string endpoint = $"premium_kundli_report";

        // Call the API using your wrapper
        string response = new ApiCall(userId, apiKey).makeApiCall(endpoint, requestJson, "pdf");
        
        // Parse with Newtonsoft.Json
        if (!string.IsNullOrEmpty(response))
        {
            return JObject.Parse(response);
        }

        return null;
    }
}
