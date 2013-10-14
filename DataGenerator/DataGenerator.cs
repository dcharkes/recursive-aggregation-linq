using System;
using System.Collections.Generic;
using System.Linq;
using recursive_aggregation_linq.Model;

namespace recursive_aggregation_linq.DataGenerator
{
    class DataGenerator
    {
        public static Unit generateDataStructure(){
            Unit root = new Unit();

            for (int a = 0; a < 1000; a++)
            {
                new Student();
            }

            for (int a = 0; a < 4; a++)
            {
                Unit level1 = new Unit(root);
                for (int b = 0; b < 5; b++)
                {
                    Unit level2 = new Unit(level1);
                    for (int c = 0; c < 5; c++)
                    {
                        Assignment x = new Assignment(level2);
                        foreach (Student s in Student.allStudents)
                        {
                            new Submission("submission" + (a + b + c ^ 2 + s.Id * 37), s, x);
                        }
                    }
                }
            }

            return root;
        }
    }
}
