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
/// Date: 06/4/15
/// Time: 5:42 PM
/// </summary>
public class AstrologyAPIClient
{
    public string userId, apikey;

	public AstrologyAPIClient(string Id , string Key)
	{
		//Initialising userid and Apikey

        userId = Id;
        apikey = Key;

	}
    public string makeRequest(string rquestUrl, string requestJson)
    {
        string method = "POST";
        return makeRequest(rquestUrl, method, requestJson);
    }

    public string makeRequest(string address, string method, string body)
    {
        var request = (HttpWebRequest)WebRequest.Create(@"https://json.astrologyapi.com/v1/"+address);
        request.Method = method;
        request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(userId + ":" + apikey)));
        request.PreAuthenticate = true;

        if (method == "POST")
        {
            if (!string.IsNullOrEmpty(body))
            {
                var requestBody = Encoding.UTF8.GetBytes(body);
                request.ContentLength = requestBody.Length;
                request.ContentType = "application/json; charset=utf-8";
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(requestBody, 0, requestBody.Length);
                }
            }
            else
            {
                request.ContentLength = 0;
            }
        }

        string output = string.Empty;

        try
        {
            using (var response = request.GetResponse())
            {
                using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                {
                    output = stream.ReadToEnd();
                }
            }
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                using (var stream = new StreamReader(ex.Response.GetResponseStream()))
                {
                    output = stream.ReadToEnd();
                }
            }
            else if (ex.Status == WebExceptionStatus.Timeout)
            {
                output = "Request timeout is expired.";
            }
        }


        return output;
    }
}