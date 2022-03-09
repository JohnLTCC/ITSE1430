using System;

namespace Demo
{
    class Demo
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
            static void DemoObject()
            {
                //Object val = 10;
                //val = "Hello";
                //val = null;

                //Methods
                //   ToString()
                int demoInt;
                demoInt.ToString(); // converts to string
                //   Equals()
                string demoString, demoString2;
                demoString.Equals(demoString2); // compares demoString to parameter.
                Equals(demoString, demoString2); // compares the two parameters
                //   GetType()
                //   GetHashCode()

            }
            static void DemoTypeChecking(object data)
            {
                //Type checking

                //Assume a string

                //C-style case
                //    Runtime rerror if wrong
                //    No way to validate at runtime
                //    Still compile safe time (string)10;
                var dataString = (string)data;

                // is-operator ::= E is T -> boolean
                if (data is string)
                {
                    dataString = (string)data;
                };

                // as-operator ::= E as T -> T or null
                //    Only works if T supports nulls (strings, objects, class types)
                dataString = data as string;
                if(dataString != null) { };

                //Pattern matching ::=  E is T id -> (boolean with id as typed value if true)
                //    dataString2's scope is limited to the if statement
                if (data is string dataString2) { };
            }
            static void DemoReferencesAndValues()
            {
                /* Types
                 * 
                *   Reference - Classes - strings and classes
                *     memory - heep (new) holds the reference to a place in memory
                *     assignment - changes the memory addresss in the variable, does not copy
                *     equality - compares address to memory, the values in the memory are irrelevent
                *     nullability - can store nulls
                *     construction - customizable
                *     inheritence - supports it
                *     mute-ability - whatever
                *     
                *   Value - Struct - Primitives (except string)
                *     memory - call stack (always valid)
                *     assignment - copies the values
                *     equality - if all values equal
                *     nullability - cannot store nulls, call stack can't have nulls
                *     construction - 0 initializes the data set
                *     inheritence - Is not supported
                *     mute-ability - should be immutable (shouldn't change values without reassignment)
                */
            }
            static void DemoConstructor()
            {
                // Do minimal initialization of instance, if any
                // Don"t initialize fields - use field inizializers
                // Unless
                //    Depends on other fields
                //    Relies on data available after initialization

                //Constructor chaining
                //   public MovieDatabase(string name) : this() <- calls another constructor works with overloaded as well
            }
            static void DemoInheritence()
            {
                //Example - public class MemoryMovieDatabase : MovieDatabase
                // - Virtual modifier on the base method
                // - override modifier on the derived method
                // - base.Add(); - to refer to base's method
                // - class() : base() - to call the base classes constructor
                //   - this happens by defualt. Only use for if there are other constructors
                // - Protected is an access modifier that makes the member public for derived types
            }
            static void DemoNamespace()
            {
                // System.Windows.Form.Form form = new System.Windows.Forms.Form();
            }
        }
    }
}
