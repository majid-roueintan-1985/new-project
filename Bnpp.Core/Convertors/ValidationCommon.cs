using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Convertors
{
    public static class ValidationCommon
    {
        public static bool IsValidIranianNationalCode(string input)
        {
            // input has 10 digits that all of them are not equal
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^(?!(\d)\1{9})\d{10}$"))
                return false;

            var check = Convert.ToInt32(input.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(input.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
        }
    }

    public class StringLengthRangeAttribute : ValidationAttribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public StringLengthRangeAttribute()
        {
            this.Minimum = 0;
            this.Maximum = int.MaxValue;
        }

        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                int len = strValue.Length;
                return len >= this.Minimum && len <= this.Maximum;
            }
            return true;
        }
    }
    public class IsValidIranianNationalCodeAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (!IsValidIranianNationalCode(strValue))
            {
                return false;
            }

            return true;
        }
        public bool IsValidIranianNationalCode(string input)
        {
            // input has 10 digits that all of them are not equal
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^(?!(\d)\1{9})\d{10}$"))
                return false;

            var check = Convert.ToInt32(input.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(input.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
        }
    }
}
