using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMePlease.Extension
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime ipDateTime)
        {
            int age = 0;

            age = DateTime.Now.Year - ipDateTime.Year;

            return age;
        }
    }
}