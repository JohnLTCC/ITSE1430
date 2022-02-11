using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Function naming rules
            //Functions are verbs
            //Functions are always Pascal cased
            //Functions should do a single, logical thing. Name should describe the action.
            static void DemoStrings()
            {
                //Strings
                var payRate = 8.75;
                var payRateString = payRate.ToString();

                // Excape sequences - character sequence that represents something unprintable
                //    \n - newline
                //    \t - horitontal tab
                //    \\ - literal slash
                //    \" - double quote
                string literal = "Hello World\nBob";
                string filePath = "C:\\windows\\system32";
                string filePath2 = @"C:\windows\system32"; // Verbatim string - ignores escape sequences

                string nullString = null;
                string emptyString = "";
                string emptyString2 = String.Empty;
                // These are not equal
                //nillString.ToString();    // crash
                //nullString + emptyString; // OK

                bool isEmpty = (emptyString == null || emptyString == ""); // Bad Practice
                isEmpty = String.IsNullOrEmpty(emptyString);
                isEmpty = emptyString.Length == 0; // Can't be null, will crash.

                // Case sensitive
                string lowerName = "bobbie", upperName = "BOBBIE";
                bool areStringEqual = lowerName == upperName; // False
                areStringEqual = lowerName.ToUpper() == upperName.ToUpper(); //Normalize, true
                areStringEqual = String.Compare(lowerName, upperName, true) == 0; // Ignores case, alterativley use StringComparison.IgnoreCase in place of true.
                areStringEqual = String.Equals(lowerName, upperName, StringComparison.CurrentCultureIgnoreCase); // also works, a bit more optimized

                // Useful string functions
                bool startswithLetter = lowerName.StartsWith("B"); // Endswith("B");
                lowerName = " BOB ";
                lowerName = lowerName.Trim(); // "BOB" // TrimStart, TrimEnd

                // Add leading spaces
                lowerName.PadLeft(20);
                lowerName.PadRight(20);

                // Joining strings
                string fullName = String.Join(' ', "Bob", "William", "Smite"); //"Bob William Smith"
                string numbesr = String.Join(", ", 1, 2, 3, 4); // "1, 2, 3, 4"

                // Split a string
                var tokens = "1 | 2 | 3 | 4".Split("|");
            }
            static void DemoPrimitives()
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
            }

            static void DemoArithmatic ()
            {
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
}
