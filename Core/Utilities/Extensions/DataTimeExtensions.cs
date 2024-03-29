﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Extensions
{
    public static class DataTimeExtensions
    {
        public static string FullDateAndTimeStringWithUnderscore(this DateTime dateTime)
        {
            return $"{dateTime.Millisecond}" +
                $"_{dateTime.Second}_{dateTime.Minute}" +
                $"_{dateTime.Hour}_{dateTime.Day}_{dateTime.Month}" +
                $"_{dateTime.Year}";

        }
    }
}
