using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primitives
            //Integrals
            sbyte sbyteValue = 10;
            short shortValue = 20;
            int intValue = 62_543; //The compiler ignores underscores.
            long longValue = 40L; //L to turn the literal to a long.

            //Floats
            float floatValue = 45.6F;
            double doubleValue = 5678.115;
            decimal payRate = 17.50M;

            bool isSuccessful = true;
            bool isFailing = false;

            char letterGrade = 'F';
            string name = "John";

            int hoursWorked;

            //Scope starts at the variable declaration until the end of the block.

            //hoursWorked = 10;
            intValue = hoursWorked;
        }
    }
}
