using System;

namespace Cipher_Decipher
{
    class KeyValidator : Validator
    {
        // each variable stores the respective regex expression for that cipher's key validation
        private static readonly string atbashRegex = @".$";
        private static readonly string caesarRegex = @"([\d]{1,2})$";
        private static readonly string columnarTranspositionRegex = @"([A-Za-z])$";
        private static readonly string keywordRegex = @"([A-Za-z]{1,26})$";
        private static readonly string letterSubRegex = @".$";
        private static readonly string railFenceRegex = @"([^0\d])$";
        private static readonly string vatsyayanaRegex = @".$";
        private static readonly string vigenereRegex = @"([A-Za-z])$";
        private static readonly string oneTimePadRegex = @"([A-Za-z])$";
        private static readonly string bifidRegex = @"[A-Z]$";
        private static readonly string trifidRegex = @"[A-Z+]$";

        // stores an array of all the expression for the key validators
        private static readonly String[] regexExpression = { atbashRegex, caesarRegex, columnarTranspositionRegex, keywordRegex, letterSubRegex, railFenceRegex, vatsyayanaRegex,vigenereRegex, oneTimePadRegex, bifidRegex, trifidRegex};
        // stores the error messages that are associated to each cipher's key if the user's input doesen't match the regular expression
        private static readonly string[] errorMessage = {"ERROR: Please try again.", "ERROR: The key must be one or two number digits (0-9).", "ERROR: The keyword must be made solely of letters.", "ERROR: Please try again.", "ERROR: Please try again.", "ERROR: The key must be a number that is above 0.", "ERROR: Please try again.", "ERROR: The keyword must be made solely of letters.", "ERROR: The keyword must be made solely of letters.", "ERROR: The keyword must be made of capitalised letters only", "ERROR: The keyword must made of capitalised letters only and one addition symbol." };
        
        // returns the regular expression within the regexExpression array by its position
        public string findRegex(int i)
        {
            return regexExpression[i];
        }
        
        // returns the error message that is associated with the regular expression currently being used to validate
        public string failValidate()
        {
            int i = Array.IndexOf(regexExpression,getRegex());
            return errorMessage[i];
        }
        public bool lengthCheck(int keyLength, int messageLength)
        {
            return messageLength < keyLength;
        }


    }
}
