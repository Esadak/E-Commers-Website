using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entity;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsyn(StoreContext context, ILogger logger)
        {

            try{
                if(!context.Courses.Any())
                {
                    var CourseData = File.ReadAllText("../Infrastructure/SeedData/courses.json");
                    var courses = JsonSerializer.Deserialize<List<Course>>(CourseData);
                    foreach(var item in courses)
                    {
                        context.Courses.Add(item);
                    }
                    await context.SaveChangesAsync();

                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);

            }
        }
    }
}