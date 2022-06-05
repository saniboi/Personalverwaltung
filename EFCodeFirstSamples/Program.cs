using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var teacher = new Teacher
            {
                Name = "Hans Fischer",
                Courses = new List<Course>
                {
                    new Course { Title = "VB.Net" },
                    new Course { Title = "EF" },
                    new Course { Title = "C#" }
                }
            };
            using (var context = new SchoolContext())
            {
                context.Teachers.Add(teacher);
                context.SaveChanges();
            }

            Console.WriteLine("Datenbank aktualisiert ...");
            Console.ReadLine();
        }
        
    }
}

