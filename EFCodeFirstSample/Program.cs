﻿using System;
using System.Collections.Generic;

namespace EFCodeFirstSample
{
    internal class Program
    {
        static void Main()
        {
            using (var context = new SchoolContext())
            {
                context.Database.CreateIfNotExists();
            }

            Console.WriteLine("Datenbank wurde erstellt ...");
            Console.ReadLine();
        }
    }
}
