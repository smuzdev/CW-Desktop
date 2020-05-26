using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace KlingenRestaurant
{
    class PasswordRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            cultureInfo = CultureInfo.CurrentCulture;
            if (!Regex.Match(charString, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9@#!^&*.]{6,})$").Success)
            {
                    return new ValidationResult(false, $"Пароль должен содержать только латинские буквы, минимум 1 букву и цифру.(может включать @#!^&*.)");
            }
            return ValidationResult.ValidResult;
        }
    }
}
