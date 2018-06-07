using System.Text;

namespace Core
{
    public static class PhonewordTranslator
    {
        // The ToNumber function which takes in letters and translates into numbers
        public static string ToNumber(string raw)
        {
            // If entry label entry then return nothing
            if (string.IsNullOrWhiteSpace(raw))
                return null;

            // Uppercase the string 
            raw = raw.ToUpperInvariant();

            // Create a new variable that will store the characters as a string
            var newNumber = new StringBuilder();
            // Run a for loop for each character (c) in the raw string
            foreach (var c in raw)
            {
                //If the character matches with any of these then add it to the number variable
                if (" -0123456789".Contains(c))
                    newNumber.Append(c);

                else
                {
                    // If not found then use TranslateToNumber function to get a digit 
                    var result = TranslateToNumber(c);
                    // If the result isn't null then append it to the number
                    if (result != null)
                        newNumber.Append(result);
                    // Bad character?
                    else
                        return null;
                }
            }
            // After the number has been made it is sent back as a string
            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        // A read only array is created 
        static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };


        // Pass the character into the function
        static int? TranslateToNumber(char c)
        {
            // Start a loop that checks if the character can be found in the array
            for (int i = 0; i < digits.Length; i++)
            {
                // i is the part of the array eg 0 "ABC"
                if (digits[i].Contains(c))
                    // If found then return the value +2
                    return 2 + i;
            }
            return null;
        }
    }
}