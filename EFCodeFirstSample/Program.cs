using System;
using System.Collections.Generic;

namespace EFCodeFirstSample
{
    internal class Program
    {
        static void Main()
        {
            using (var context = new SchoolContext())
            {
                context.Database.Create();
            }

            Console.WriteLine("Datenbank wurde erstellt ...");
            Console.ReadLine();
        }
    }
}
