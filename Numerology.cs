using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Numerology
{
    private string userId;
    private string apiKey;

    public Numerology(string userId, string apiKey)
    {
        this.userId = userId;
        this.apiKey = apiKey;
    }

    public JObject GetNumerology(string name, int day, int month, int year)
    {
        // This matches: https://json.astrologyapi.com/v1/numero_table
    
        var requestDataObj = new {
            
            name =name,
            day = day,
            month = month,
            year = year,
           
        };
        string requestJson = JsonConvert.SerializeObject(requestDataObj);

        // Endpoint name
        string endpoint = $"numero_table";

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
