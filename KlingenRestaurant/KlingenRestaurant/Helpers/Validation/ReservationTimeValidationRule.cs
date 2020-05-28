using System;
using System.Globalization;
using System.Windows.Controls;

namespace KlingenRestaurant
{
    public class ReservationTimeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            if (value is DateTime)
                time = (DateTime)value;
            else
                throw new Exception("123");
            if (time.Hour < DateTime.Now.Hour)
            {
                return new ValidationResult(false, $"Введите корректное время");
            }
            else if (time.Hour == DateTime.Now.Hour && time.Minute < DateTime.Now.Minute)
            {
                return new ValidationResult(false, $"Введите корректное время");
            }
            else return ValidationResult.ValidResult;
        }
    }
}