using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Horoscope
{
    private string userId;
    private string apiKey;

    public Horoscope(string userId, string apiKey)
    {
        this.userId = userId;
        this.apiKey = apiKey;
    }

    public JObject GetDailyHoroscope(string zodiacName, double timezone)
    {
        // This matches: https://json.astrologyapi.com/v1/sun_sign_prediction/daily/<zodiacName>
        // Prepare the request data (if needed).
        // Some endpoints need a JSON object, but many just read from the URL.
        

        // In many endpoints, you pass JSON with day, month, year, etc. 
        // For a daily sun sign, you might have a simpler input.

        // Build the JSON string (if the API requires a body).
        // For a daily sun sign, the request might be empty or just pass timezone.
        var requestDataObj = new {
            zodiacName = zodiacName,
            timezone = timezone
        };
        string requestJson = JsonConvert.SerializeObject(requestDataObj);

        // Endpoint name
        string endpoint = $"sun_sign_prediction/daily/{zodiacName}";

        // Call the API using your wrapper
        string response = new ApiCall(userId, apiKey).makeApiCall(endpoint, requestJson);
        
        // Parse with Newtonsoft.Json
        if (!string.IsNullOrEmpty(response))
        {
            return JObject.Parse(response);
        }

        return null;
    }
}
