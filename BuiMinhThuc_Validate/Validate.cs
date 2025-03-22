
using System.Net;

namespace BuiMinhThuc_Validate
{
    public static class Validate
    {
        public static string ValidateUsername(int minLenght, int maxLenght, string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return "Username không được bỏ trống !";

            if (userName.Length < minLenght)
                return $"Username phải lớn hơn {minLenght} ký tự !";

            if (userName.Length > maxLenght)
                return $"Username phải nhỏ hơn {maxLenght} ký tự !";

            if (!System.Text.RegularExpressions.Regex.IsMatch(userName, @"^[a-zA-Z0-9_]+$"))
                return "Username không được chứa ký tự đặc biệt !";

            return userName;
        }

        public static string ValidatePassword(int minLenght, int maxLenght, string password, string confirmPassword = null)
        {
            if (string.IsNullOrEmpty(password))
                return "Password không được bỏ trống !";
            if (password.Length < minLenght)
                return $"Password phải lớn hơn {minLenght} ký tự !";
            if (password.Length > maxLenght)
                return $"Password phải nhỏ hơn {maxLenght} ký tự !";

            bool hasLower = false, hasUpper = false, hasDigit = false, hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsLower(c)) hasLower = true;
                else if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (char.IsPunctuation(c) || char.IsSymbol(c)) hasSpecial = true;
            }

            if (!(hasLower && hasUpper && hasDigit && hasSpecial))
                return "Password phải chứa ít nhất 1 ký tự thường, 1 ký tự hoa, 1 số và 1 ký tự đặc biệt !";

            if (confirmPassword != null && password != confirmPassword)
                return "Password không trùng với ConfirmPassword !";

            return password;
        }

        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return "Email không được bỏ trống !";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                return "Email không đúng định dạng !";

            return email;
        }

        public static string ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return "PhoneNumber không được bỏ trống !";
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^0[0-9]{9,10}$"))
                return "PhoneNumber không đúng định dạng !";
            return phoneNumber;
        }

        public static string ValidateFullName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                return "FullName không được bỏ trống !";
            if (!System.Text.RegularExpressions.Regex.IsMatch(fullName, @"^[a-zA-Z ]+$"))
                return "FullName không đúng định dạng !";
            return fullName;
        }

        public static string ValidateAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                return "Address không được bỏ trống !";
            return address;
        }
        public static string ValidateDateOfBirth(string dateOfBirth)
        {
            if (string.IsNullOrEmpty(dateOfBirth))
                return "DateOfBirth không được bỏ trống !";
            if (!System.Text.RegularExpressions.Regex.IsMatch(dateOfBirth, @"^([0-2][0-9]|(3)[0-1])\/(0[0-9]|1[0-2])\/\d{4}$"))
                return "DateOfBirth không đúng định dạng !";
            return dateOfBirth;
        }

        public static async  Task<bool> IsEmailActiveAsync(string email)
        {

            string domain = email.Split('@')[1];
            try
            {
                var mxRecords =await Dns.GetHostAddressesAsync(domain);
                return mxRecords != null && mxRecords.Length > 0;
            }
            catch
            {
                return false;
            }
        }

    }
}
