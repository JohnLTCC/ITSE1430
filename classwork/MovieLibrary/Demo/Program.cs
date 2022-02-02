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

            /*
             * Size:
             * byte - 1
             * short - 2
             * int - 4
             * long - 8
             */

            //Floats
            float floatValue = 45.6F;
            double doubleValue = 5678.115;
            decimal payRate = 17.50M;

            /*
             * Size:
             * flost - 4
             * double - 8
             * decimal - a lot
             * Precision:
             * float - 5-7
             * double - 12-15
             * decimal - 80
             */

            bool isSuccessful = true;
            bool isFailing = false;

            char letterGrade = 'F';
            string name = "John";

            //This is wasteful
            int hoursWorked;
            hoursWorked = 0;

            //Scope starts at the variable declaration until the end of the block.

            //Definitely assigned
            intValue = hoursWorked;

            //Arithmatic Operators
            int x = 1, y = 2, z = 3;

            z = x + y;
            z = x - y;
            z = x * y;
            z = x / y;
            z = x % y;
            // X++ prefix increment
            // temp = x;
            // x += 1;
            // temp;
            x++;

            // ++X postfix increment
            // x += 1
            // x
            ++x;

            //X++ prefix decrement
            x--;

            //++X postfix decrement
            --x;
        }
    }
}
