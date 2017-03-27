# Astrology-API-NET-Client
.NET client to consume Astrology APIs

# Demo
Click on the link to download the demo project of Vedic Rishi .Net Client.<br />
Start your download from <a href="https://www.astrologyapi.com/developers/DotNetApiClient.zip">here</a> <br />
-Replace ``` userId ``` and ``` apiKey``` with your id and keys respectively.<br />
-Downloaded project require .Net framework 4.0 or above.

# Where to get API Key
You can visit https://www.astrologyapi.com/ to get the astrology API key to be used for your websites or mobile applications.

# How To Use
1. Create your web application on .Net Framework 4.0 or above.
2. Copy & paste App_code and Bin folder to your project.
3. Instantiate VedicRishiNetClient class as follows -

    ```C#
    var client = new VedicRishiNetClient(userid, apiKey);
    ```
    Replace ``` userId ``` and ``` apiKey``` with your id and keys respectively.
    You can get the API key details from https://www.astrologyapi.com/

4. Call the api
   ```C#
   var response = client.makeRequest(apiEndPoint, requestData);
   ```
   View App_Code/ApiCall.cs for more details about calling APIs

5. How to Format request json data and api endpoint
    ```C#
    Dictionary<string, string> reqObject = new Dictionary<string, string>();

    reqObject.Add("day", 1);
    reqObject.Add("month", 10);
    reqObject.Add("year", 1990);
    reqObject.Add("hour", 9);
    reqObject.Add("min", 21);
    reqObject.Add("lat", 19.206);
    reqObject.Add("lon", 72.80);
    reqObject.Add("tzone", 5.5);


    //Request Birth Detail.
    string requestData = JsonConvert.SerializeObject(reqObject);

    // Requested Api End Point . Replace end point to call other api
    string apiEndPoint = @"birth_details/";

    ```
    View Default.aspx.cs for more details on how to parse request and response data.

6. The response will be a JSON encoded data returned as an API response. Eg. for /birth_details/ api -

    ```JS
    {
        "year":2015,
        "month":6,
        "day":28,
        "hour":13,
        "minute":21,
        "latitude":18.975,
        "longitude":72.8258,
        "timezone":5.5,
        "sunrise":"6:4:48",
        "sunset":"19:20:49",
        "ayanamsha":24.073405019935933
    }
    ```

7. How to parse the response json

    ```C#
     // Converting rturn data into json object
    var convertObj = JObject.Parse(res);

    // Display the data where you want
    var day = (string)convertObj.SelectToken("day");
    var month = (string)convertObj.SelectToken("month");
    var year = (string)convertObj.SelectToken("year");
    var hour = (string)convertObj.SelectToken("hour");
    var minute = (string)convertObj.SelectToken("minute");
    var latitude = (string)convertObj.SelectToken("latitude");
    var longitude = (string)convertObj.SelectToken("longitude");
    var timezone = (string)convertObj.SelectToken("timezone");
    var sunrise = (string)convertObj.SelectToken("sunrise");
    var sunset = (string)convertObj.SelectToken("sunset");
    var ayanamsha = (string)convertObj.SelectToken("ayanamsha");
    ```

    For API documentation, visit - https://www.astrologyapi.com/docs/
