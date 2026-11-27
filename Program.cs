using EventHub.Data;
using Microsoft.EntityFrameworkCore;
namespace EventHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EventHubDbContext())
            {
                context.Database.Migrate();

                Console.WriteLine("EventHub Database Created Successfully!");
            }
        }
    }
}
