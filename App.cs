using System;
using Newtonsoft.Json.Linq;

public class App
{
    public static void Main()
    {
        // Usually read from environment variables or app settings
        string userId = "Your User ID";
        string apiKey = "Your API Key";

        // Example: Daily Horoscope
        var horo = new Horoscope(userId, apiKey);
        JObject daily = horo.GetDailyHoroscope("aries", 5.5);
        if (daily != null)
        {
            Console.WriteLine("Daily Horoscope:\n" + daily.ToString());
        }
        else
        {
            Console.WriteLine("Failed to retrieve daily horoscope.");
        }

        // Example: Matchmaking
        var match = new MatchMaking(userId, apiKey);
        JObject matchPoints = match.GetMakingResponse(
            10, 12, 1993, 1, 25, 25.0, 82.0, 5.5,
            8, 10, 1995, 2, 30, 25.0, 82.0, 5.5
        );
        if (matchPoints != null)
        {
            Console.WriteLine("Match Ashtakoot Points:\n" + matchPoints.ToString());
        }
        else
        {
            Console.WriteLine("Failed to retrieve match points.");
        }

        // Example: Numerology
        var numero = new Numerology(userId, apiKey);
        JObject numerology = numero.GetNumerology("Your Name", 1, 1, 2020);
        if (numerology != null)
        {
            Console.WriteLine("Numerology:\n" + numerology.ToString());
        }

        // Example: Premium Kundli Report
        var pdf = new PDF(userId, apiKey);
        JObject pdfHoroscope = pdf.GetPDFResponse("Your Name", "Male", 1, 1, 2020, 1, 1, 25.0, 82.0, 5.5, "Your Place");
        if (pdfHoroscope != null)
        {
            Console.WriteLine("Premium Kundli Report:\n" + pdfHoroscope.ToString());
        }
    }
}
