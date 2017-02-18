using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public partial class _Default : System.Web.UI.Page
{
    
    public void btnCallRestAPI_Click(object sender, EventArgs e)
    {

        string Day = dayText.Text.ToString();
        string Month = monthText.Text.ToString();
        string Year = yearText.Text.ToString();
        string Hour = hourText.Text.ToString();
        string Min = minuteText.Text.ToString();
        string Lat = latText.Text.ToString();
        string lon = lonText.Text.ToString();
        string Tzone = tzoneText.Text.ToString();
            
        Dictionary<string, string> reqObject = new Dictionary<string, string>();

        //For other astro api
        //----------------------------------------------------------------------
        reqObject.Add("day", Day);
        reqObject.Add("month", Month);
        reqObject.Add("year", Year);
        reqObject.Add("hour", Hour);
        reqObject.Add("min", Min);
        reqObject.Add("lat", Lat);
        reqObject.Add("lon", lon);
        reqObject.Add("tzone", Tzone);


        //For Matching Api
        //----------------------------------------------------------------------
        //reqObject.Add("m_day", "5");
        //reqObject.Add("m_month", "2");
        //reqObject.Add("m_year", "1986");
        //reqObject.Add("m_hour", "3");
        //reqObject.Add("m_min", "2");
        //reqObject.Add("m_lat", "18.975");
        //reqObject.Add("m_lon", "72.8258");
        //reqObject.Add("m_tzone", "5.5");
        //reqObject.Add("f_day", "3");
        //reqObject.Add("f_month", "2");
        //reqObject.Add("f_year", "1986");
        //reqObject.Add("f_hour", "3");
        //reqObject.Add("f_min", "2");
        //reqObject.Add("f_lat", "18.975");
        //reqObject.Add("f_lon", "72.8258");
        //reqObject.Add("f_tzone", "5.5");



        //Request Birth Detail.
        string requestJson = JsonConvert.SerializeObject(reqObject);

        // Requested Api End Point . Replace end point to call other api
        string endPoint = @"birth_details/";


        // Calling APi from here
        /**
         * Change userid and Api Key Before using this.
         * Replace your userId and ApiKey in this file
         * App_Code/ApiCalls.cs
         */

        var client = new ApiCall();
        var res = client.makeApiCall(endPoint, requestJson);

        // Converting rturn data into json object
        var convertObj = JObject.Parse(res);

        // Display the data where you want
        dayResponse.Text = (string)convertObj.SelectToken("day");
        monthResponse.Text = (string)convertObj.SelectToken("month");
        yearResponse.Text = (string)convertObj.SelectToken("year");
        hourResponse.Text = (string)convertObj.SelectToken("hour");
        minResponse.Text = (string)convertObj.SelectToken("minute");
        latResponse.Text = (string)convertObj.SelectToken("latitude");
        lonResponse.Text = (string)convertObj.SelectToken("longitude");
        tzoneResponse.Text = (string)convertObj.SelectToken("timezone");
        sunriseResponse.Text = (string)convertObj.SelectToken("sunrise");
        sunsetResponse.Text = (string)convertObj.SelectToken("sunset");
        ananResponse.Text = (string)convertObj.SelectToken("ayanamsha");


        entireResponse.Text = res;

        //See return response in console output
        System.Diagnostics.Debug.WriteLine("response--" + convertObj);


    }

    
}