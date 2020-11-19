using System;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = DateTime.Today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age))
                --age;
            
            return age;
        }
    }
}