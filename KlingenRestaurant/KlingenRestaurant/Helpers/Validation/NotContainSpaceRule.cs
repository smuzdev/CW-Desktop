using System.Globalization;
using System.Windows.Controls;

namespace KlingenRestaurant
{
    class NotContainSpaceRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            cultureInfo = CultureInfo.CurrentCulture;
                return value.ToString().Contains(" ") ? new ValidationResult(false, "Пробелы не разрешены в этом поле")
                : ValidationResult.ValidResult;
        }
    }
}
