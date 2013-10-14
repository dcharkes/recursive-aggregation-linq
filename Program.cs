using System;
using System.Collections.Generic;
using System.Linq;
using recursive_aggregation_linq.DataGenerator;
using recursive_aggregation_linq.Model;

namespace recursive_aggregation_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit root = DataGenerator.DataGenerator.generateDataStructure();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
