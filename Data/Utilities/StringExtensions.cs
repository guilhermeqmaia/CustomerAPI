﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utilities
{
    public static class StringExtensions
    {
        public static string FormatCpf(this string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace(",", "").Replace("-", "");
        }
        public static string FormatPostalCode(this string postalCode)
        {
            return postalCode.Trim().Replace("-", "").Replace(".", "").Replace(",", "");
        }

        public static string FormatCellphone(this string cellphone)
        {
            return cellphone.Trim().Replace("-", "").Replace("(", "").Replace(")", "").Replace(".", "").Replace(",", "");
        }
    }
}
