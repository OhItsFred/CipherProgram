using System.Text.RegularExpressions;

namespace Cipher_Decipher
{
    class textValidator
    {
        // stores the regex expression for the text (must be made of letters and cannot be more than 70,000 characters)
        private static readonly string textRegex = @"[A-Za-z]{1,70000}$";
        // stores the error message that will be outputted if the input does not match the above regex expression
        private static readonly string errorMessage = "ERROR - Your inputted text must contain only letters and must not be larger than 70,000 characters.";

        // if the input message matches the regex expression then it returns true, otherwise the function returns false
        public virtual bool Validate(string input)
        {
            var reg = new Regex(textRegex);
            return reg.IsMatch(input);
        }

        // if this function is called it returns the errorMessage variable that is declared above
        public string failValidate()
        {
            return errorMessage;
        }

    }
}
