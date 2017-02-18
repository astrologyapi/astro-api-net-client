using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ApiCall
/// Here is a simple wrapper writen 
/// who make api call for you
/// http://www.vedicrishiastro.com/
/// Author: Ajeet Kanojia
/// Date: 06/4/15
/// Time: 5:42 PM
/// </summary>
public class ApiCall
{
	public ApiCall()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string makeApiCall(string apiEndPoint, string requestData)
    {
        /**
         * userId for Vedic Rishi Astro API
         * api key for Vedic Rishi Astro API access
        */
        string userid = "< Your User Id >",
                apiKey = "< Yor API Key >";


        var client = new VedicRishiNetClient(userid, apiKey);

        return client.makeRequest(apiEndPoint, requestData);

    }

}