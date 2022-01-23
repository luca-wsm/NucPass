using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucPass.Constants
{
    public class MessageConstants
    {
        public const string MESSAGEBOX_TITLE_WARNING = "NucPass » Warning";
        public const string MESSAGEBOX_TITLE_ERROR = "NucPass » Error";
        public const string MESSAGEBOX_TITLE_INFORMATION = "NucPass » Information";
        public const string MESSAGEBOX_TITLE_SUCCESS = "NucPass » Success";
        public const string PASSWORD_OK = "OK";
        public const string PASSWORD_BOX_EMPTY = "Please enter a master password";
        public const string PASSWORD_REGEX_ERROR = "The password requires at least one upper case letter, one lower case letter, one digit, one special character and must be at least 8 letters long";
        public const string PASSWORD_NOT_MATCHES = "The passwords you entered did not match";
        public const string LOGIN_ATTEMPT_WARNING = "Warning: You have entered the wrong password four times, if you enter it incorrectly two more times, all your data will be deleted!";
        public const string LOGIN_ATTEMPT_EXECUTION = "You entered the wrong password six times. All data has been deleted. The Application will now be closed.";
        public const string PANIC_DELETE_ERROR = "An error occurred during the panic delete.";
        public const string RECOVERY_ENABLE_WARNING = "Attention: Your password will be saved encrypted in this file with AES-256. In the Forgot Password section you can choose the Recoveryfile and then your password will be copied to your clipboard. You can only use the file one time. So please be carefully, the file is the key to your masterpassword.";
        public const string RECOVERY_FILE_NOT_VALID = "The file you provided is corrupted or not valid.";
        public const string RECOVERY_VALUE_MESSAGEBOX = "Your password » "; // "\nThe Application will now be closed." will be added after the password. ( ForgotPasswordForm ) 
        public const string RECOVERY_VALUE_CLIPBOARD = "Your password copied to your clipboard. \nThe Application will now be closed.";
    }
}
