using System.Globalization;
using System.Windows.Controls;

namespace KlingenRestaurant
{
    public class MaximumCharacterRule : ValidationRule
    {
        public int MaximumCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            cultureInfo = CultureInfo.CurrentCulture;

            if (charString.Length >= MaximumCharacters)
            {
                    return new ValidationResult(false, $"Поле должно содержать не более {MaximumCharacters} символов.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
