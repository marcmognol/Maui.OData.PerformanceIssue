using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Infrastructure;

public static class MyHttpRepository
{
    public static async Task<ODataResponse?> GetAsync()
    {
        var httpClient = new HttpClient();

        return await httpClient.GetFromJsonAsync<ODataResponse>("https://services.odata.org/V4/(S(r5behdg3orwkze3bmwcnjwqm))/TripPinServiceRW/People");
    }

    public class ODataResponse
    {
        [JsonPropertyName("value")]
        public People[] Value { get; set; }
    }

    public class People
    {
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }
    }
}