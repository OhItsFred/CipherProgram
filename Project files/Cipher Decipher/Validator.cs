using System.Text.RegularExpressions;

namespace Cipher_Decipher
{
    abstract class Validator
    {
        // stores the regex expression that is currently being used to validate the user's input
        private string regexLine = @".$";
        // if this procedure is called is updates the regexLine variable to the new regex expression that is given as a parameter
        public void updateRegex(string regex)
        {
            this.regexLine = regex;
        }

        // if the input message matches the regex expression then it returns true, otherwise the function returns false
        public virtual bool Validate(string input)
        {
            var reg = new Regex(regexLine);
            return reg.IsMatch(input);
        }
        // when this procedure is called it returns the current regex expression that is being used for validation.
        public string getRegex()
        {
            return this.regexLine;
        }


    }
}
