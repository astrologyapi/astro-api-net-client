using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ApiCall
/// Here is a simple wrapper writen 
/// who make api call for you
/// https://json.astrologyapi.com/v1/
/// Author: Ajeet Kanojia
/// Date: 06/4/15
/// Time: 5:42 PM
/// </summary>
public class ApiCall
{
	 private string userId;
    private string apiKey;
    private AstrologyAPIClient client;

    public ApiCall(string userId, string apiKey)
    {
        this.userId = userId;
        this.apiKey = apiKey;
        client = new AstrologyAPIClient(userId, apiKey);
    }

   public string makeApiCall(string apiEndPoint, string requestData, string apiType="json")
    {
        // Call the actual client
        return client.makeRequest(apiEndPoint, requestData);
    }


}