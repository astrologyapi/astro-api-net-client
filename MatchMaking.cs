using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class MatchMaking
{
    private string userId;
    private string apiKey;

    public MatchMaking(string userId, string apiKey)
    {
        this.userId = userId;
        this.apiKey = apiKey;
    }

    // Example: "match_ashtakoot_points"
    // Both male & female data
    public JObject GetMakingResponse(
        int m_day, int m_month, int m_year, int m_hour, int m_min, double m_lat, double m_lon, double m_tzone,
        int f_day, int f_month, int f_year, int f_hour, int f_min, double f_lat, double f_lon, double f_tzone
    )
    {
        var requestData = new {
            m_day, m_month, m_year, m_hour, m_min, m_lat, m_lon, m_tzone,
            f_day, f_month, f_year, f_hour, f_min, f_lat, f_lon, f_tzone
        };
        string requestJson = JsonConvert.SerializeObject(requestData);

        string endpoint = "match_ashtakoot_points"; // per your Java code
        string response = new ApiCall(userId, apiKey).makeApiCall(endpoint, requestJson,"json");

        if (!string.IsNullOrEmpty(response))
        {
            return JObject.Parse(response);
        }
        return null;
    }
}
