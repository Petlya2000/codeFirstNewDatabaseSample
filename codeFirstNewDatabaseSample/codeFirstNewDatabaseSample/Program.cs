using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var cout = Console.ReadLine();

                var blog = new Weather { cout = cout };
                db.Weathers.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Weathers
                            orderby b.cout
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.cout);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Weather
    {
        public int id { get; set; }
        public string cout { get; set; }

        public string country { get; set; }
        public string name { get; set; }
        public double temp { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double wind_speed { get; set; }

    }



    public class BloggingContext : DbContext
    {
        public DbSet<Weather> Weathers { get; set; }
    }
}