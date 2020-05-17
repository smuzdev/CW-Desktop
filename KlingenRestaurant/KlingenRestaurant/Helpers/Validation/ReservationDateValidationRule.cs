using System;
using System.Globalization;
using System.Windows.Controls;

namespace KlingenRestaurant
{
    public class ReservationDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            if (value is DateTime)
                time = (DateTime)value;
            else
                throw new Exception("123");
            if (time.Date < DateTime.Now.Date)
            {
                return new ValidationResult(false, $"Введите корректную дату");
            }
            else return ValidationResult.ValidResult;
        }
    }
}