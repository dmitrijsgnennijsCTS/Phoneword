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
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                    // Bad character?
                    else
                        return null;
                }
            }
            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}