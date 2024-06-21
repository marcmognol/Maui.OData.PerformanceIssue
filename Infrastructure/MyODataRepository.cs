using Microsoft.OData.SampleService.Models.TripPin;

namespace Infrastructure;

public static class MyODataRepository
{
    public static async Task GetAsync()
    {
        var serviceRoot = "https://services.odata.org/V4/TripPinServiceRW/";
        var context = new DefaultContainer(new Uri(serviceRoot));

        IEnumerable<Person> people = await context.People.ExecuteAsync();
        foreach (var person in people)
        {
            Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
        }
    }
}