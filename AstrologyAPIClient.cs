using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Net;

/// <summary>
/// Summary description for AstrologyAPIClient
/// AstrologyAPI Client for consuming AstrologyAPIs
/// https://json.astrologyapi.com/v1/
/// Author: Ajeet Kanojia
/// Updated by: Suraj Yadav
/// Updated on : 29/1/25
/// Date: 06/4/15
/// Time: 5:42 PM
/// </summary>
public class AstrologyAPIClient
{
    // Base URLs
    private readonly string baseUrlJson = "https://json.astrologyapi.com/v1/";
    private readonly string baseUrlPdf  = "https://pdf.astrologyapi.com/v1/";

    public string userId;
    public string apikey;

    public AstrologyAPIClient(string Id , string Key)
    {
        userId = Id;
        apikey = Key;
    }

    // Helper method to pick the right base URL
    private string GetBaseUrl(string apiType)
    {
        if (string.Equals(apiType, "pdf", StringComparison.OrdinalIgnoreCase))
        {
            return baseUrlPdf;
        }
        return baseUrlJson; 
    }

   public string makeRequest(string requestUrl, string requestJson)
{
    return makeRequest(requestUrl, "POST", requestJson, "json");
}

public string makeRequest(string requestUrl, string method, string requestJson, string apiType)
{
    var baseUrl = GetBaseUrl(apiType);
    string fullUrl = baseUrl + requestUrl;

    var request = (HttpWebRequest)WebRequest.Create(fullUrl);
    request.Method = method;
    request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(userId + ":" + apikey)));
    request.PreAuthenticate = true;

    if (method == "POST" && !string.IsNullOrEmpty(requestJson))
    {
        var requestBody = Encoding.UTF8.GetBytes(requestJson);
        request.ContentLength = requestBody.Length;
        request.ContentType = "application/json; charset=utf-8";
        using (var requestStream = request.GetRequestStream())
        {
            requestStream.Write(requestBody, 0, requestBody.Length);
        }
    }

    using (var response = request.GetResponse())
    {
        using (var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        {
            return stream.ReadToEnd();
        }
    }
}

}
