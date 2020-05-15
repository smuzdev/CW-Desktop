using System;
using System.Globalization;
using System.Windows.Controls;

namespace KlingenRestaurant
{
    public class FutureDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            if (value is DateTime)
                time = (DateTime)value;
            else
                throw new Exception("LOH");
            if (time.Date < DateTime.Now.Date)
            {
                return new ValidationResult(false, $"Выберите валидную дату");
            }
            else return ValidationResult.ValidResult;
        }
    }
}